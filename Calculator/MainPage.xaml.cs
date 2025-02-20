namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private double storage = 0;
        private double operand = 0;
        private string operation = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberBtn(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operand = (operand * 10) + Convert.ToDouble(button.Text);

            Calculation.Text += button.Text;
        }

        private void OperatorBtn(object sender, EventArgs e)
        {
            if (operation != "")
            {
                Calculate();
            }
            else
            {
                storage = operand;
            }

            operand = 0;

            Button button = (Button)sender;
            operation = button.Text;

            Calculation.Text += $"{operation}";
        }

        private void EqualBtn(object sender, EventArgs e)
        {
            Calculate();

            Calculation.Text = storage.ToString();

            operation = "";
            operand = 0;
        }

        private void Calculate()
        {
            switch (operation)
            {
                case "+":
                    storage += operand;
                    break;
                case "-":
                    storage -= operand;
                    break;
                case "*":
                    storage *= operand;
                    break;
                case "/":
                    if (operand == 0)
                    {
                        Clear();
                        return;
                    }
                    storage /= operand;
                    break;
            }
            operand = 0;
        }

        private void ClearBtn(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            storage = 0;
            operand = 0;
            operation = "";

            Calculation.Text = "";
        }


    }
} 
