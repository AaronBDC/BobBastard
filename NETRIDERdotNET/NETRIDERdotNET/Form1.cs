using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region Testing ProphetsWayToolzSuite
using ProphetsWay.BaseDataAccess;
using ProphetsWay.EFTools;
using ProphetsWay.Hasher;
using ProphetsWay.iBatisTools;
using ProphetsWay.Utilities;

#endregion Testing ProphetsWayToolzSuite
namespace NETRIDERdotNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public void Super()
        {
            //webView21.NavigateToString("http://netrider.co");
            webView21.Source = new Uri("http://netrider.co");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String errorMessage = null;
            try
            {
                // code for try
                Super();
            }
            catch (Exception ex)
            {
                // code for ex
                errorMessage = ex.Message;
                Console.WriteLine(errorMessage);
            }
            finally
            {
                // code for finally/cleanup
            }

        }

        #region Functions 
        #endregion Functions

        #region UnitTests
        #endregion UnitTests
    }
}
