using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TccoTabrizBus
{
    class Program
    {
        private const string LOGIN = "ورود", LOGOUT = "خروج", WEBSITE = "وبسایت",
            NEXT = "بعدی",
            CANCEL = "لغو",
            NEXT_DAY = "روز بعد",
            HOME = "صفحه اصلی",
            PREVIOUS_DAY = "روز قبل",
            PERFORMANCE_REPORT = "گزارش کارکرد",
            ACCOUNTING_REPORT = "گزارش حسابداری",
            WELCOME_MESSAGE = "خوش آمدید. برای وارد شدن به حساب کاربری خود دکمه ورود را بزنید.",
            LOGIN_ENTER_USERNAME_MESSAGE = "لطفا نام کاربری خود را وارد کنید و دکمه بعدی را کلیک کنید.",
        LOGIN_ENTER_PASSWORD_MESSAGE = "لطفا کلمه عبور خود را وارد کنید و دکمه بعدی را کلیک کنید.",
            LOGIN_FAILED_MESSAGE = "نام کاربری یا کلمه عبور شما اشتباه است.",
            LOGIN_SUCCESS_MESSAGE = "شما وارد حساب کاربری خود شدید.";
        // private static MonoCP.Telegram.TelegramAPI _telegramAPI;
        static long _offset = 0;
        private static MonoCP.Telegram.Types.ReplyKeyboardMarkup _guestKeyboard, _cancelKeyboard, _doLogin, _accountKeyboard, _dayNavigator;
        private static List<User> _users;
        private static NetManager2 _telegramAPI = new NetManager2("362514771:AAEh2WAdZBtQ6dFMJBJ4_a5KIzo9ajV50os");

        static void Main(string[] args)
        {
            Init();
            GetUpdates();
            Console.Read();
        }

        private static void Init()
        {
            //_telegramAPI = new MonoCP.Telegram.TelegramAPI("362514771:AAEh2WAdZBtQ6dFMJBJ4_a5KIzo9ajV50os");
            //_telegramAPI.ResponseUpdateEvent += _telegramAPI_ResponseUpdateEvent;

            _users = new List<User>();

            _guestKeyboard = InitArrangedKeyboard(1, 1, LOGIN);
            _cancelKeyboard = InitArrangedKeyboard(1, 1, CANCEL);
            _doLogin = InitArrangedKeyboard(1, 2, CANCEL, LOGIN);
            _accountKeyboard = InitArrangedKeyboard(2, 2, PERFORMANCE_REPORT, ACCOUNTING_REPORT, LOGOUT, WEBSITE);
            _dayNavigator = InitArrangedKeyboard(1, 3, PREVIOUS_DAY, HOME, NEXT_DAY);
        }

        private static MonoCP.Telegram.Types.ReplyKeyboardMarkup InitArrangedKeyboard(int row, int col, params string[] buttonTexts)
        {
            MonoCP.Telegram.Types.ReplyKeyboardMarkup buttons = new MonoCP.Telegram.Types.ReplyKeyboardMarkup();
            buttons.keyboard = new MonoCP.Telegram.Types.KeyboardButton[row][];
            int i, j, index = 0;
            for (i = 0; i < buttons.keyboard.Length; i++)
            {
                buttons.keyboard[i] = new MonoCP.Telegram.Types.KeyboardButton[col];
                for (j = 0; j < buttons.keyboard[i].Length; j++)
                {
                    buttons.keyboard[i][j] = new MonoCP.Telegram.Types.KeyboardButton() { text = buttonTexts[index++] };
                }
            }
            return buttons;
        }
        private static async void GetUpdates()
        {
            MonoCP.Telegram.Types.ResultUpdate ru;
            while (true)
            {
                //_telegramAPI.GetUpdates(_offset);
                ru = await _telegramAPI.GetUpdate(_offset);
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_telegramAPI_ResponseUpdateEvent));
                t.IsBackground = true;
                t.Start(ru);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private static void _telegramAPI_ResponseUpdateEvent(object o)
        {
            if (o == null || o == null) return;
            MonoCP.Telegram.Types.ResultUpdate ru = (MonoCP.Telegram.Types.ResultUpdate)o;
            if (ru.GetType().Equals(typeof(MonoCP.Telegram.Types.ResultUpdate)))
            {
                User _currentUser = null;
                //MonoCP.Telegram.Types.ResultUpdate results = e.GetResult<MonoCP.Telegram.Types.ResultUpdate>();
                foreach (MonoCP.Telegram.Types.Update u in ru.result)
                {
                    _offset = u.update_id + 1;
                    _currentUser = _users.Find(x => x.id == u.message.from.id);
                    if (_currentUser == null)// guest
                    {
                        _currentUser = new User()
                        {
                            ChatId = u.message.chat.id.ToString(),
                            first_name = u.message.chat.first_name,
                            last_name = u.message.chat.last_name,
                            id = u.message.from.id,
                            username = u.message.chat.username,
                            LastMessage = u.message.text
                        };
                        _users.Add(_currentUser);
                        _telegramAPI.SendMessage(_currentUser.ChatId, WELCOME_MESSAGE, _guestKeyboard);
                    }
                    _currentUser.LastMessage = u.message.text;

                    Report(_currentUser.GetFullName() + " : " + _currentUser.LastMessage);

                    if (_currentUser.LastMessage.Equals(LOGIN) && _currentUser.State == StateEnum.Guest)//login 
                    {
                        _currentUser.State = StateEnum.EnteringUsername;
                        _currentUser.Location = LocationEnum.LoginPage;
                        _telegramAPI.SendMessage(_currentUser.ChatId, LOGIN_ENTER_USERNAME_MESSAGE, _cancelKeyboard);
                    }
                    else if (_currentUser.LastMessage == CANCEL && (_currentUser.State == StateEnum.EnteringUsername || _currentUser.State == StateEnum.EnteringPassword))
                    {
                        _telegramAPI.SendMessage(_currentUser.ChatId, WELCOME_MESSAGE, _guestKeyboard);
                        _currentUser.Logout();
                    }
                    else if (_currentUser.LastMessage == PERFORMANCE_REPORT && _currentUser.State == StateEnum.LoggedIn)
                    {
                        _currentUser.Location = LocationEnum.DailyPerformance;
                        _currentUser.ReportDate = DateTime.Today;
                        string s = _currentUser.GetWroksReport().Result;
                        _telegramAPI.SendMessage(_currentUser.ChatId, "کارکرد روز " + _currentUser.ReportDate.ToString("yyyy-MM-dd") + " = " + s, _dayNavigator);
                    }
                    else if (_currentUser.LastMessage == ACCOUNTING_REPORT && _currentUser.State == StateEnum.LoggedIn)
                    {
                        _currentUser.Location = LocationEnum.AccountingReports;
                        _currentUser.ReportDate = DateTime.Today;
                        string s = _currentUser.GetFinanceReport().Result;
                        _telegramAPI.SendMessage(_currentUser.ChatId, "گزارش حسابداری روز " + _currentUser.ReportDate.ToString("yyyy-MM-dd") + " = " + s, _dayNavigator);
                    }
                    else if (_currentUser.LastMessage == LOGOUT && _currentUser.State == StateEnum.LoggedIn)
                    {
                        _telegramAPI.SendMessage(_currentUser.ChatId, WELCOME_MESSAGE, _guestKeyboard);
                        _currentUser.Logout();
                    }
                    else if (_currentUser.LastMessage == WEBSITE && _currentUser.State == StateEnum.LoggedIn)
                    {
                        _telegramAPI.SendMessage(_currentUser.ChatId, "http://www.tcco.ir");
                    }
                    else if (_currentUser.LastMessage == NEXT_DAY && _currentUser.State == StateEnum.LoggedIn && _currentUser.Location == LocationEnum.DailyPerformance)
                    {
                        _currentUser.ReportDate = _currentUser.ReportDate.AddDays(1);
                        string s = _currentUser.GetWroksReport().Result;
                        _telegramAPI.SendMessage(_currentUser.ChatId, "کارکرد روز " + _currentUser.ReportDate.ToString("yyyy-MM-dd") + " = " + s, _dayNavigator);
                    }
                    else if (_currentUser.LastMessage == PREVIOUS_DAY && _currentUser.State == StateEnum.LoggedIn && _currentUser.Location == LocationEnum.DailyPerformance)
                    {
                        _currentUser.ReportDate = _currentUser.ReportDate.AddDays(-1);
                        string s = _currentUser.GetWroksReport().Result;
                        _telegramAPI.SendMessage(_currentUser.ChatId, "کارکرد روز " + _currentUser.ReportDate.ToString("yyyy-MM-dd") + " = " + s, _dayNavigator);
                    }
                    else if (_currentUser.LastMessage == NEXT_DAY && _currentUser.State == StateEnum.LoggedIn && _currentUser.Location == LocationEnum.AccountingReports)
                    {
                        _currentUser.ReportDate = _currentUser.ReportDate.AddDays(1);
                        string s = _currentUser.GetFinanceReport().Result;
                        _telegramAPI.SendMessage(_currentUser.ChatId, "گزارش حسابداری روز " + _currentUser.ReportDate.ToString("yyyy-MM-dd") + " = " + s, _dayNavigator);
                    }
                    else if (_currentUser.LastMessage == PREVIOUS_DAY && _currentUser.State == StateEnum.LoggedIn && _currentUser.Location == LocationEnum.AccountingReports)
                    {
                        _currentUser.ReportDate = _currentUser.ReportDate.AddDays(-1);
                        string s = _currentUser.GetFinanceReport().Result;
                        _telegramAPI.SendMessage(_currentUser.ChatId, "گزارش حسابداری روز " + _currentUser.ReportDate.ToString("yyyy-MM-dd") + " = " + s, _dayNavigator);
                    }
                    else if (_currentUser.LastMessage == HOME && _currentUser.State == StateEnum.LoggedIn)
                    {
                        _currentUser.Location = LocationEnum.AccountHomePage;
                        _telegramAPI.SendMessage(_currentUser.ChatId, HOME, _accountKeyboard);
                    }
                    else if (_currentUser.State == StateEnum.EnteringUsername)// user should enter username
                    {
                        _currentUser.CredentialUsername = _currentUser.LastMessage;
                        _currentUser.State = StateEnum.EnteringPassword;
                        _telegramAPI.SendMessage(_currentUser.ChatId, LOGIN_ENTER_PASSWORD_MESSAGE);
                    }
                    else if (_currentUser.State == StateEnum.EnteringPassword)// user should enter password
                    {
                        _currentUser.CredentialPassword = _currentUser.LastMessage;
                        if (_currentUser.Login().Result)
                        {
                            _telegramAPI.SendMessage(_currentUser.ChatId, LOGIN_SUCCESS_MESSAGE, _accountKeyboard);
                        }
                        else
                        {
                            _telegramAPI.SendMessage(_currentUser.ChatId, LOGIN_FAILED_MESSAGE, _guestKeyboard);
                        }
                    }
                    else
                    {
                        _telegramAPI.SendMessage(_currentUser.ChatId, " ", _guestKeyboard);
                    }

                }
                return;
            }
        }

        private static void Report(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
