using System.Globalization;
using System.Windows.Forms;
using Xceed.Document.NET;


namespace LumoForm 
{ 
    public class TextFormat
    {
        public Formatting FTimes8b = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 8D,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes8B = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 8D,
            Bold = true,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FArial8I = new Formatting
        {
            FontFamily = new Font("Arial Narrow"),
            Size = 8D,
            Italic = true,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes10b = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 10D,
            Bold = false,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes12B = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 12D,
            Bold = true,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes12b = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 12D,
            Bold = false,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes12BS = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 12D,
            Bold = true,
            UnderlineStyle = UnderlineStyle.singleLine,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes14bS = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 14D,
            Bold = false,
            UnderlineStyle = UnderlineStyle.singleLine,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes14b = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 14D,
            Bold = false,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes16BS = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 16D,
            Bold = true,
            UnderlineStyle = UnderlineStyle.singleLine,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FTimes16B = new Formatting
        {
            FontFamily = new Font("Times New Roman"),
            Size = 16D,
            Bold = true,
            Language = new CultureInfo("pt-BR")
        };

        public Formatting FArialBlack12b = new Formatting
        {
            FontFamily = new Font("Arial Black"),
            Size = 12D,
            Bold = false,
            Language = new CultureInfo("pt-BR")
        };
    }
}
