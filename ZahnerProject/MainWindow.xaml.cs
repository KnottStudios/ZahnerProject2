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

namespace ZahnerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string instructions = "Input two numbers that are at least 20 digits apart between - 10000 and 10000.";
        public MainWindow()
        {
            InitializeComponent();
            ZahnerXandY numbersXY = new ZahnerXandY();
            this.DataContext = numbersXY;
            lblAnswer.Text = instructions;
            
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e) {
            RootElement.BindingGroup.CommitEdit();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            RootElement.BindingGroup.CommitEdit();
            if ((bool)RootElement.GetValue(Validation.HasErrorProperty)) {
                return;
            }
            if (!(tbNumX.Text != "" && tbNumY.Text != ""))
            {
                MessageBox.Show("Please enter numerical values in both boxes.");
                return;
            }
            int x = int.Parse(tbNumX.Text);
            int y = int.Parse(tbNumY.Text);
            string results = "";
            string temp = "";
            if (x > y) {
                int z = y;
                y = x;
                x = z;
            }
            for (int i = x; i <= y; i++) {
                temp = i.ToString();
                if (i % 3 == 0) {
                    temp = "A";
                }
                if (i % 5 == 0)
                {
                    temp = "Z";
                }
                if (i % 3 == 0 && i % 5 == 0)
                {
                    temp = "AZ";
                }
                results += temp + " ";
            }
            lblAnswer.Text = results;
        }
        private void btnSubmit_CanClick(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = false;
            if (!(bool)tbNumX.GetValue(Validation.HasErrorProperty) && !(bool)tbNumY.GetValue(Validation.HasErrorProperty) && !(bool)RootElement.GetValue(Validation.HasErrorProperty)){
                e.CanExecute = true;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tbNumX.Text = "";
            tbNumY.Text = "";
            lblAnswer.Text = instructions;
        }
    }

    public class IsNumValidationRule : ValidationRule {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);
            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value is not an Integer in range.");
            int intVal;
            bool canConvert = int.TryParse(strValue, out intVal);
            if(!(-10000 <= intVal && intVal <= 10000))
            {
                canConvert = false;
            }
            return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input is not an Integer in range.");
        }
    }
}
