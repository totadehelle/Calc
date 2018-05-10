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

        private string _text = "0";

        public string Text
        {
            set
            {
                _text = value;
                TextIsChangedEvent?.Invoke(_text);
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
        public bool AriphmeticButtonIsPressed = false;

        public decimal StoredNumber;

        //Добавить возможность вводить отрицательное число
        public decimal CurrentNumber => Decimal.Parse(Text,
            NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
 
        public void ClearAll()
        {
            Text = "0";
            OperationToDo = Operation.NoOperation;
            AriphmeticButtonIsPressed = false;
            StoredNumber = 0;
        }

        public void RemoveLastSymbol()
        {
            if (Text != "0" && !Text.Contains("Н") && !AriphmeticButtonIsPressed)
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
                || AriphmeticButtonIsPressed
                || Text.Contains("H") // "Нельзя делить на ноль"
            )
            {
                Text = figure;
            }

            else Text += figure;

            AriphmeticButtonIsPressed = false;
        }

        public void AddZero()
        {
            if (!Text.Contains("H")
                && !Text.Equals("0")
                && !AriphmeticButtonIsPressed)
            {
                Text += "0";
            }

            else Text = "0";

            AriphmeticButtonIsPressed = false;
        }

        public void AddPoint()
        {
            if (!Text.Contains("H")
                && !Text.Contains(".")
                && !AriphmeticButtonIsPressed)
            {
                Text += ".";
            }

            AriphmeticButtonIsPressed = false;
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
                AriphmeticButtonIsPressed = true;
            }
            else
            {
                if (!AriphmeticButtonIsPressed)
                {
                    Calculate();
                    if (!Text.Contains("Н"))
                    {
                        StoredNumber = CurrentNumber;
                        AriphmeticButtonIsPressed = true;
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
                            OperationToDo = Operation.NoOperation;
                            return;
                        }

                        
                        break;
                }

                OperationToDo = Operation.NoOperation;
                Text = result.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
