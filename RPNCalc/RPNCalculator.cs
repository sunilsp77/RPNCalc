using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace RPNCalc
{
    class RPNCalculator
    {
        Stack<int> st = new Stack<int>();
        public string finalres;
        public string Calculate(string arg)
        {
            string[] arr = arg.Split(',');
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Equals("+") || arr[i].Equals("-") || arr[i].Equals("*") || arr[i].Equals("/"))
                    {
                        if (st.Count < 2)
                        {
                            throw new Exception("Invalid Expression");
                        }
                        int res;
                        int a = st.Pop();
                        int b = st.Pop();
                        if (a >= Int32.MaxValue || b >= Int32.MaxValue)
                            throw new Exception("greater than max");
                        if (arr[i].Equals("+"))
                        {
                            res = b + a;
                            if (res >= int.MaxValue)
                            {
                                finalres = "greater than max";
                                throw new Exception(finalres);
                            }
                        }
                        else if (arr[i].Equals("-"))
                        {
                            res = b - a;
                        }
                        else if (arr[i].Equals("*"))
                        {
                            res = b * a;
                        }
                        else if (arr[i].Equals("/"))
                        {
                            if (a == 0)
                            {
                                finalres = "Divide by zero";
                                throw new Exception(finalres);
                            }
                            res = b / a;
                        }
                        else
                        {
                            finalres = "Invalid operator";
                            throw new Exception(finalres);
                        }
                        st.Push(res);
                    }
                    else if (arr[i].Equals("!"))
                    {
                        if (st.Count < 1)
                        {
                            finalres = "Invalid Expression";
                            throw new Exception(finalres);
                        }
                        int res;
                        int a = st.Pop();
                        if (arr[i].Equals("!"))
                        {
                            if (a < 0)
                            {
                                finalres = "Invalid Operand";
                                throw new Exception(finalres);
                            }

                            int fact_result = calculate_fact(a);
                            res = fact_result;
                        }
                        else
                        {
                            finalres = "Invalid operator";
                            throw new Exception(finalres);
                        }
                        st.Push(res);
                    }
                    else
                    {
                        st.Push(Convert.ToInt32(arr[i]));
                    }

                }
                finalres = st.Pop().ToString();
            }
            catch (Exception e)
            {
               
            }
            return finalres;
        }
        public int calculate_fact(int a)
        {
            if(a==0)
            {
                return 1;
            }
            return a * calculate_fact(a - 1);
        }
            
       }
    
}
