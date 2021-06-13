using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Stack oper = new Stack();
        Stack parentheses = new Stack();
        public bool isoperator(char c)
        {
            if(c == '/' || c == '*' || c == '+' || c == '-' || c == '.' || c == '^')
            {
                return true;
            }
            return false;
        }
        public bool isfunction(string s)
        {
            if(s == "Sin(" || s == "Cos(" || s == "Tan(" || s == "Cot(" || s == "Log(" || s == "Ln(" || s == "√(")
            {
                return true;
            }
            return false;
        }
        public bool isnumber(char c)
        {
            if (c >= '0' && c <= '9') return true;
            return false;
        }

        private void numbers_click(object sender, EventArgs e)
        {
            string phrase = txtDisplay.Text;
            Button btn = (Button)sender;
            if (phrase == "0")
            {
                txtDisplay.Clear();
                txtDisplay.Text = txtDisplay.Text + btn.Text;
                return;

            }
            if ( phrase[phrase.Length - 1] == ')' || phrase[phrase.Length-1] == 'e' || phrase[phrase.Length - 1] == 'π')
            {
                return;
            }
            txtDisplay.Text = txtDisplay.Text + btn.Text;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void operators_click(object sender, EventArgs e)
        {

            string phrase = txtDisplay.Text;
            Button btn = (Button)sender;
            if (isoperator(phrase[phrase.Length - 1]))
            {
                return;
            }
            if(phrase[phrase.Length-1] == '(')
            {
                txtDisplay.Text = txtDisplay.Text + "0";
            }
            
            if(btn.Text == ".")
            {
                if(oper.Count > 0 || phrase[phrase.Length-1] == 'π')
                {
                    Console.WriteLine("///////1");
                    return;
                }
                else
                {
                    oper.Push(".");
                }
            }
            else
            {
                if (oper.Count != 0)
                {
                    oper.Pop();
                }
            }
            txtDisplay.Text = txtDisplay.Text + btn.Text;
        }

        private void clear_click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void function_click(object sender, EventArgs e)
        {
            string phrase = txtDisplay.Text;
            Button btn = (Button)sender;
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Clear();
                txtDisplay.Text = txtDisplay.Text + btn.Text + "(";
                parentheses.Push("(");
                return;
            }
            if(phrase[phrase.Length-1] == ')' || isnumber(phrase[phrase.Length-1]))
            {
                return;
            }
            
            txtDisplay.Text = txtDisplay.Text + btn.Text + "(";
            parentheses.Push("(");
        }


        private void Exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void File_click(object sender, EventArgs e)
        {

        }
        private void backSpace_click(object sender, EventArgs e)
        {
            string phrase = txtDisplay.Text;

            if (phrase.Length > 4 && (isfunction(phrase.Substring(phrase.Length - 4)) || isfunction(phrase.Substring(phrase.Length - 3)) || isfunction(phrase.Substring(phrase.Length - 2))))
            {
               
                if(phrase[phrase.Length - 3] == 'L')
                {
                    txtDisplay.Text = phrase.Substring(0, phrase.Length - 3);
                    parentheses.Pop();
                }
                else if(phrase[phrase.Length - 2] == '√')
                {
                    txtDisplay.Text = phrase.Substring(0, phrase.Length - 2);
                    parentheses.Pop();
                }
                else
                {
                    txtDisplay.Text = phrase.Substring(0, phrase.Length - 4);
                    parentheses.Pop();
                }
                
            }
            else if(phrase.Length == 4 && isfunction(phrase.Substring(phrase.Length - 4)))
            {
                txtDisplay.Text = phrase.Substring(0, phrase.Length - 4);
                parentheses.Pop();
                txtDisplay.Text = "0";
            }
            else if(phrase.Length == 3 && isfunction(phrase.Substring(phrase.Length - 3)))
            {
                txtDisplay.Text = phrase.Substring(0, phrase.Length - 3);
                parentheses.Pop();
                txtDisplay.Text = "0";
            }
            else if (phrase.Length == 2 && isfunction(phrase.Substring(phrase.Length - 2)))
            {
                txtDisplay.Text = phrase.Substring(0, phrase.Length - 2);
                parentheses.Pop();
                txtDisplay.Text = "0";
            }
            else
            {
                if(phrase.Length <= 1)
                {
                    if(phrase[phrase.Length-1] == '(')
                    {
                        txtDisplay.Text = "0";
                        parentheses.Pop();
                        return;
                    }
                    txtDisplay.Text = "0";
                    return;
                }

                if(phrase[phrase.Length-1] == '(')
                {
                    
                    txtDisplay.Text = phrase.Substring(0, phrase.Length - 1);
                    parentheses.Pop();
                    return;
                }
                if(phrase[phrase.Length - 1] == ')')
                {
                    txtDisplay.Text = phrase.Substring(0, phrase.Length - 1);
                    parentheses.Push("(");
                    return;
                }
                if(phrase[phrase.Length - 1] == '.')
                {
                    txtDisplay.Text = phrase.Substring(0, phrase.Length - 1);
                    oper.Pop();
                    return;
                }
                txtDisplay.Text = phrase.Substring(0, phrase.Length - 1);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void LeftParentheses_click(object sender, EventArgs e)
        {
            string phrase = txtDisplay.Text;
            Button btn = (Button)sender;
            if (phrase == "0")
            {
                txtDisplay.Clear();
                txtDisplay.Text = txtDisplay.Text + btn.Text;
                parentheses.Push("(");
                return;
            }
            if(phrase.Length >= 1 && (isnumber(phrase[phrase.Length-1]) || phrase[phrase.Length-1] == ')' || phrase[phrase.Length - 1] == 'e' || phrase[phrase.Length - 1] == 'π'))
            {
                return;
            }
            
            txtDisplay.Text = txtDisplay.Text + btn.Text ;
            parentheses.Push("(");
        }

        private void RightParentheses_click(object sender, EventArgs e)
        {
            string phrase = txtDisplay.Text;
            Button btn = (Button)sender;
            if (phrase == "0" || isoperator(phrase[phrase.Length - 1]) || phrase[phrase.Length - 1] == '(')
            {
                return;
            }
            if(parentheses.Count > 0)
            {
                parentheses.Pop();
                txtDisplay.Text = txtDisplay.Text + btn.Text;
            }
            else
            {
                return;
            }
        }

        private void evaluate_Click(object sender, EventArgs e)
        {
            Evaluate expression = new Evaluate();
            if (parentheses.Count != 0)
            {
                int temp = parentheses.Count;
                MessageBox.Show("Lack of "+ temp +" right parentheses!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string answer = expression.evaluate(txtDisplay.Text);
                if (answer == "NaN")
                {
                    MessageBox.Show("There is something wrong in expression!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtDisplay.Text = answer;
                }
            }
        }

        

        private void neper_Click(object sender, EventArgs e)
        {
            string phrase = txtDisplay.Text;
            Button btn = (Button)sender;
            if (phrase == "0")
            {
                txtDisplay.Clear();
                txtDisplay.Text = txtDisplay.Text + btn.Text;
                return;
            }
            if(isnumber(phrase[phrase.Length-1]) || phrase[phrase.Length - 1] == ')' || phrase[phrase.Length - 1] == 'e' || phrase[phrase.Length - 1] == 'π')
            {
                return;
            }
            txtDisplay.Text = txtDisplay.Text + btn.Text;
        }

        private void Pi_Click(object sender, EventArgs e)
        {
            string phrase = txtDisplay.Text;
            Button btn = (Button)sender;

            if(phrase == "0")
            {
                txtDisplay.Clear();
                txtDisplay.Text = txtDisplay.Text + btn.Text;
                return;
            }
            if(isnumber(phrase[phrase.Length-1]) || phrase[phrase.Length - 1] == ')' || phrase[phrase.Length - 1] == 'e' || phrase[phrase.Length - 1] == 'π')
            {
                return;
            }
            txtDisplay.Text = txtDisplay.Text + btn.Text;
        }
    }
}
