using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Evaluate
    {
        MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();

        // [+\-*/^] Match any character in the set. {2,} match 2 or more of the preceding token
        Regex InvalidOperatorsRegex = new Regex(@"[+\-*/^]{2,}");

        // Convert & parse the expression to be accepted by VB Script. 
        //Using nullable type to be able to return null values
        public Double? EvaluateExpression(string expression)
        {
            if (expression == null)
            {
                return null;
            }

            Double? result = null,
                    tempRes = 0;

            string insideExp = "";

            int firstParent = 0,
                lastParent = 0;

            sc.Language = "VBScript";

            // If exp contains 2 or more adjacent operators result will be null due to invalid expression
            if (InvalidOperatorsRegex.Match(expression).Success)
            {
                return null;
            }

            // Replace & convert to lower string "sqrt" to "sqr" to match VBScript expression
            if (expression.ToLower().Contains("sqrt"))
            {
                expression = expression.ToLower().Replace("sqrt", "sqr");
            }

            // Solve expression inside parentheses first and replace the result in exp
            if (!expression.ToLower().Contains("sqr") && expression.Contains("("))
            {
                try
                {
                    firstParent = expression.IndexOf("(") + 1;
                    lastParent = expression.IndexOf(")", firstParent);
                    insideExp = expression.Substring(firstParent, lastParent - firstParent);
                    tempRes = sc.Eval(insideExp);
                    expression = expression.Replace(insideExp, tempRes.ToString());
                    result = sc.Eval(expression);

                    return result;
                }
                catch
                {
                    expression = replaceParenthesesByStar(expression);
                }    
            }

            //Evaluating expression normally in case there is no SquareRoot
            try
            {
                result = sc.Eval(expression);
            }
            catch
            {
                return null;
            }
            return result;
        }

        private string replaceParenthesesByStar(string exp)
        {
            int idxParentesisFirst = 0,
                idxParentesisLast = 0;

            // Replace opening parenthesis to * operator and remove closing parenthesis
            idxParentesisFirst = exp.IndexOf('(');
            idxParentesisLast = exp.IndexOf(')');

            if ((idxParentesisFirst - 1) >= 0)
            {
                exp = exp.Replace("(", "*");
            }
            else
            {
                exp = exp.Replace(")", "");
            }

            if ((idxParentesisLast + 1) < exp.Length)
            {
                exp = exp.Replace("(", "*");
            }
            else
            {
                exp = exp.Replace(")", "");
            }

            return exp;
        }
    }
}

