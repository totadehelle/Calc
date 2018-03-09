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

        public string Text
        {
            set
            {
                _text = value;
                TextIsChangedEvent(_text);
            }
            get { return _text; }
        }

        public enum Operation
        {
            NoOperation,
            Add,
            Deduct,
            Multiply,
            Divide
        }

        public static Operation OperationToDo = Operation.NoOperation;
        public bool AriphmeticButtonPressedPreviously = false;

        public decimal StoredNumber;

        //Добавить возможность вводить отрицательное число
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


        
        public void ClearAll()
        {
            Text = "0";
            OperationToDo = Operation.NoOperation;
            AriphmeticButtonPressedPreviously = false;
            StoredNumber = 0;
        }

        public void RemoveLastSymbol()
        {
            if (Text != "0" && !Text.Contains("Н") && !AriphmeticButtonPressedPreviously)
            {
                Text = Text.Remove(Text.Length - 1);
                if (Text == "")
                {
                    Text = "0";
                }
            }
        }

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
                && !Text.Contains("H")) // "Нельзя делить на ноль"
            {
                Text += figure;
            }

            AriphmeticButtonPressedPreviously = false;
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

            AriphmeticButtonPressedPreviously = false;
        }

        public void AddPoint()
        {
            if (!Text.Contains("H")
                && !Text.Contains(".")
                && !AriphmeticButtonPressedPreviously)
            {
                Text += ".";
            }

            AriphmeticButtonPressedPreviously = false;
        }

        public void Add()
        {
            ArithmeticOperationCommonActions();
            OperationToDo = Operation.Add;
        }

        public void Deduct()
        {
            ArithmeticOperationCommonActions();
            OperationToDo = Operation.Deduct;
        }

        public void Multiplicate()
        {
            ArithmeticOperationCommonActions();
            OperationToDo = Operation.Multiply;
        }

        public void Divide()
        {
            ArithmeticOperationCommonActions();
            OperationToDo = Operation.Divide;
        }

        private void ArithmeticOperationCommonActions()
        {
            if (OperationToDo == Operation.NoOperation)
            {
                StoredNumber = CurrentNumber;
                AriphmeticButtonPressedPreviously = true;
            }
            else
            {
                if (!AriphmeticButtonPressedPreviously)
                {
                    Calculate();
                    if (!Text.Contains("Н"))
                    {
                        StoredNumber = CurrentNumber;
                        AriphmeticButtonPressedPreviously = true;
                    }
                }
            }
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
                        try
                        {
                            result = StoredNumber / CurrentNumber;
                        }
                        catch (DivideByZeroException)
                        {
                            Text = "Нельзя делить на ноль";
                        }

                        
                        break;
                }

                OperationToDo = Operation.NoOperation;
                Text = result.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
