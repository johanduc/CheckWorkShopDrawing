using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

using CheckWorkShopDrawing.Drawing;

namespace CheckWorkShopDrawing
{
    public partial class Form1 : Form
    {
        public static tsd.DrawingHandler dh = new DrawingHandler();
        public static tsm.Model model = new Model();
        public Form1()
        {
            InitializeComponent();

            if (!model.GetConnectionStatus())
            {
                MessageBox.Show("Check connection to Tekla model");
            }
        }

        private void btn_CheckDrawing_Click(object sender, EventArgs e)
        {
            if(!dh.GetConnectionStatus())
            {
                return;
                MessageBox.Show("Select drawings to run tool!");
            }

            tsd.DrawingEnumerator selectedDrawing = dh.GetDrawingSelector().GetSelected();

            while (selectedDrawing.MoveNext())
            {
                if(selectedDrawing.Current is tsd.AssemblyDrawing)
                {
                    AssDrawing assDrawing = new AssDrawing(selectedDrawing.Current as tsd.AssemblyDrawing);
                    assDrawing.Check();
                }
                else if(selectedDrawing.Current is tsd.SinglePartDrawing)
                {
                    SPDrawing spDrawing = new SPDrawing(selectedDrawing.Current as tsd.SinglePartDrawing);
                    spDrawing.Check();
                }
               
            }
        }
    }
}
