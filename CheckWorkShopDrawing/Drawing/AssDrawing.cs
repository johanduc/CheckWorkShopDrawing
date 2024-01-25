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
    public class AssDrawing
    {
        private tsd.AssemblyDrawing assemDR;
        public AssDrawing(tsd.AssemblyDrawing drawing)
        {
            this.assemDR = drawing;
        }

        public void Check()
        {
            Identifier id = assemDR.AssemblyIdentifier;
            tsd.ContainerView containerView = assemDR.GetSheet();
            tsd.DrawingObjectEnumerator allViews = containerView.GetAllViews();

            tsm.Assembly assembly = Form1.model.SelectModelObject(id) as tsm.Assembly;
            tsm.Part mainPart = assembly.GetMainPart() as tsm.Part;
            ArrayList secondaries = assembly.GetSecondaries();

            InfoFromModel infoFromModel = new InfoFromModel()
            {
                mainPart = mainPart,
                secondaries = secondaries
            };

            InfoFromDrawing infoFromDrawing = new InfoFromDrawing()
            {
                allViews = allViews
            };

            #region Check Weld Mark
            //Check Weld Mark
            List<Identifier> list_Weld_Identifier_In_Model = infoFromModel.GetListWeldIdentifier();
            List<Identifier> list_Weld_Identifier_In_Drawing = infoFromDrawing.GetListWeldIdentifier();
            List<Identifier> list_Weld_Identifier_Missing = new List<Identifier>();

            if (list_Weld_Identifier_In_Model.Count != list_Weld_Identifier_In_Drawing.Count)
            {
                list_Weld_Identifier_Missing = list_Weld_Identifier_In_Model.Except(list_Weld_Identifier_In_Drawing).ToList();
            }
            List<WeldMarkInfo> missing_weldMarkInfos = WeldMarkInfo.Get_Infos_Missing_Weld(list_Weld_Identifier_Missing);

            if (missing_weldMarkInfos.Count > 0)
            {
                foreach (WeldMarkInfo weldMarkInfo in missing_weldMarkInfos)
                {
                    DataRow newRow = Form1.dtInfo.NewRow();
                    newRow["col_No"] = Form1.count++;
                    newRow["col_DrawingType"] = "Assembly";
                    newRow["col_DrawingMark"] = assemDR.Mark;
                    newRow["col_TypeMissing"] = "Weld Mark";
                    newRow["col_missingID"] = weldMarkInfo.ID;
                    Form1.dtInfo.Rows.Add(newRow);
                }
            }
            #endregion

            #region Check Part Mark
            //Check Part Mark
            List<Identifier> list_Part_Identifier_In_Model = infoFromModel.GetListPartIdentifier();
            List<Identifier> list_Part_Identifier_In_Drawing = infoFromDrawing.GetListPartIdentifier();
            List<Identifier> list_Part_Identifier_Missing = new List<Identifier>();

            if (list_Part_Identifier_In_Model.Count != list_Part_Identifier_In_Drawing.Count)
            {
                list_Part_Identifier_Missing = list_Part_Identifier_In_Model.Except(list_Part_Identifier_In_Drawing).ToList();
            }
            List<PartMarkInfo> missing_partMarkInfos = PartMarkInfo.Get_Infos_Missing_Part(list_Part_Identifier_Missing);

            if (missing_partMarkInfos.Count > 0)
            {
                foreach (PartMarkInfo partMarkInfo in missing_partMarkInfos)
                {
                    DataRow newRow = Form1.dtInfo.NewRow();
                    newRow["col_No"] = Form1.count++;
                    newRow["col_DrawingType"] = "Assembly";
                    newRow["col_DrawingMark"] = assemDR.Mark;
                    newRow["col_TypeMissing"] = "Part Mark";
                    newRow["col_missingID"] = partMarkInfo.ID;
                    Form1.dtInfo.Rows.Add(newRow);
                }
            }
            #endregion

            #region Check Bolt Mark
            //Check Bolt Mark
            List<Identifier> list_Bolt_Identifier_In_Model = infoFromModel.GetListBoltIdentifier();
            List<Identifier> list_Bolt_Identifier_In_Drawing = infoFromDrawing.GetListBoltIdentifier();
            List<Identifier> list_Bolt_Identifier_Missing = new List<Identifier>();
            if (list_Bolt_Identifier_In_Model.Count != list_Bolt_Identifier_In_Drawing.Count)
            {
                list_Bolt_Identifier_Missing = list_Bolt_Identifier_In_Model.Except(list_Bolt_Identifier_In_Drawing).ToList();
            }
            List<BoltMarkInfo> missing_boltMarkInfos = BoltMarkInfo.Get_Infos_Missing_Bolt(list_Bolt_Identifier_Missing);

            if (missing_boltMarkInfos.Count > 0)
            {
                foreach (BoltMarkInfo boltMarkInfo in missing_boltMarkInfos)
                {
                    DataRow newRow = Form1.dtInfo.NewRow();
                    newRow["col_No"] = Form1.count++;
                    newRow["col_DrawingType"] = "Assembly";
                    newRow["col_DrawingMark"] = assemDR.Mark;
                    newRow["col_TypeMissing"] = "Bolt Mark";
                    newRow["col_missingID"] = boltMarkInfo.ID;
                    Form1.dtInfo.Rows.Add(newRow);
                }
            }

            #endregion
            
            List<Identifier> list_ID_Object_From_Mark = new List<Identifier>();

            while (allViews.MoveNext())
            {
                if (!(allViews.Current is tsd.View)) continue;
                tsd.View currentView = allViews.Current as tsd.View;

                ////Dimension List
                //tsd.DrawingObjectEnumerator dimensionList = currentView.GetObjects(new Type[] { typeof(tsd.DimensionSetBase) });
                //while (dimensionList.MoveNext())
                //{
                //    if (dimensionList.Current is tsd.StraightDimensionSet)
                //    {
                //        tsd.StraightDimensionSet straightDimensionSet = dimensionList.Current as tsd.StraightDimensionSet;
                //    }
                //    else if (dimensionList.Current is tsd.CurvedDimensionSetBase)
                //    {
                //        tsd.CurvedDimensionSetBase curvedDimensionSetBase = dimensionList.Current as tsd.CurvedDimensionSetBase;
                //    }
                //}

                ////Part List
                //List<int> part_ID_CurrentView = new List<int>();
                //tsd.DrawingObjectEnumerator PartList_currentView = currentView.GetObjects(new Type[] { typeof(tsd.Part) });

                //while (PartList_currentView.MoveNext())
                //{
                //    tsd.Part part = PartList_currentView.Current as tsd.Part;

                //    part_ID_CurrentView.Add(part.ModelIdentifier.ID);

                //    tsm.Part part_In_Model = Form1.model.SelectModelObject(part.ModelIdentifier) as tsm.Part;
                //    tsm.ModelObjectEnumerator weldList = part_In_Model.GetWelds();

                //    while (weldList.MoveNext())
                //    {
                //        if (!(weldList.Current is tsm.BaseWeld)) continue;
                //        tsm.BaseWeld baseWeld = weldList.Current as tsm.BaseWeld;
                //        tsm.ModelObject mainObject = baseWeld.MainObject;
                //        tsm.ModelObject secondaryObject = baseWeld.SecondaryObject;

                //        if(!list_Weld_ID_In_Drawing.Contains(baseWeld.Identifier.ID))
                //        {
                //            list_Weld_ID_In_Drawing.Add(baseWeld.Identifier.ID);
                //        }
                //    }
                //}

                //list_Weld_ID_In_Drawing.Sort();

                //Leader Line List
                tsd.DrawingObjectEnumerator LeaderLineList = currentView.GetObjects(new Type[] { typeof(tsd.LeaderLine) });
                //MessageBox.Show(LeaderLineList.GetSize().ToString());

                //Mark List
                tsd.DrawingObjectEnumerator MarkList = currentView.GetObjects(new Type[] { typeof(tsd.Mark) });

                //Connection List
                tsd.DrawingObjectEnumerator ConnectionList = currentView.GetObjects(new Type[] { typeof(tsd.Connection) });
                //MessageBox.Show(ConnectionList.GetSize().ToString());

                //Bolt List
                tsd.DrawingObjectEnumerator BoltList = currentView.GetObjects(new Type[] { typeof(tsd.Bolt) });
                //MessageBox.Show(BoltList.GetSize().ToString());

            }
        }
    }
}
