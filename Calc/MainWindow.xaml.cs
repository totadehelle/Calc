using Calc;
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
        readonly CalculationModel _calculationModel;
        public MainWindow()
        {
            InitializeComponent();
            _calculationModel = new CalculationModel();

        }

        


        public void ChangeTextInTextbox()
        {
        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        #region SYMBOL_BUTTONS

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddZero();

            /*if (CalculationModel.OperationToDo == CalculationModel.Operation.Divide)
            {
                textBox.Text = "Нельзя делить на ноль";
                CalculationModel.OperationToDo = CalculationModel.Operation.NoOperation;
                StoredNumber = 0;
            }

            else textBox.Text = CalculationModel.AddFigureFrom1To9((Button)sender, textBox.Text);*/
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button) sender).Content.ToString());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void butto8_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddFigureFrom1To9(((Button)sender).Content.ToString());
        }

        private void buttonDot_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.AddPoint();
        }



        #endregion

        #region NON_ARITHMETIC_OPERATION_BUTTONS
        private void buttonDelete_Click()
        {
            _calculationModel.RemoveLastSymbol();
        }
        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.ClearAll();
        }
        #endregion

        #region ARITHMETIC_OPERATION_BUTTONS
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.Add();
        }

        private void buttonDeduct_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.Deduct();
        }

        private void buttonMuliply_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.Multiplicate();
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            _calculationModel.Divide();
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (CalculationModel.OperationToDo != CalculationModel.Operation.NoOperation)
            {
                decimal result = 0;
                switch (CalculationModel.OperationToDo)
                {
                    case CalculationModel.Operation.Add:
                        result = CalculationModel.Add(StoredNumber, CurrentNumber);
                        break;

                    case CalculationModel.Operation.Deduct:
                        result = CalculationModel.Deduct(StoredNumber, CurrentNumber);
                        break;

                    case CalculationModel.Operation.Multiply:
                        result = CalculationModel.Multiplicate(StoredNumber, CurrentNumber);
                        break;

                        // отсутствует логика для деления на ноль! result в этом случае будет 0
                    case CalculationModel.Operation.Divide:
                        result = CalculationModel.Divide(StoredNumber, CurrentNumber);
                        break;
                }

                CalculationModel.OperationToDo = CalculationModel.Operation.NoOperation;
                textBox.Text = result.ToString(CultureInfo.InvariantCulture);
            }
        }
        #endregion
    }
}
