using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

namespace CheckWorkShopDrawing.Utils
{
    public class InfoFromDrawing
    {
        public tsd.DrawingObjectEnumerator allViews { get; set; }

        public List<Identifier> GetListWeldIdentifier()
        {
            List<Identifier> list_Weld_Identifier_In_Drawing = new List<Identifier>();
            allViews.Reset();
            while (allViews.MoveNext())
            {
                if (!(allViews.Current is tsd.View)) continue;
                tsd.View currentView = allViews.Current as tsd.View;

                //Weld Mark List
                tsd.DrawingObjectEnumerator weldMarkList = currentView.GetObjects(new Type[] { typeof(tsd.WeldMark) });
                while (weldMarkList.MoveNext())
                {
                    tsd.WeldMark weldMark = weldMarkList.Current as tsd.WeldMark;
                    Identifier weld_ID_From_Drawing = weldMark.ModelIdentifier;
                    tsm.BaseWeld weld_In_model = Form1.model.SelectModelObject(weldMark.ModelIdentifier) as tsm.BaseWeld;
                    Identifier weld_ID_From_Model = weld_In_model.Identifier;
                    if (!list_Weld_Identifier_In_Drawing.Contains(weld_ID_From_Model))
                    {
                        list_Weld_Identifier_In_Drawing.Add(weld_ID_From_Model);

                    }
                }
            }

            return list_Weld_Identifier_In_Drawing;
        }

        public List<Identifier> GetListPartIdentifier()
        {
            List<Identifier> list_Part_Identifier_In_Drawing = new List<Identifier>();
            allViews.Reset();
            while (allViews.MoveNext())
            {
                if (!(allViews.Current is tsd.View)) continue;
                tsd.View currentView = allViews.Current as tsd.View;
                tsd.DrawingObjectEnumerator MarkList = currentView.GetObjects(new Type[] { typeof(tsd.Mark) });
                while(MarkList.MoveNext())
                {
                    tsd.Mark mark = MarkList.Current as tsd.Mark;
                    tsd.MarkBase.MarkBaseAttributes markBaseAttributes = mark.Attributes;
                    Type type = markBaseAttributes.GetType();
                    FieldInfo fieldInfo = type.GetField("ModelObjectIdentifier", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var value = fieldInfo.GetValue(markBaseAttributes);
                    if (value == null) continue;
                    int valueID = Convert.ToInt32(value.ToString());
                    Identifier objectID = new Identifier(valueID);
                    tsm.ModelObject modelObject = Form1.model.SelectModelObject(objectID);
                    if (modelObject is tsm.Part)
                    {
                        list_Part_Identifier_In_Drawing.Add(modelObject.Identifier);
                    }
                }
            }

            return list_Part_Identifier_In_Drawing;
        }

        public List<Identifier> GetListBoltIdentifier()
        {
            List<Identifier> list_Bolt_Identifier_In_Drawing = new List<Identifier>();
            allViews.Reset();
            while (allViews.MoveNext())
            {
                if (!(allViews.Current is tsd.View)) continue;
                tsd.View currentView = allViews.Current as tsd.View;
                tsd.DrawingObjectEnumerator MarkList = currentView.GetObjects(new Type[] { typeof(tsd.Mark) });
                while (MarkList.MoveNext())
                {
                    tsd.Mark mark = MarkList.Current as tsd.Mark;
                    tsd.MarkBase.MarkBaseAttributes markBaseAttributes = mark.Attributes;
                    Type type = markBaseAttributes.GetType();
                    FieldInfo fieldInfo = type.GetField("ModelObjectIdentifier", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var value = fieldInfo.GetValue(markBaseAttributes);
                    if (value == null) continue;
                    int valueID = Convert.ToInt32(value.ToString());
                    Identifier objectID = new Identifier(valueID);
                    tsm.ModelObject modelObject = Form1.model.SelectModelObject(objectID);
                    if (modelObject is tsm.BoltGroup)
                    {
                        list_Bolt_Identifier_In_Drawing.Add(modelObject.Identifier);
                    }
                }
            }

            return list_Bolt_Identifier_In_Drawing;
        }

        public List<Identifier> GetListDimensionIdentifier()
        {
            List<Identifier> list_Dimension_Identifier_In_Drawing = new List<Identifier>();
            allViews.Reset();
            while (allViews.MoveNext())
            {
                if (!(allViews.Current is tsd.View)) continue;
                tsd.View currentView = allViews.Current as tsd.View;
                tsd.DrawingObjectEnumerator dimensionList = currentView.GetObjects(new Type[] { typeof(tsd.DimensionSetBase) });
                while (dimensionList.MoveNext())
                {
                    if (!(dimensionList.Current is tsd.StraightDimensionSet)) continue;
                    tsd.StraightDimensionSet straightDimensionSet = dimensionList.Current as tsd.StraightDimensionSet;
                }
            }
            return list_Dimension_Identifier_In_Drawing;
        }
    }
}
