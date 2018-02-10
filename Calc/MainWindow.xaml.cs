using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public decimal StoredNumber;
        public decimal CurrentNumber { get { return Decimal.Parse(textBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture); } }
        public enum Operation {NoOperation, Add, Deduct, Multiply, Divide}
        public static Operation OperationToDo = Operation.NoOperation;
        
        public MainWindow()
        {
            InitializeComponent();
            //CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        #region SYMBOL_BUTTONS

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            if (OperationToDo == Operation.Divide)
            {
                textBox.Text = "Нельзя делить на ноль";
                OperationToDo = Operation.NoOperation;
                StoredNumber = 0;
            }

            else textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void butto8_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }

        private void buttonDot_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Operator.AddSymbolToTextBox((Button)sender, textBox.Text);
        }



        #endregion

        #region NON_ARITHMETIC_OPERATION_BUTTONS
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "0")
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                if (textBox.Text == "")
                {
                    textBox.Text = "0";
                }
            }

        }
        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
            OperationToDo = Operation.NoOperation;
        }
        #endregion

        #region ARITHMETIC_OPERATION_BUTTONS
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!textBox.Text.Contains("Н")) // "Нельзя делить на ноль"
            {
                StoredNumber = CurrentNumber;
                OperationToDo = Operation.Add;
            }
        }

        private void buttonDeduct_Click(object sender, RoutedEventArgs e)
        {
            if (!textBox.Text.Contains("Н")) // "Нельзя делить на ноль"
            {
                StoredNumber = CurrentNumber;
                OperationToDo = Operation.Deduct;
            }
        }

        private void buttonMuliply_Click(object sender, RoutedEventArgs e)
        {
            if (!textBox.Text.Contains("Н")) // "Нельзя делить на ноль"
            {
                StoredNumber = CurrentNumber;
                OperationToDo = Operation.Multiply;
            }
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            if (!textBox.Text.Contains("Н")) // "Нельзя делить на ноль"
            {
                StoredNumber = CurrentNumber;
                OperationToDo = Operation.Divide;
            }
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (OperationToDo != Operation.NoOperation)
            {
                decimal result = 0;
                switch (OperationToDo)
                {
                    case Operation.Add:
                        result = Operator.Add(StoredNumber, CurrentNumber);
                        break;

                    case Operation.Deduct:
                        result = Operator.Deduct(StoredNumber, CurrentNumber);
                        break;

                    case Operation.Multiply:
                        result = Operator.Multiplicate(StoredNumber, CurrentNumber);
                        break;

                        // отсутствует логика для деления на ноль! result в этом случае будет 0
                    case Operation.Divide:
                        result = Operator.Divide(StoredNumber, CurrentNumber);
                        break;
                }
                OperationToDo = Operation.NoOperation;
                textBox.Text = result.ToString(CultureInfo.InvariantCulture);
            }
        }
        #endregion
    }
}
