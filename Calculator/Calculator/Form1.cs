using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmExpressionEval : Form
    {
        public frmExpressionEval()
        {
            InitializeComponent();
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            Double? res = 0;
            Evaluate eval = new Evaluate();

            res = eval.EvaluateExpression(txtExpression.Text);

            if (res != null)
            {
                txtResult.Text = res.ToString();
            }
            else
            {
                MessageBox.Show("Not Valid Expression");
            }
        }
    }
}
