using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SSE662_Proj1.ViewModels
{
    class MainViewModel : AbstractViewModel
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
            get => _decOutput;
            set => SetValue(ref _hexOutput, value);
        }

        string _binOutput;
        public string BinOutput
        {
            get => _decOutput;
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
            //long num = -1;
            //if(Int64.TryParse(Input, out num))
            //{
            //    ErrorText = null;
            //    BinOutput = Convert.ToString(num, 2);
            //    DecOutput = num.ToString();
            //}
            //else
            //{
            //    //Check if input matches expected string of a number
            //    ErrorText = "This is an error.";
            //}
        }

        #endregion
    }
}
