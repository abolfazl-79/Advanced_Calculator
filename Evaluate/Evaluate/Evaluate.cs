using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluate
{
    class Evaluate
    {
        static double F_evaluate(string function ,string value)
        {
            if(function == "Sin")
            {
                double radian = (Convert.ToDouble(value) * (Math.PI)) / 180.0;
                return Math.Round(Math.Sin(radian),4);
            }
            else if(function == "Cos")
            {
                double radian = (Convert.ToDouble(value) * (Math.PI)) / 180.0;
                return Math.Round(Math.Cos(radian), 4);
            }
            else if (function == "Tan")
            {
                double radian = (Convert.ToDouble(value) * (Math.PI)) / 180.0;
                return Math.Round(Math.Tan(radian), 4);
            }
            else if (function == "Cot")
            {
                double radian = (Convert.ToDouble(value) * (Math.PI)) / 180.0;
                return Math.Round(1/Math.Tan(radian), 4);
            }
            else if (function == "Log")
            {
                return Math.Log10(Convert.ToDouble(value));
            }
            else if(function == "Ln")
            {
                return Math.Log(Convert.ToDouble(value));
            }
            else if(function == "√")
            {
                return Math.Sqrt(Convert.ToDouble(value)); 
            }
            else
            {
                return Math.Sqrt(Convert.ToDouble(value));
            }
        }
        public string evaluate(string infix)
        {
            Converting convert = new Converting();
            string prefix = convert.infixToPrefix(infix);
            Stack<string> operand = new Stack<string>(prefix.Length);
            for (int i = prefix.Length - 1; i >= 0; i--)
            {
                if (!(convert.isOperator(prefix[i])))
                {
                    string s = "";
                    while ((i > 0 && !convert.isOperator(prefix[i])) || prefix[i] == '-')
                    {
                        s += prefix[i];
                        i--;
                    }
                    
                    char[] arr = s.ToCharArray();
                    Array.Reverse(arr);
                    s = new String(arr);
                    Console.WriteLine(s);
                    if (s.Contains('.'))
                    {
                        int v_len = s.Length;
                        int dot_position = s.IndexOf('.');
                        int value = int.Parse(s.Replace(".", ""));
                        double newValue = ((double)value / Math.Pow(10, v_len - (dot_position + 1)));
                        operand.push(newValue.ToString());
                    }
                    
                    else if (Converting.isFunction(s))
                    {
                        Console.WriteLine("////////");
                        string value = operand.pop();
                        operand.push(F_evaluate(s, value).ToString());
                    }
                    else
                    {
                        operand.push(s);
                        i++;
                    }
                }
                else if(prefix[i] == ' ')
                {
                    continue;
                }
                else
                {
                    double op1 = Convert.ToDouble(operand.peek());
                    operand.pop();

                    double op2 = Convert.ToDouble(operand.peek());
                    operand.pop();

                    switch(prefix[i])
                    {
                        case '^':
                            operand.push(Math.Pow(op1,op2).ToString());
                            break;
                        case '*':
                            operand.push((op1 * op2).ToString());
                            break;
                        case '/':
                            operand.push((op1 / op2).ToString());
                            break;
                        case '+':
                            operand.push((op1 + op2).ToString());
                            break;
                        case '-':
                            operand.push((op1 - op2).ToString());
                            break;
                    }
                    

                }
            }
            return operand.pop();
        }
    }
}
