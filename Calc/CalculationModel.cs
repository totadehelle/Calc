using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calc
{
    public class CalculationModel
    {
        public event Action<string> TextIsChangedEvent;

        private string _text;
        public string Text {
            set
            {
                _text = value;
                TextIsChangedEvent(_text);
            }
            get { return _text; }
        }

        public enum Operation { NoOperation, Add, Deduct, Multiply, Divide }
        public static Operation OperationToDo = Operation.NoOperation;
        public bool AriphmeticButtonPressedPreviously = false;

        public decimal StoredNumber;
        public decimal CurrentNumber => Decimal.Parse(Text, 
            NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);


        /*private string Text
        {
            set
            {
                _text = value;
                TextIsChangedEvent(_text);
            }
            get { return _text; }
        }*/

        //public void OnNumberInput(int i)
        // {
        //     Text += i.ToString();
        // }


        //reads the text from the button and returns it, for ex., "9" for button 9
        public void AddFigureFrom1To9(string figure)
        {
            if (Text == "0" 
                || AriphmeticButtonPressedPreviously
                || Text.Contains("H") // "Нельзя делить на ноль"
               )
            {
                Text = figure;
            }

            if (Text != "0"
                && !AriphmeticButtonPressedPreviously
                && !Text.Contains("H"))
            {
                Text += figure;
            }
        }

        public void AddZero()
        {
            if (!Text.Contains("H")
                && !Text.Equals("0")
                && !AriphmeticButtonPressedPreviously)
            {
                Text += "0";
            }

            if (Text.Contains("H")
                || AriphmeticButtonPressedPreviously)
            {
                Text = "0";
            }
        }

        public void AddPoint()
        {
            if (!Text.Contains("H") 
                && !Text.Contains(".") 
                && !AriphmeticButtonPressedPreviously)
            {
                Text += ".";
            }
        }

        public void Add()
        {
            StoredNumber = CurrentNumber;
            CalculationModel.OperationToDo = CalculationModel.Operation.Add;
        }

        public decimal Deduct(decimal a, decimal b)
        {
            return a-b;
        }

        public decimal Multiplicate(decimal a, decimal b)
        {
            return a*b;
        }

        public decimal Divide(decimal a, decimal b)
        {
            return a / b;
        }

        public void Calculate()
        {
            if (OperationToDo != Operation.NoOperation)
            {
                decimal result = 0;
                switch (OperationToDo)
                {
                    case Operation.Add:
                        result = StoredNumber + CurrentNumber;
                        break;

                    case Operation.Deduct:
                        result = StoredNumber - CurrentNumber;
                        break;

                    case Operation.Multiply:
                        result = StoredNumber * CurrentNumber;
                        break;

                    // отсутствует логика для деления на ноль! result в этом случае будет 0
                    case Operation.Divide:
                        result = StoredNumber / CurrentNumber;
                        break;
                }

                OperationToDo = Operation.NoOperation;
                Text = result.ToString();
            }
    }
}
