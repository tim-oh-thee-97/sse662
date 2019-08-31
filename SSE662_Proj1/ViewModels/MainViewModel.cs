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
            ErrorText = null;
            Regex binary = new Regex("^0b[01]{1,32}$");
            Regex hex = new Regex("^0x[0123456789ABCDEF]{1,8}$");
            Regex roman = new Regex("^[IVXLCDM]{1,15}$");
            int num;
            if(binary.IsMatch(Input))
            {
                num = Convert.ToInt32(Input.Substring(2), 2);
                StrOutput = IntToString(num);
                RomanOutput = IntToRoman(num);
                BinOutput = Input;
                DecOutput = Convert.ToString(num, 10);
                HexOutput = "0x" + Convert.ToString(num, 16).ToUpper();
            }
            else if (hex.IsMatch(Input.Substring(0,2) + Input.Substring(2).ToUpper()))
            {
                num = Convert.ToInt32(Input.Substring(2), 16);
                StrOutput = IntToString(num);
                RomanOutput = IntToRoman(num);
                BinOutput = "0b" + Convert.ToString(num, 2);
                DecOutput = Convert.ToString(num, 10);
                HexOutput = Input.Substring(0, 2) + Input.Substring(2).ToUpper();
            }
            else if (Int32.TryParse(Input, out num))
            {
                StrOutput = IntToString(num);
                RomanOutput = IntToRoman(num);
                BinOutput = "0b" + Convert.ToString(num, 2);
                DecOutput = Input;
                HexOutput = "0x" + Convert.ToString(num, 16).ToUpper();
            }
            else
            {
                //Try to parse string as number input
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

        private string IntToString(int num)
        {
            if (num == 0)
                return "zero";
            else if (num < 0)
                return "negative " + IntToString(-num);
            else if (num < 20)
                return underTwenty[num];
            else if (num < 100)
                return teens[num / 10] + (num % 10 == 0 ? "" : "-" + underTwenty[num % 10]);
            else if (num < 1000)
                return underTwenty[num / 100] + " hundred" + (num % 100 == 0 ? "" : " " + IntToString(num % 100));
            else if (num <= Int32.MaxValue)
            {
                for (long i = 1000; i < Int32.MaxValue && i > 0; i *= 1000)
                {
                    if (num < i * 1000)
                        return IntToString(num / (int)i) + " " + Suffixes[(int)i] + (num % i == 0 ? "" : " " + IntToString(num % (int)i));
                }
                return "ERROR: Unexpected error.";
            }
            else
                return "ERROR: Number too large";
        }

        private string IntToRoman(int num)
        {
            
            if (num > 60000 || num < -60000)
                return "Number too large.";
            else if (num < 0)
                return "-" + IntToRoman(-num);
            else if (num == 0)
                return String.Empty;
            else if (num >= 1000)
                return "M" + IntToRoman(num - 1000);
            else if (num >= 900)
                return "CM" + IntToRoman(num - 900);
            else if (num >= 500)
                return "D" + IntToRoman(num - 500);
            else if (num >= 400)
                return "CD" + IntToRoman(num - 400);
            else if (num >= 100)
                return "C" + IntToRoman(num - 100);
            else if (num >= 90)
                return "XC" + IntToRoman(num - 90);
            else if (num >= 50)
                return "L" + IntToRoman(num - 50);
            else if (num >= 40)
                return "XL" + IntToRoman(num - 40);
            else if (num >= 10)
                return "X" + IntToRoman(num - 10);
            else if (num >= 9)
                return "IX" + IntToRoman(num - 9);
            else if (num >= 5)
                return "V" + IntToRoman(num - 5);
            else if (num >= 4)
                return "IV" + IntToRoman(num - 4);
            else if (num >= 1)
                return "I" + IntToRoman(num - 1);
            else return "ERROR: Unexpected error.";
        }

        #endregion
    }
}
