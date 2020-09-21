using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using FastReport;
using FastReport.Data;
using FastReport.Dialog;
using FastReport.Barcode;
using FastReport.Table;
using FastReport.Utils;

namespace FastReport
{
    public class ReportScript
    {
        public FastReport.Report Report;
        public FastReport.Engine.ReportEngine Engine;
        public FastReport.DataBand Data1;
        public FastReport.DataBand Data2;
        public FastReport.ReportPage Page1;
        public FastReport.ReportPage Page2;
        public FastReport.PageFooterBand PageFooter1;
        public FastReport.PageHeaderBand PageHeader1;
        public FastReport.ReportTitleBand ReportTitle1;
        public FastReport.SubreportObject Subreport1;
        public FastReport.TextObject Text1;
        public FastReport.TextObject Text2;
        public FastReport.TextObject Text3;
        public FastReport.TextObject Text4;
        public FastReport.TextObject Text5;
        public FastReport.TextObject Text6;
        public FastReport.TextObject Text7;
        public FastReport.TextObject Text8;
        public FastReport.TextObject Text9;
        private object CalcExpression(string expression, Variant Value)
        {
            if (expression == "[اعيان.Code]=[مالکين اوليه اعيان.estUnitBuild.Code]")
                return ( 
                    
                    (Int32)Report.GetColumnValue("اعيان.Code")) == ((Int32)Report.GetColumnValue("مالکين اوليه اعيان.estUnitBuild.Code")
                    
                    );
            return null;
        }

        private System.SByte Abs(System.SByte value)
        {
            return System.Math.Abs(value);
        }

        private System.Int16 Abs(System.Int16 value)
        {
            return System.Math.Abs(value);
        }

        private System.Int32 Abs(System.Int32 value)
        {
            return System.Math.Abs(value);
        }

        private System.Int64 Abs(System.Int64 value)
        {
            return System.Math.Abs(value);
        }

        private System.Single Abs(System.Single value)
        {
            return System.Math.Abs(value);
        }

        private System.Double Abs(System.Double value)
        {
            return System.Math.Abs(value);
        }

        private System.Decimal Abs(System.Decimal value)
        {
            return System.Math.Abs(value);
        }

        private System.Double Acos(System.Double d)
        {
            return System.Math.Acos(d);
        }

        private System.Double Asin(System.Double d)
        {
            return System.Math.Asin(d);
        }

        private System.Double Atan(System.Double d)
        {
            return System.Math.Atan(d);
        }

        private System.Double Ceiling(System.Double a)
        {
            return System.Math.Ceiling(a);
        }

        private System.Decimal Ceiling(System.Decimal d)
        {
            return System.Math.Ceiling(d);
        }

        private System.Double Cos(System.Double d)
        {
            return System.Math.Cos(d);
        }

        private System.Double Exp(System.Double d)
        {
            return System.Math.Exp(d);
        }

        private System.Double Floor(System.Double d)
        {
            return System.Math.Floor(d);
        }

        private System.Decimal Floor(System.Decimal d)
        {
            return System.Math.Floor(d);
        }

        private System.Double Log(System.Double d)
        {
            return System.Math.Log(d);
        }

        private System.Int32 Maximum(System.Int32 val1, System.Int32 val2)
        {
            return FastReport.Functions.StdFunctions.Maximum(val1, val2);
        }

        private System.Int64 Maximum(System.Int64 val1, System.Int64 val2)
        {
            return FastReport.Functions.StdFunctions.Maximum(val1, val2);
        }

        private System.Single Maximum(System.Single val1, System.Single val2)
        {
            return FastReport.Functions.StdFunctions.Maximum(val1, val2);
        }

        private System.Double Maximum(System.Double val1, System.Double val2)
        {
            return FastReport.Functions.StdFunctions.Maximum(val1, val2);
        }

        private System.Decimal Maximum(System.Decimal val1, System.Decimal val2)
        {
            return FastReport.Functions.StdFunctions.Maximum(val1, val2);
        }

        private System.Int32 Minimum(System.Int32 val1, System.Int32 val2)
        {
            return FastReport.Functions.StdFunctions.Minimum(val1, val2);
        }

        private System.Int64 Minimum(System.Int64 val1, System.Int64 val2)
        {
            return FastReport.Functions.StdFunctions.Minimum(val1, val2);
        }

        private System.Single Minimum(System.Single val1, System.Single val2)
        {
            return FastReport.Functions.StdFunctions.Minimum(val1, val2);
        }

        private System.Double Minimum(System.Double val1, System.Double val2)
        {
            return FastReport.Functions.StdFunctions.Minimum(val1, val2);
        }

        private System.Decimal Minimum(System.Decimal val1, System.Decimal val2)
        {
            return FastReport.Functions.StdFunctions.Minimum(val1, val2);
        }

        private System.Double Round(System.Double a)
        {
            return System.Math.Round(a);
        }

        private System.Decimal Round(System.Decimal d)
        {
            return System.Math.Round(d);
        }

