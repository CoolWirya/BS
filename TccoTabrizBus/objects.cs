using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoCP.Telegram.Types
{
    [System.Runtime.Serialization.DataContract]
    public class ResultUpdate
    {
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string ok { get; set; }


        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public Update[] result { get; set; }
    }
    [System.Runtime.Serialization.DataContract]
    public class Update
    {
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public long update_id { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public Message message { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public Message edited_message { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int inline_query { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int chosen_inline_result { get; set; }
    }
    [System.Runtime.Serialization.DataContract]
    public class Message
    {
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int message_id { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public User from { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int date { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int forward_date { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public Chat chat { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public Message reply_to_message { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int edit_date { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string text { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string caption { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string new_chat_title { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool delete_chat_photo { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool group_chat_created { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool supergroup_chat_created { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool channel_chat_created { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int migrate_to_chat_id { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int migrate_from_chat_id { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public Message pinned_message { get; set; }
    }

    [System.Runtime.Serialization.DataContract]
    public class User
    {
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string username { get; set; }
    }
    [System.Runtime.Serialization.DataContract]
    public class Chat
    {
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public long id { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string type { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string title { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string username { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string first_name { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string last_name { get; set; }
    }
    /// <summary>
    /// Use this method to send text messages.On success, the sent Message is returned.
    /// </summary>
    [System.Runtime.Serialization.DataContract(Name = "sendMessage")]
    public class SendMessage
    {
        /// <summary>
        /// Yes Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string chat_id { get; set; }
        /// <summary>
        ///  Text of the message to be sent
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string text { get; set; }
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public ReplyKeyboardMarkup reply_markup { get; set; }
    }
    [System.Runtime.Serialization.DataContract]
    public class ReplyKeyboardMarkup 
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of KeyboardButton objects
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public KeyboardButton[][] keyboard { get; set; }
        /// <summary>
        /// Optional.Requests clients to resize the keyboard vertically for optimal fit(e.g., make the keyboard smaller if there are just two rows of buttons). Defaults to false, in which case the custom keyboard is always of the same height as the app's standard keyboard.
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool resize_keyboard { get; set; }
        /// <summary>
        /// Optional.Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat – the user can press a special button in the input field to see the custom keyboard again. Defaults to false.
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool one_time_keyboard { get; set; }
        /// <summary>
        /// Optional.Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        //Example: A user requests to change the bot‘s language, bot replies to the request with a keyboard to select the new language.Other users in the group don’t see the keyboard.
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool selective { get; set; }
    }
    [System.Runtime.Serialization.DataContract]
    public class KeyboardButton
    {
        /// <summary>
        ///    Text of the button.If none of the optional fields are used, it will be sent to the bot as a message when the button is pressed
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public string text { get; set; }
        /// <summary>
        /// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool request_contact { get; set; }
        /// <summary>
        /// Optional.If True, the user's current location will be sent when the button is pressed. Available in private chats only
        /// </summary>
        [System.Runtime.Serialization.DataMember(EmitDefaultValue = false)]
        public bool request_location { get; set; }
    }
}
