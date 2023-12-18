using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodingModule.ViewModels
{
    public class UrlCodingViewModel : BindableBase
    {

        private string _urlCode;

        public string UrlCode
        {
            get { return _urlCode; }
            set { SetProperty(ref _urlCode, value); }
        }

        private string _urlCodingCode;

        public string UrlCodingCode
        {
            get { return _urlCodingCode; }
            set { SetProperty(ref _urlCodingCode, value); }
        }

        public DelegateCommand UrlEnCodingCommand { get; set; }

        public DelegateCommand UrlDeCodingCommand { get; set; }

        public DelegateCommand ClearCodeCommand { get; set; }

        public UrlCodingViewModel()
        {
            UrlEnCodingCommand = new DelegateCommand(UrlEncoding);
            UrlDeCodingCommand = new DelegateCommand(UrlDeCoding);
            ClearCodeCommand = new DelegateCommand(ClearCode);
        }

        private void ClearCode()
        {
            UrlCode = string.Empty;
            UrlCodingCode = string.Empty;
        }

        /// <summary>
        /// url解码
        /// </summary>
        private void UrlDeCoding()
        {
            string decodedString = WebUtility.UrlDecode(UrlCodingCode);
            UrlCode = decodedString;
        }

        /// <summary>
        /// url编码
        /// </summary>
        private void UrlEncoding()
        {
            // WebUtility.UrlEncode(UrlCode) 空格转换成"+"
            // Uri.EscapeDataString 空格转换成"%20"
            string encodedString = Uri.EscapeDataString(UrlCode);
            UrlCodingCode = encodedString;
        }
    }
}
