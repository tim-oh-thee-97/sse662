using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SSE662_Proj1.ViewModels
{
    public class MainViewModel : AbstractViewModel
    {
        public MainViewModel()
        {

        }

        #region Properties

        string _input;
        public string Input
        {
            get => _input;
            set => SetValue(ref _input, value);
        }

        string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set => SetValue(ref _errorText, value);
        }

        string _strOutput;
        public string StrOutput
        {
            get => _strOutput;
            set => SetValue(ref _strOutput, value);
        }

        string _romanOutput;
        public string RomanOutput
        {
            get => _romanOutput;
            set => SetValue(ref _romanOutput, value);
        }

        string _decOutput;
        public string DecOutput
        {
            get => _decOutput;
            set => SetValue(ref _decOutput, value);
        }

        string _hexOutput;
        public string HexOutput
        {
            get => _hexOutput;
            set => SetValue(ref _hexOutput, value);
        }

        string _binOutput;
        public string BinOutput
        {
            get => _binOutput;
            set => SetValue(ref _binOutput, value);
        }

        #endregion

        #region Commands

        public bool CanSubmit => Input != null;

        RelayCommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if(_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(param => Submit(),
                        param => CanSubmit);
                }
                return _submitCommand;
            }
        }

        #endregion

        #region Command Implementations

        private void Submit()
        {
            Regex binary = new Regex("^[01]{1,32}$");
            Regex hex = new Regex("^[0123456789ABCDEF]{1,8}$");
            Regex roman = new Regex("^[IVXLCDM]{1,15}$");
            int num;
            if (Int32.TryParse(Input, out num))
            {
                ErrorText = null;
                StrOutput = NumToString(num);
                BinOutput = "0b" + Convert.ToString(num, 2);
                DecOutput = num.ToString();
                HexOutput = "0x" + Convert.ToString(num, 16).ToUpper();
            }
            else
            {
                //Check if input matches expected string of a number
                ErrorText = "Invalid Input.";
            }
        }

        #endregion

        #region Functions

        private readonly string[] underTwenty = {
            "",    //0
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        private readonly string[] teens = {
            "",    //0
            "",    //10
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        private readonly Dictionary<int, string> Suffixes = new Dictionary<int, string> {
            {1000, "thousand" },
            {1000000, "million" },
            {1000000000, "billion" },
        };

        private string NumToString(int num)
        {
            if (num == 0)
                return "zero";
            else if (num < 0)
                return "Negative " + NumToString(-num);
            else if (num < 20)
                return underTwenty[num];
            else if (num < 100)
                return teens[num / 10] + (num % 10 == 0 ? "" : "-") + underTwenty[num % 10];
            else if (num < 1000)
                return underTwenty[num / 100] + " hundred" + (num % 100 == 0 ? "" : " ") + NumToString(num % 100);
            else if (num < Int32.MaxValue)
            {
                for (int i = 1000; i < Int32.MaxValue; i *= 1000)
                {
                    if (num < i * 1000)
                        return NumToString(num / i) + " " + Suffixes[i] + (num % i == 0 ? "" : " ") + NumToString(num % i);
                }
                return "ERROR: Unexpected error.";
            }
            else
                return "ERROR: Number too large";
        }

        #endregion
    }
}