        private System.Double Round(System.Double value, System.Int32 digits)
        {
            return System.Math.Round(value, digits);
        }

        private System.Decimal Round(System.Decimal d, System.Int32 decimals)
        {
            return System.Math.Round(d, decimals);
        }

        private System.Double Sin(System.Double a)
        {
            return System.Math.Sin(a);
        }

        private System.Double Sqrt(System.Double d)
        {
            return System.Math.Sqrt(d);
        }

        private System.Double Tan(System.Double a)
        {
            return System.Math.Tan(a);
        }

        private System.Double Truncate(System.Double d)
        {
            return System.Math.Truncate(d);
        }

        private System.Decimal Truncate(System.Decimal d)
        {
            return System.Math.Truncate(d);
        }

        private System.Int32 Asc(System.Char c)
        {
            return FastReport.Functions.StdFunctions.Asc(c);
        }

        private System.Char Chr(System.Int32 i)
        {
            return FastReport.Functions.StdFunctions.Chr(i);
        }

        private System.String Insert(System.String s, System.Int32 startIndex, System.String value)
        {
            return FastReport.Functions.StdFunctions.Insert(s, startIndex, value);
        }

        private System.Int32 Length(System.String s)
        {
            return FastReport.Functions.StdFunctions.Length(s);
        }

        private System.String LowerCase(System.String s)
        {
            return FastReport.Functions.StdFunctions.LowerCase(s);
        }

        private System.String PadLeft(System.String s, System.Int32 totalWidth)
        {
            return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth);
        }

