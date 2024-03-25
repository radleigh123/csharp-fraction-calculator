using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace FractionForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OperatorsCombo.SelectedIndex = 0;

            //pre-defined inputs
            Num1.Text = "1";
            Deno1.Text = "2";
            Num2.Text = "1";
            Deno2.Text = "3";
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            var f1 = new Fraction(int.Parse(Num1.Text), int.Parse(Deno1.Text));
            var f2 = new Fraction(int.Parse(Num2.Text), int.Parse(Deno2.Text));

            Fraction result = null;
            switch (OperatorsCombo.SelectedIndex)
            {
                case 0:
                    result = f1 + f2;
                    break;
                case 1:
                    result = f1 - f2;
                    break;
                case 2:
                    result = f1 * f2;
                    break;
                case 3:
                    result = f1 / f2;
                    break;
                default:
                    MessageBox.Show("Invalid operator.");
                    return;
            }

            //double resultFloat = (double) result.GetNum() / result.GetDeno();
            FloatingTBox.Text = (double) result.GetNum() / result.GetDeno() + "";
            Num3.Text = result.GetNum() + "";
            Deno3.Text = result.GetDeno() + "";
        }

        private bool ValidateInputs()
        {
            Regex numRegex = new Regex(@"^\d+$");
            Regex denoRegex = new Regex(@"^[1-9][0-9]*$");

            if (!numRegex.IsMatch(Num1.Text) || !numRegex.IsMatch(Num2.Text))
            {
                MessageBox.Show("Please enter a valid numerator.");
                return false;
            }

            if (!denoRegex.IsMatch(Deno1.Text) || !denoRegex.IsMatch(Deno2.Text))
            {
                MessageBox.Show("Please enter a valid denominator.");
                return false;
            }

            return true;
        }
    }
}
