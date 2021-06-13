using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluate
{
    class Converting
    {

        static int getPriority(string c)
        {
            if (c == "*" || c == "/")
            {
                return 2;
            }
            else if (c == "+" || c == "-")
            {
                return 1;
            }
            else if (c == "^" || isFunction(c))
            {
                return 3;
            }
            return 0;
        }

        public static bool isAlphabet(char c)
        {
            if ((c >= 'a' && c <= 'z') || (c <= 'Z' && c >= 'A') || c == '√') return true;
            return false;
        }

        public static bool isFunction(string s)
        {
            if(s == "Sin" || s == "Cos" || s == "Tan" || s == "Cot" || s == "Log" || s == "Ln" || s == "√")
            {
                return true;
            }
            return false;
        }
        public bool isOperator(char c)
        {
            if (!(c >= 'a' && c <= 'z') && !(c >= '0' && c <= '9') && !(c <= 'Z' && c >= 'A') && !(c == '.') && !(c == 'e') && !(c == 'π') && !(c == '√'))
            {
                return true;
            }
            return false;
        }

        public string infixToPrefix(string phrase)
        {
            Stack<String> operators = new Stack<String>(phrase.Length);
            Stack<String> operands = new Stack<String>(phrase.Length);
            
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == '(')   //check the left parentheses
                {
                    operators.push(phrase[i]+"");
                }
                else if (phrase[i] == ')')        //check the right parentheses
                {
                    while (!operators.isempty() && operators.peek() != "(")    
                    {
                        
                        if(isFunction(operators.peek()))         //check the element if it is a function
                        {
                            string op1 = operands.pop();
                            string f = operators.pop();
                            operands.push(" " + f + op1);
                        }
                       else
                       {
                            string op1 = operands.pop();
                            string oper = operators.pop();
                            string op2 = operands.pop();

                            operands.push(oper + op2 + op1);
                       }
                        
                    }
                    operators.pop();                           //pop left element from stack
                }
                else if (!isOperator(phrase[i]))  //check the elements except the operators
                {
                    string s = "";
                    while (i < phrase.Length)   //check it if it is  Multi-digit number or it is function
                    {
                        if(!isOperator(phrase[i]))
                        {
                            s += phrase[i];
                            i++;
                        }
                        
                        else
                        {
                            break;
                        }
                    }
                    if (s == "π")
                    {
                        s = "3.14";
                    }
                    else if (s == "e")
                    {
                        s = "2.71";
                    }

                    if (operands.peek() == "-")
                    {
                        operands.pop();
                        operands.push(" -" + s + " ");
                    }
                    else
                    {
                        if(!isFunction(s))
                        {
                            operands.push(" " + s + " ");
                        }
                        else
                        {
                            operators.push(s);
                        }
                        
                    }
                    i--;
                }
                else
                {
                    if(phrase[i] == '-' && ((i == 0 && (phrase[i+1] == '(' || isAlphabet(phrase[i+1])))
                        || (i != 0 && phrase[i-1] == '(' && (phrase[i + 1] == '(' || isAlphabet(phrase[i + 1])))))
                    {
                        operands.push(" -1 ");
                        operators.push("*");
                    }
                    else if(phrase[i] == '-' && ((i == 0 && !isOperator(phrase[i+1])) || (phrase[i-1] == '(' && !isOperator(phrase[i + 1]))))
                    {
                        operands.push("-");
                    }
                    else
                    {
                        while (!operators.isempty() && getPriority(phrase[i]+"") <= getPriority(operators.peek()))
                        {
                            if (isFunction(operators.peek()))
                            {
                                string op1 = operands.pop();
                                string f = operators.pop();
                                operands.push(" " + f + op1);
                            }
                            else
                            {
                                string op1 = operands.pop();
                                string oper = operators.pop();
                                string op2 = operands.pop();

                                operands.push(oper + op2 + op1);
                            }
                            
                        }
                        operators.push(phrase[i]+"");
                    }
                    
                }
            }

            while (!operators.isempty())
            {
                if(isFunction(operators.peek()))
                {
                    string op1 = operands.pop();
                    string f = operators.pop();
                    operands.push(" " + f + op1);
                }
                else
                {
                    string op1 = operands.pop();
                    string oper = operators.pop();
                    string op2 = operands.pop();

                    operands.push(oper + op2 + op1);
                }
                
            }

            return operands.peek();
        }
    }
}
