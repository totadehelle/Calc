using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calc
{
    public class CalculationModel
    {
        /*public string Text { get;
            set { }
        }
        void GetText*/

        public event Action<string> TextChangedEvent;
        private string _text;

        private string Text
        {
            set
            {
                _text = value;
                TextChangedEvent();
            }
            get { return _text; }
        }

        public void OnNumberInput(int i)
        {
            Text += i.ToString();
        }
    }

    //reads the text from the button and returns it, for ex., "9" for button 9
    public string AddFigureFrom1To9(Button button, string text)

        

        {
            if ((text == "0" 
                 || text != "0" && MainWindow.OperationToDo != MainWindow.Operation.NoOperation
                 || text.Contains("H")) // "Нельзя делить на ноль"
                && button.Content.ToString() != ".")
            {
                return button.Content.ToString();
            }

            if (button.Content.ToString() == "." && !text.Contains(".") 
                                                 && !text.Contains("Н") // "Нельзя делить на ноль"
                || text != "0" && MainWindow.OperationToDo == MainWindow.Operation.NoOperation 
                               && button.Content.ToString() != ".")
            {
                return text + button.Content;
            }

            return text;
        }

        public string AddZero(string text)
        {
        }

        public string AddDot(string text)
        {
        }

        public static decimal Add(decimal a, decimal b)
        {
            return a+b;
        }

        public static decimal Deduct(decimal a, decimal b)
        {
            return a-b;
        }

        public static decimal Multiplicate(decimal a, decimal b)
        {
            return a*b;
        }

        public static decimal Divide(decimal a, decimal b)
        {
            return a / b;
        }

        
    }
}