        private System.String PadLeft(System.String s, System.Int32 totalWidth, System.Char paddingChar)
        {
            return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth, paddingChar);
        }

        private System.String PadRight(System.String s, System.Int32 totalWidth)
        {
            return FastReport.Functions.StdFunctions.PadRight(s, totalWidth);
        }

        private System.String PadRight(System.String s, System.Int32 totalWidth, System.Char paddingChar)
        {
            return FastReport.Functions.StdFunctions.PadRight(s, totalWidth, paddingChar);
        }

        private System.String Remove(System.String s, System.Int32 startIndex)
        {
            return FastReport.Functions.StdFunctions.Remove(s, startIndex);
        }

        private System.String Remove(System.String s, System.Int32 startIndex, System.Int32 count)
        {
            return FastReport.Functions.StdFunctions.Remove(s, startIndex, count);
        }

        private System.String Replace(System.String s, System.String oldValue, System.String newValue)
        {
            return FastReport.Functions.StdFunctions.Replace(s, oldValue, newValue);
        }

        private System.String Substring(System.String s, System.Int32 startIndex)
        {
            return FastReport.Functions.StdFunctions.Substring(s, startIndex);
        }

        private System.String Substring(System.String s, System.Int32 startIndex, System.Int32 length)
        {
            return FastReport.Functions.StdFunctions.Substring(s, startIndex, length);
        }

        private System.String TitleCase(System.String s)
        {
            return FastReport.Functions.StdFunctions.TitleCase(s);
        }

        private System.String Trim(System.String s)
        {
            return FastReport.Functions.StdFunctions.Trim(s);
        }

        private System.String UpperCase(System.String s)
        {
            return FastReport.Functions.StdFunctions.UpperCase(s);
        }

        private System.DateTime AddDays(System.DateTime date, System.Double value)
        {
            return FastReport.Functions.StdFunctions.AddDays(date, value);
        }

        private System.DateTime AddHours(System.DateTime date, System.Double value)
        {
            return FastReport.Functions.StdFunctions.AddHours(date, value);
        }

        private System.DateTime AddMinutes(System.DateTime date, System.Double value)
        {
            return FastReport.Functions.StdFunctions.AddMinutes(date, value);
        }

        private System.DateTime AddMonths(System.DateTime date, System.Int32 value)
        {
            return FastReport.Functions.StdFunctions.AddMonths(date, value);
        }

        private System.DateTime AddSeconds(System.DateTime date, System.Double value)
        {
            return FastReport.Functions.StdFunctions.AddSeconds(date, value);
        }

        private System.DateTime AddYears(System.DateTime date, System.Int32 value)
        {
            return FastReport.Functions.StdFunctions.AddYears(date, value);
        }

        private System.TimeSpan DateDiff(System.DateTime date1, System.DateTime date2)
        {
            return FastReport.Functions.StdFunctions.DateDiff(date1, date2);
        }

        private System.DateTime DateSerial(System.Int32 year, System.Int32 month, System.Int32 day)
        {
            return FastReport.Functions.StdFunctions.DateSerial(year, month, day);
        }

        private System.Int32 Day(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.Day(date);
        }

        private System.String DayOfWeek(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.DayOfWeek(date);
        }

        private System.Int32 DayOfYear(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.DayOfYear(date);
        }

        private System.Int32 DaysInMonth(System.Int32 year, System.Int32 month)
        {
            return FastReport.Functions.StdFunctions.DaysInMonth(year, month);
        }

        private System.Int32 Hour(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.Hour(date);
        }

        private System.Int32 Minute(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.Minute(date);
        }

        private System.Int32 Month(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.Month(date);
        }

        private System.String MonthName(System.Int32 month)
        {
            return FastReport.Functions.StdFunctions.MonthName(month);
        }

        private System.Int32 Second(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.Second(date);
        }

        private System.Int32 Year(System.DateTime date)
        {
            return FastReport.Functions.StdFunctions.Year(date);
        }

        private System.String Format(System.String format, params System.Object[] args)
        {
            return FastReport.Functions.StdFunctions.Format(format, args);
        }

        private System.String FormatCurrency(System.Object value)
        {
            return FastReport.Functions.StdFunctions.FormatCurrency(value);
        }

        private System.String FormatCurrency(System.Object value, System.Int32 decimalDigits)
        {
            return FastReport.Functions.StdFunctions.FormatCurrency(value, decimalDigits);
        }

        private System.String FormatDateTime(System.DateTime value)
        {
            return FastReport.Functions.StdFunctions.FormatDateTime(value);
        }

        private System.String FormatDateTime(System.DateTime value, System.String format)
        {
            return FastReport.Functions.StdFunctions.FormatDateTime(value, format);
        }

        private System.String FormatNumber(System.Object value)
        {
            return FastReport.Functions.StdFunctions.FormatNumber(value);
        }

        private System.String FormatNumber(System.Object value, System.Int32 decimalDigits)
        {
            return FastReport.Functions.StdFunctions.FormatNumber(value, decimalDigits);
        }

        private System.String FormatPercent(System.Object value)
        {
            return FastReport.Functions.StdFunctions.FormatPercent(value);
        }

        private System.String FormatPercent(System.Object value, System.Int32 decimalDigits)
        {
            return FastReport.Functions.StdFunctions.FormatPercent(value, decimalDigits);
        }

        private System.Boolean ToBoolean(System.Object value)
        {
            return System.Convert.ToBoolean(value);
        }

        private System.Byte ToByte(System.Object value)
        {
            return System.Convert.ToByte(value);
        }

        private System.Char ToChar(System.Object value)
        {
            return System.Convert.ToChar(value);
        }

        private System.DateTime ToDateTime(System.Object value)
        {
            return System.Convert.ToDateTime(value);
        }

        private System.Decimal ToDecimal(System.Object value)
        {
            return System.Convert.ToDecimal(value);
        }

        private System.Double ToDouble(System.Object value)
        {
            return System.Convert.ToDouble(value);
        }

        private System.Int32 ToInt32(System.Object value)
        {
            return System.Convert.ToInt32(value);
        }

        private System.String ToRoman(System.Object value)
        {
            return FastReport.Functions.StdFunctions.ToRoman(value);
        }

        private System.Single ToSingle(System.Object value)
        {
            return System.Convert.ToSingle(value);
        }

        private System.String ToString(System.Object value)
        {
            return System.Convert.ToString(value);
        }

        private System.String ToWords(System.Object value)
        {
            return FastReport.Functions.StdFunctions.ToWords(value);
        }

        private System.String ToWords(System.Object value, System.String currencyName)
        {
            return FastReport.Functions.StdFunctions.ToWords(value, currencyName);
        }

        private System.String ToWords(System.Object value, System.String one, System.String many)
        {
            return FastReport.Functions.StdFunctions.ToWords(value, one, many);
        }

        private System.String ToWordsEnGb(System.Object value)
        {
            return FastReport.Functions.StdFunctions.ToWordsEnGb(value);
        }

        private System.String ToWordsEnGb(System.Object value, System.String currencyName)
        {
            return FastReport.Functions.StdFunctions.ToWordsEnGb(value, currencyName);
        }

        private System.String ToWordsEnGb(System.Object value, System.String one, System.String many)
        {
            return FastReport.Functions.StdFunctions.ToWordsEnGb(value, one, many);
        }

        private System.String ToWordsRu(System.Object value)
        {
            return FastReport.Functions.StdFunctions.ToWordsRu(value);
        }

        private System.String ToWordsRu(System.Object value, System.String currencyName)
        {
            return FastReport.Functions.StdFunctions.ToWordsRu(value, currencyName);
        }

        private System.String ToWordsRu(System.Object value, System.Boolean male, System.String one, System.String two, System.String many)
        {
            return FastReport.Functions.StdFunctions.ToWordsRu(value, male, one, two, many);
        }

        private System.Object Choose(System.Double index, params System.Object[] choice)
        {
            return FastReport.Functions.StdFunctions.Choose(index, choice);
        }

        private System.Object IIf(System.Boolean expression, System.Object truePart, System.Object falsePart)
        {
            return FastReport.Functions.StdFunctions.IIf(expression, truePart, falsePart);
        }

        private System.Object Switch(params System.Object[] expressions)
        {
            return FastReport.Functions.StdFunctions.Switch(expressions);
        }

    }
}