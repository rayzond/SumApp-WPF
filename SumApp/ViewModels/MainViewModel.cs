using Calculator;
using SumApp.MVVMPatterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SumApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Constants

        private const string RESULT_MESSAGE_SUCCESS = "{0}";
        private const string RESULT_MESSAGE_INVALID_INPUT = "Invalid numbers.";
        private const string ERROR_OCCURED = "Arithmetic operation failure.";

        #endregion

        #region Members

        private string _number1;
        private string _number2;
        private string _result;

        private readonly CalculatorService _calculator;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            _calculator = new CalculatorService();
            AddCommand = new RelayCommand(addNumber);
        }

        #endregion

        #region Properties

        public string Number1
        {
            get => _number1;
            set { _number1 = value; OnPropertyChanged(); }
        }

        public string Number2
        {
            get => _number2;
            set { _number2 = value; OnPropertyChanged(); }
        }

        public string Result
        {
            get => _result;
            set { _result = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Try to add numbers one and two together if they are valid and display the result if succeeded.
        /// </summary>
        private void addNumber()
        {
            if (double.TryParse(Number1, out var a) && double.TryParse(Number2, out var b))
            {
                double sum = _calculator.Add(a, b);
                Result = string.Format(RESULT_MESSAGE_SUCCESS, sum);
            }
            else
            {
                Result = RESULT_MESSAGE_INVALID_INPUT;
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
