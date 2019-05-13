using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalApp : Form
    {
        public CalApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // static strings to prevent the later malfunctions
        public static string prevEquation = "", prevOperation = "", operation = "";

        public static double answer = 0;

        // Send the lbl.Text to the txtDisplay
        private void AllLbl_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            
            switch(lbl.Name)
            {
                // Delete action
                case "lblDel":
                    // Validating whether txtDisplay has characters or not
                    if(txtDisplay.Text.Length > 0)
                    {
                        // To get the length and delete char one by one from the back
                        /// 0 is the index of the veryfirst string. 
                        /// So it GETs 0th index character and SETs the removal of the last char  
                        txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                    }
                    break;
                // All Clear action
                case "lblAc":
                    operation = "";
                    txtDisplay.ResetText();
                    txtDisplay2.ResetText();
                    break;
                // Separate the decimal point
                case "lblDot":
                    if(!txtDisplay.Text.Contains("."))
                    {
                        //This is to append thetxtDisplay
                        txtDisplay.Text += ".";
                    }
                    break;
                // Plus and Minus action
                case "lblPlusMinus":
                    if(txtDisplay.Text.Length > 0)
                    {
                        if (!txtDisplay.Text.Contains("-"))
                        {
                            // Add minus sign to the beggining of the string
                            txtDisplay.Text = "-" + txtDisplay.Text;
                        }
                        else if(txtDisplay.Text.Contains("-"))
                        {
                            // Remove the biggining minus sign from the string
                            txtDisplay.Text = txtDisplay.Text.Substring(1, txtDisplay.Text.Length - 1);
                        }
                    }
                    break;
                // To get the lbl value to the txtDisplay and reset the minus
                default:
                    if(operation == "-")
                    {
                        operation = "";
                        txtDisplay.ResetText();
                    }
                    txtDisplay.Text += lbl.Text;
                    break;
            }
        }

        // Arithmatic operation controlling
        private void Operation_Click(object sender, EventArgs e)
        {
            Label opr = sender as Label;

            switch (opr.Text)
            {
                case "+":
                    if (txtDisplay.Text.Length > 0)
                    {
                        // When operation is blank or equal to the =, then it assigns to the +
                        if (operation == "" || operation == "=")
                        {
                            operation = "+";
                            prevOperation = operation;
                            prevEquation = txtDisplay.Text;
                            txtDisplay2.Text = prevEquation + operation;
                            txtDisplay.ResetText();
                        }
                    }
                    // After assigns, then it makes the calculation 
                    else
                    {
                        operation = "+";
                        MultiEquations();
                    }
                    break;
                case "-":
                    if (txtDisplay.Text.Length > 0)
                    {
                        // When operation is blank or equal to the =, then it assigns to the -
                        if (operation == "" || operation == "=")
                        {
                            operation = "-";
                            prevOperation = operation;
                            prevEquation = txtDisplay.Text;
                            txtDisplay2.Text = prevEquation + operation;
                            txtDisplay.ResetText();
                        }
                    }
                    // After assigns, then it makes the calculation 
                    else
                    {
                        operation = "-";
                        MultiEquations();
                    }
                    break;
                case "÷":
                    if (txtDisplay.Text.Length > 0)
                    {
                        // When operation is blank or equal to the =, then it assigns to the /
                        if (operation == "" || operation == "=")
                        {
                            operation = "÷";
                            prevOperation = operation;
                            prevEquation = txtDisplay.Text;
                            txtDisplay2.Text = prevEquation + operation;
                            txtDisplay.ResetText();
                        }
                    }
                    // After assigns, then it makes the calculation 
                    else
                    {
                        operation = "÷";
                        MultiEquations();
                    }
                    break;
                case "x":
                    if (txtDisplay.Text.Length > 0)
                    {
                        // When operation is blank or equal to the =, then it assigns to the x
                        if (operation == "" || operation == "=")
                        {
                            operation = "x";
                            prevOperation = operation;
                            prevEquation = txtDisplay.Text;
                            txtDisplay2.Text = prevEquation + operation;
                            txtDisplay.ResetText();
                        }
                    }
                    // After assigns, then it makes the calculation 
                    else
                    {
                        operation = "x";
                        MultiEquations();
                    }
                    break;
                case "=":
                    if (txtDisplay.Text.Length > 0)
                    {
                        // If operation equals to the =, it will do the calculation directly
                        operation = "=";
                        MultiEquations();
                        txtDisplay2.ResetText();
                        txtDisplay.Text = answer.ToString();
                    }
                    break;
            }
        }

        private void MultiEquations()
        {
            // If previous operation equals to the +, it will assign to the operation and to the calculation
            if (prevOperation == "+")
            {
                prevOperation = operation;

                // Converting strings to double
                answer = Convert.ToDouble(prevEquation) + Convert.ToDouble(txtDisplay.Text);

                // PrevEquation assigns to the answer and make it a strring again
                prevEquation = answer.ToString();
                txtDisplay2.Text = prevEquation + operation;
                txtDisplay.ResetText();
            }
            // If previous operation equals to the -, it will assign to the operation and to the calculation
            else if (prevOperation == "-")
            {
                prevOperation = operation;

                // Converting strings to double
                answer = Convert.ToDouble(prevEquation) - Convert.ToDouble(txtDisplay.Text);

                // PrevEquation assigns to the answer and make it a strring again
                prevEquation = answer.ToString();
                txtDisplay2.Text = prevEquation + operation;
                txtDisplay.ResetText();
            }
            // If previous operation equals to the /, it will assign to the operation and to the calculation
            else if (prevOperation == "÷")
            {
                prevOperation = operation;

                // Converting strings to double
                answer = Convert.ToDouble(prevEquation) / Convert.ToDouble(txtDisplay.Text);

                // PrevEquation assigns to the answer and make it a strring again
                prevEquation = answer.ToString();
                txtDisplay2.Text = prevEquation + operation;
                txtDisplay.ResetText();
            }
            // If previous operation equals to the x, it will assign to the operation and to the calculation
            else if (prevOperation == "x")
            {
                prevOperation = operation;

                // Converting strings to double
                answer = Convert.ToDouble(prevEquation) * Convert.ToDouble(txtDisplay.Text);

                // PrevEquation assigns to the answer and make it a strring again
                prevEquation = answer.ToString();
                txtDisplay2.Text = prevEquation + operation;
                txtDisplay.ResetText();
            }
        }
    }
}
