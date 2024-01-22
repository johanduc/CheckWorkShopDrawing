using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

using CheckWorkShopDrawing.Info;

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

            //Get list_Weld_ID_In_Model
            List<Identifier> list_Weld_ID_In_Model = new List<Identifier>();
            tsm.ModelObjectEnumerator weldList_In_Model = mainPart.GetWelds();
            if (weldList_In_Model.GetSize() > 0)
            {
                while (weldList_In_Model.MoveNext())
                {
                    tsm.BaseWeld weld = weldList_In_Model.Current as tsm.BaseWeld;
                    if (!list_Weld_ID_In_Model.Contains(weld.Identifier))
                        list_Weld_ID_In_Model.Add(weld.Identifier);
                }
            }

            foreach (tsm.Part secondary in secondaries)
            {
                weldList_In_Model = secondary.GetWelds();
                if (weldList_In_Model.GetSize() > 0)
                {
                    while (weldList_In_Model.MoveNext())
                    {
                        tsm.BaseWeld weld = weldList_In_Model.Current as tsm.BaseWeld;
                        if (!list_Weld_ID_In_Model.Contains(weld.Identifier))
                            list_Weld_ID_In_Model.Add(weld.Identifier);
                    }
                }
            }

            // Get list_Bolt_ID_In_Model
            List<Identifier> list_Bolt_ID_In_Model = new List<Identifier>();
            tsm.ModelObjectEnumerator boltList_In_Model = mainPart.GetBolts();
            if(boltList_In_Model.GetSize() > 0)
            {
                while (boltList_In_Model.MoveNext())
                {
                    tsm.BoltGroup boltGroup = boltList_In_Model.Current as tsm.BoltGroup;
                    if(!list_Bolt_ID_In_Model.Contains(boltGroup.Identifier))
                    {
                        list_Bolt_ID_In_Model.Add(boltGroup.Identifier);
                    }
                }
            }

            foreach (tsm.Part secondary in secondaries)
            {
                boltList_In_Model = secondary.GetBolts();
                if(boltList_In_Model.GetSize() > 0)
                {
                    while (boltList_In_Model.MoveNext())
                    {
                        tsm.BoltGroup boltGroup = boltList_In_Model.Current as tsm.BoltGroup;
                        if (!list_Bolt_ID_In_Model.Contains(boltGroup.Identifier))
                        {
                            list_Bolt_ID_In_Model.Add(boltGroup.Identifier);
                        }
                    }
                }
            }

            List<Identifier> list_Weld_ID_In_Drawing = new List<Identifier>();

            //while (allViews.MoveNext())
            //{
            //    if (!(allViews.Current is tsd.View)) continue;
            //    tsd.View currentView = allViews.Current as tsd.View;
            //    tsd.DrawingObjectEnumerator drawingObject = currentView.GetObjects();
            //    tsd.DrawingObjectEnumerator weldMarkList = currentView.GetObjects(new Type[] { typeof(tsd.WeldMark) });
            //    List<int> list = new List<int>();
            //    while (weldMarkList.MoveNext())
            //    {
            //        tsd.WeldMark weldMark = weldMarkList.Current as tsd.WeldMark;
            //        Identifier id12 = weldMark.ModelIdentifier;
            //        list.Add(id12.ID);
            //    }
            //    //while (drawingObject.MoveNext())
            //    //{
            //    //    MessageBox.Show(drawingObject.Current.GetType().ToString());
            //    //}
            //    List<int> noDup = list.Distinct().ToList();
            //}

            List<Identifier> list_ID_Object_From_Mark = new List<Identifier>();

            while (allViews.MoveNext())
            {
                if (!(allViews.Current is tsd.View)) continue;
                tsd.View currentView = allViews.Current as tsd.View;

                //Dimension List
                tsd.DrawingObjectEnumerator dimensionList = currentView.GetObjects(new Type[] { typeof(tsd.DimensionSetBase) });
                while (dimensionList.MoveNext())
                {
                    if (dimensionList.Current is tsd.StraightDimensionSet)
                    {
                        tsd.StraightDimensionSet straightDimensionSet = dimensionList.Current as tsd.StraightDimensionSet;
                    }
                    else if (dimensionList.Current is tsd.CurvedDimensionSetBase)
                    {
                        tsd.CurvedDimensionSetBase curvedDimensionSetBase = dimensionList.Current as tsd.CurvedDimensionSetBase;
                    }
                }

                //Weld Mark List
                tsd.DrawingObjectEnumerator weldMarkList = currentView.GetObjects(new Type[] { typeof(tsd.WeldMark) });
                List<int> weld_ID_CurrentView = new List<int>();
                while (weldMarkList.MoveNext())
                {
                    tsd.WeldMark weldMark = weldMarkList.Current as tsd.WeldMark;
                    if (!weld_ID_CurrentView.Contains(weldMark.ModelIdentifier.ID))
                        weld_ID_CurrentView.Add(weldMark.ModelIdentifier.ID);

                    if (!list_Weld_ID_In_Drawing.Contains(weldMark.ModelIdentifier))
                        list_Weld_ID_In_Drawing.Add(weldMark.ModelIdentifier);
                }

                //weld_ID_CurrentView.Sort();

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
                while(MarkList.MoveNext())
                {
                    
                    tsd.Mark mark = MarkList.Current as tsd.Mark;
                    tsd.MarkBase.MarkBaseAttributes markBaseAttributes = mark.Attributes;
                    Type type = markBaseAttributes.GetType();
                    FieldInfo field = type.GetField("ModelObjectIdentifier", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    string value = field.GetValue(markBaseAttributes).ToString();
                    if (value == null) continue;
                    int id_value = Convert.ToInt32(value);
                    if (value != null)
                    {
                        Identifier objectID = new Identifier(id_value);
                        tsm.ModelObject mObj = Form1.model.SelectModelObject(objectID);
                        Console.WriteLine(mObj.GetType().ToString());
                        if (mObj is tsm.BoltGroup || mObj is tsm.Part)
                        {
                            list_ID_Object_From_Mark.Add(mObj.Identifier);
                        }
                    }
                    else
                    {
                        int i = 0;
                    }
                }
                //MessageBox.Show(MarkList.GetSize().ToString());

                //Connection List
                tsd.DrawingObjectEnumerator ConnectionList = currentView.GetObjects(new Type[] { typeof(tsd.Connection) });
                //MessageBox.Show(ConnectionList.GetSize().ToString());

                //Bolt List
                tsd.DrawingObjectEnumerator BoltList = currentView.GetObjects(new Type[] { typeof(tsd.Bolt) });
                //MessageBox.Show(BoltList.GetSize().ToString());

            }

            List<Identifier> list_Weld_ID_Missing = new List<Identifier>();

            if (list_Weld_ID_In_Model != list_Weld_ID_In_Drawing)
            {
                list_Weld_ID_Missing = list_Weld_ID_In_Model.Except(list_Weld_ID_In_Drawing).ToList();
            }

            List<WeldMarkInfo> weldMarkInfos = new List<WeldMarkInfo>();

            foreach (Identifier weldID in list_Weld_ID_Missing)
            {
                WeldMarkInfo weldMarkInfo = new WeldMarkInfo();
                tsm.BaseWeld baseWeld = Form1.model.SelectModelObject(weldID) as tsm.BaseWeld;
                weldMarkInfo.ID = baseWeld.Identifier.ID;
                weldMarkInfo.mainObject = baseWeld.MainObject;
                weldMarkInfo.secondaryObject = baseWeld.SecondaryObject;
                weldMarkInfos.Add(weldMarkInfo);
            }
        }
    }
}
