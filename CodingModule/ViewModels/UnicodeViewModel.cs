using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace CodingModule.ViewModels
{
    public class UnicodeViewModel : BindableBase
    {
        private string utf8Template = "&#X四个数字;(二字节 十六进制形式)";

        public string Utf8Template
        {
            get => utf8Template; set => utf8Template = value;
        }

        private string chineseCode;

        public string ChineseCode
        {
            get { return chineseCode; }
            set { SetProperty(ref chineseCode, value); }
        }

        private string unicodeCodingCode;


        public string UnicodeCode
        {
            get { return unicodeCodingCode; }
            set { SetProperty(ref unicodeCodingCode, value); }
        }

        public DelegateCommand ClearCodeCommand { get; set; }


        public DelegateCommand Chinese2UnicodeCodingCommand { get; set; }

        public DelegateCommand Unicode2ChineseCondingCommand { get; set; }

        public UnicodeViewModel()
        {
            Chinese2UnicodeCodingCommand = new DelegateCommand(chineseToUnicodeCoding);
            Unicode2ChineseCondingCommand = new DelegateCommand(unicodeToChineseCoding);
            ClearCodeCommand = new DelegateCommand(clearCode);
        }

        /// <summary>
        /// 支持UTF-8 或者Unicode转中文
        /// </summary>
        private void unicodeToChineseCoding()
        {
            // \u1234
            if (UnicodeCode.StartsWith(@"\u", StringComparison.OrdinalIgnoreCase))
            {
                string[] codes = UnicodeCode.StartsWith(@"\u") ? UnicodeCode.Split(@"\u") : UnicodeCode.Split(@"\U");
                List<byte> bytes = new List<byte>();
                for (int i = 0; i < codes.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(codes[i])) continue;
                    string s = codes[i];
                    byte high = Convert.ToByte(s.Substring(0, 2), 16);
                    byte low = Convert.ToByte(s.Substring(2, 2), 16);
                    bytes.Add(low);
                    bytes.Add(high);
                }
                byte[] arr = bytes.ToArray();
                string result = Encoding.Unicode.GetString(arr);
                ChineseCode = result;
            }
            // &#x1234
            else
            {
                string[] codes = UnicodeCode.Split(';');
                List<byte> bytes = new List<byte>();
                for (int i = 0; i < codes.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(codes[i])) continue;
                    string s = codes[i].Substring(3, 4);
                    byte high = Convert.ToByte(s.Substring(0, 2), 16);
                    byte low = Convert.ToByte(s.Substring(2, 2), 16);
                    bytes.Add(low);
                    bytes.Add(high);
                }
                byte[] arr = bytes.ToArray();
                string result = Encoding.Unicode.GetString(arr);
                ChineseCode = result;
            }


        }

        private void clearCode()
        {
            ChineseCode = string.Empty;
            UnicodeCode = string.Empty;
        }

        private void chineseToUnicodeCoding()
        {
            // 字节数组表示unicode需要这种格式  转字节数组固定是2位 首位是低位   
            string prefix = "&#X{0}{1};";
            byte[] bytes = Encoding.Unicode.GetBytes(ChineseCode);
            // 将字节数组转换为Unicode字符串
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length - 1; i += 2)
            {
                byte low = bytes[i];
                byte high = bytes[i + 1];
                string code = string.Format(prefix, $"{high:X2}", $"{low:X2}");
                sb.Append(code);
            }
            UnicodeCode = sb.ToString();
        }
    }
}
