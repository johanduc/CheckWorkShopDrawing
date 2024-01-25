using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Data;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

using CheckWorkShopDrawing.Info;
using CheckWorkShopDrawing.Utils;

namespace CheckWorkShopDrawing.Drawing
{
    public class SPDrawing
    {
        private tsd.SinglePartDrawing singlePartDR;

        public SPDrawing(tsd.SinglePartDrawing drawing)
        {
            this.singlePartDR = drawing;
        }

        public void Check()
        {
            Identifier id = singlePartDR.PartIdentifier;
            tsd.ContainerView containerView = singlePartDR.GetSheet();
            tsd.DrawingObjectEnumerator allViews = containerView.GetAllViews();

            tsm.Part part = Form1.model.SelectModelObject(id) as tsm.Part;

            InfoFromModel infoFromModel = new InfoFromModel()
            {
                mainPart = part
            };

            InfoFromDrawing infoFromDrawing = new InfoFromDrawing()
            {
                allViews = allViews
            };

            #region Check Part Mark
            //List<Identifier> list_Part_Identifier_In_Model = infoFromModel.GetListPartIdentifier();
            //List<Identifier> list_Part_Identifier_In_Drawing = infoFromDrawing.GetListPartIdentifier();
            //List<Identifier> list_Part_Identifier_Missing = new List<Identifier>();

            //if (list_Part_Identifier_In_Model.Count != list_Part_Identifier_In_Drawing.Count)
            //{
            //    list_Part_Identifier_Missing = list_Part_Identifier_In_Model.Except(list_Part_Identifier_In_Drawing).ToList();
            //}
            //List<PartMarkInfo> missing_partMarkInfos = PartMarkInfo.Get_Infos_Missing_Part(list_Part_Identifier_Missing);

            //if (missing_partMarkInfos.Count > 0)
            //{
            //    foreach (PartMarkInfo partMarkInfo in missing_partMarkInfos)
            //    {
            //        DataRow newRow = Form1.dtInfo.NewRow();
            //        newRow["col_No"] = Form1.count++;
            //        newRow["col_DrawingType"] = "Single Part";
            //        newRow["col_DrawingMark"] = singlePartDR.Mark;
            //        newRow["col_TypeMissing"] = "Part Mark";
            //        newRow["col_missingID"] = partMarkInfo.ID;
            //        Form1.dtInfo.Rows.Add(newRow);
            //    }
            //}
            #endregion

            #region Check Bolt Mark
            //List<Identifier> list_Bolt_Identifier_In_Model = infoFromModel.GetListBoltIdentifier();
            //List<Identifier> list_Bolt_Identifier_In_Drawing = infoFromDrawing.GetListBoltIdentifier();
            //List<Identifier> list_Bolt_Identifier_Missing = new List<Identifier>();
            //if (list_Bolt_Identifier_In_Model.Count != list_Bolt_Identifier_In_Drawing.Count)
            //{
            //    list_Bolt_Identifier_Missing = list_Bolt_Identifier_In_Model.Except(list_Bolt_Identifier_In_Drawing).ToList();
            //}
            //List<BoltMarkInfo> missing_boltMarkInfos = BoltMarkInfo.Get_Infos_Missing_Bolt(list_Bolt_Identifier_Missing);

            //if (missing_boltMarkInfos.Count > 0)
            //{
            //    foreach (BoltMarkInfo boltMarkInfo in missing_boltMarkInfos)
            //    {
            //        DataRow newRow = Form1.dtInfo.NewRow();
            //        newRow["col_No"] = Form1.count++;
            //        newRow["col_DrawingType"] = "Single Part";
            //        newRow["col_DrawingMark"] = singlePartDR.Mark;
            //        newRow["col_TypeMissing"] = "Bolt Mark";
            //        newRow["col_missingID"] = boltMarkInfo.ID;
            //        Form1.dtInfo.Rows.Add(newRow);
            //    }
            //}
            #endregion

            #region Check Dimension Mark
            List<Identifier> list_Dimension_Identifier_In_Drawing = infoFromDrawing.GetListDimensionIdentifier();

            #endregion
        }
    }
}
