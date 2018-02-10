using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calc
{
    public static class Operator
    {
        //reads the text from the button and returns it, for ex., "9" for button 9
        public static string AddSymbolToTextBox(Button button, string text)

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
