using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsmui = Tekla.Structures.Model.UI;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

using CheckWorkShopDrawing.Drawing;

namespace CheckWorkShopDrawing
{
    public partial class Form1 : Form
    {
        public static tsd.DrawingHandler dh = new DrawingHandler();
        public static tsm.Model model = new Model();
        public static DataTable dtInfo = new DataTable();
        public static int count = 0;

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
            try
            {
                //Check connection to Drawing
                if (!dh.GetConnectionStatus())
                {
                    return;
                    MessageBox.Show("Select drawings to run tool!");
                }

                //Reset index before running tool
                count = 0;
                var dt = adgv_ResultTable.DataSource as System.Data.DataTable;
                if (dt != null)
                {
                    dt.Rows.Clear();
                    adgv_ResultTable.DataSource = dt;
                }

                tsd.DrawingEnumerator selectedDrawing = dh.GetDrawingSelector().GetSelected();

                while (selectedDrawing.MoveNext())
                {
                    tsd.Drawing currentDrawing = selectedDrawing.Current as tsd.Drawing;
                    if (currentDrawing is tsd.AssemblyDrawing)
                    {
                        AssDrawing assDrawing = new AssDrawing(currentDrawing as tsd.AssemblyDrawing);
                        assDrawing.Check();
                    }
                    else if (currentDrawing is tsd.SinglePartDrawing)
                    {
                        SPDrawing spDrawing = new SPDrawing(currentDrawing as tsd.SinglePartDrawing);
                        spDrawing.Check();
                    }
                }
                adgv_ResultTable.DataSource = dtInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                MessageBox.Show("Done");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtInfo = new DataTable();
            foreach (DataGridViewColumn col in adgv_ResultTable.Columns)
            {
                dtInfo.Columns.Add(col.Name);
                col.DataPropertyName = col.Name;
            }
        }

        private void adgv_ResultTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection cells = adgv_ResultTable.SelectedCells;// List cell trong datagridview
            ArrayList objList = new ArrayList();
            foreach (DataGridViewCell cell in cells)
            {
                int rowIndex = cell.RowIndex;
                //Lấy giá trị của cột 4
                if (adgv_ResultTable.Rows[rowIndex].Cells[4].Value == null) continue;
                string id = adgv_ResultTable.Rows[rowIndex].Cells[4].Value.ToString();
                tsm.ModelObject mObj = model.SelectModelObject(new Identifier(int.Parse(id)));
                objList.Add(mObj);
            }
            tsmui.ModelObjectSelector mObjSelector = new tsmui.ModelObjectSelector();
            mObjSelector.Select(objList);
            Tekla.Structures.ModelInternal.Operation.dotStartAction("ZoomToSelected", "");
            model.CommitChanges();
        }
    }
}
