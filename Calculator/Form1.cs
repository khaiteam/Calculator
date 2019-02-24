using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Calculator _calculator;
        public Form1()
        {
            InitializeComponent();
            _calculator = new Calculator();
            txtb.ReadOnly = true;
            txtb.Text = "0";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (txtb.Text[0] == '-')
            {
                txtb.Text = txtb.Text.Remove(0, 1);
                return;
            }
            if (txtb.Text[0] != '0')
            {
                txtb.Text += '-' + txtb.Text;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            txtb.Text = "0";
            _calculator.Left = 0;
            _calculator.Right = 0;
            FreeButtons();
        }

        private void btn0_Click(object sender, System.EventArgs e)
        {
            txtb.Text += (sender as Button).Text;
            CorrectNumber();
        }

        private void btnSum_Click(object sender, System.EventArgs e)
        {
            if(CanPress())
            {
                var btn = sender as Button;
                btn.Enabled = false;
                _calculator.Left = Convert.ToDouble(txtb.Text);
                txtb.Text = "0";
            }
        }

        private bool CanPress()
        {
            if (!btnMultiplication.Enabled)
                return false;

            if (!btnSubtraction.Enabled)
                return false;

            if (!btnSum.Enabled)
                return false;

            if (!btnDivision.Enabled)
                return false;

            return true;
        }

        private void FreeButtons()
        {
            btnMultiplication.Enabled = true;
            btnSubtraction.Enabled = true;
            btnDivision.Enabled = true;
            btnSum.Enabled = true;
        }
        private void btndot_Click(object sender, System.EventArgs e)
        {
            if ((txtb.Text.IndexOf(".") == -1) && (txtb.Text.IndexOf("∞") == -1))
                txtb.Text += ".";
        }

        private void btnrez_Click(object sender, System.EventArgs e)
        {
            _calculator.Right = Convert.ToDouble(txtb.Text);
            if (!btnMultiplication.Enabled)
                txtb.Text = _calculator.Actions["*"].Invoke(_calculator.Left, _calculator.Right).ToString();
            if (!btnDivision.Enabled)
                txtb.Text = _calculator.Actions["/"].Invoke(_calculator.Left, _calculator.Right).ToString();
            if (!btnSum.Enabled)
                txtb.Text = _calculator.Actions["+"].Invoke(_calculator.Left, _calculator.Right).ToString();
            if (!btnSubtraction.Enabled)
                txtb.Text = _calculator.Actions["-"].Invoke(_calculator.Left, _calculator.Right).ToString();
            _calculator.Left = 0;
            _calculator.Right = 0;
            FreeButtons();
        }

        private void CorrectNumber()
        {
            //if infinity - you can't write anything
            if (txtb.Text.IndexOf("∞") != -1)
                txtb.Text = txtb.Text.Substring(0, txtb.Text.Length - 1);

            //removes redunant '0'
            if (txtb.Text[0] == '0' && (txtb.Text.IndexOf(",") != 1))
                txtb.Text = txtb.Text.Remove(0, 1);

            //removes redunant '-'
            if (txtb.Text[0] == '-')
                if (txtb.Text[1] == '0' && (txtb.Text.IndexOf(",") != 2))
                    txtb.Text = txtb.Text.Remove(1, 1);
        }
    }
}
