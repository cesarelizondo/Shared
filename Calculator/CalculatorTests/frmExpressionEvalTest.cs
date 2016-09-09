using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass()]
    public class frmExpressionEvalTest
    {       
        Evaluate eval = new Evaluate();

        [TestMethod()]
        public void SimpleBinaryExpressionValid()
        {
            string binaryExp = "1+4";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(5, val);
        }

        [TestMethod()]
        public void SimpleBinaryExpressionInValid()
        {
            string binaryExp = "1++2";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(null, val, "This should return false it returned " + val);
        }

        [TestMethod()]
        public void POWExpresionValid()
        {
            string binaryExp = "10^2";
           Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(100, val);
        }

        [TestMethod()]
        public void POWExpresionInValid()
        {
            string binaryExp = "10^^2";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(null, val, "This should be an invalid expression, and result mut be 0 as defined");
        }

        [TestMethod()]
        public void SQRTExpresionValid()
        {
            string binaryExp = "SQRT(5^4)";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(25, val);
        }

        [TestMethod()]
        public void SQRTExpresionInValid()
        {
            string binaryExp = "SQRT(5/)";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(null, val, "This should be an invalid expression, and result mut be 0 as defined");
        }


        [TestMethod()]
        public void SimpleDivisionExpressionValid()
        {
            string binaryExp = "12/2";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(6, val);
        }

        [TestMethod()]
        public void ExpressionWithParenthesesValid()
        {
            string binaryExp = "10(10)";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(100, val);
        }

        [TestMethod()]
        public void ExpressionWithParenthesesAndOperatorValid()
        {
            string binaryExp = "2(1+2)";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(6, val);
        }

        [TestMethod()]
        public void SimpleBinaryExpressionWithinParenthesesValid()
        {
            string binaryExp = "(1+2)";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(3, val);
        }

        [TestMethod()]
        public void MultiplicationWithParenthesesValid()
        {
            string binaryExp = "1(1+2)";
            Double? val = eval.EvaluateExpression(binaryExp);

            Assert.AreEqual(3, val);
        }
    }
}
