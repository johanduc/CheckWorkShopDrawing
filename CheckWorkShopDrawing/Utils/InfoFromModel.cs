using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

namespace CheckWorkShopDrawing.Utils
{
    public class InfoFromModel
    {
        public tsm.Assembly assembly { get; set; }
        public tsm.Part mainPart  { get; set; }
        public ArrayList secondaries { get; set; } = new ArrayList();

        public List<Identifier> GetListWeldIdentifier()
        {
            //Get list_Weld_Identifier_In_Model
            List<Identifier> list_Weld_Identifier_In_Model = new List<Identifier>();
            tsm.ModelObjectEnumerator weldList_In_Model = mainPart.GetWelds();
            if (weldList_In_Model.GetSize() > 0)
            {
                while (weldList_In_Model.MoveNext())
                {
                    tsm.BaseWeld weld = weldList_In_Model.Current as tsm.BaseWeld;
                    if (!list_Weld_Identifier_In_Model.Contains(weld.Identifier))
                        list_Weld_Identifier_In_Model.Add(weld.Identifier);
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
                        if (!list_Weld_Identifier_In_Model.Contains(weld.Identifier))
                            list_Weld_Identifier_In_Model.Add(weld.Identifier);
                    }
                }
            }

            return list_Weld_Identifier_In_Model;
        }

        public List<Identifier> GetListBoltIdentifier()
        {
            // Get list_Bolt_Identifier_In_Model
            List<Identifier> list_Bolt_Identifier_In_Model = new List<Identifier>();
            tsm.ModelObjectEnumerator boltList_In_Model = mainPart.GetBolts();
            if (boltList_In_Model.GetSize() > 0)
            {
                while (boltList_In_Model.MoveNext())
                {
                    tsm.BoltGroup boltGroup = boltList_In_Model.Current as tsm.BoltGroup;
                    if (!list_Bolt_Identifier_In_Model.Contains(boltGroup.Identifier))
                    {
                        list_Bolt_Identifier_In_Model.Add(boltGroup.Identifier);
                    }
                }
            }

            foreach (tsm.Part secondary in secondaries)
            {
                boltList_In_Model = secondary.GetBolts();
                if (boltList_In_Model.GetSize() > 0)
                {
                    while (boltList_In_Model.MoveNext())
                    {
                        tsm.BoltGroup boltGroup = boltList_In_Model.Current as tsm.BoltGroup;
                        if (!list_Bolt_Identifier_In_Model.Contains(boltGroup.Identifier))
                        {
                            list_Bolt_Identifier_In_Model.Add(boltGroup.Identifier);
                        }
                    }
                }
            }

            return list_Bolt_Identifier_In_Model;
        }

        public List<Identifier> GetListPartIdentifier()
        {
            // Get list_Part_Identifier_In_Model
            List<Identifier> list_Part_Identifier_In_Model = new List<Identifier>();
            list_Part_Identifier_In_Model.Add(mainPart.Identifier);

            foreach (tsm.Part secondary in secondaries)
            {
                if(!list_Part_Identifier_In_Model.Contains(secondary.Identifier))
                    list_Part_Identifier_In_Model.Add(secondary.Identifier);
            }
            return list_Part_Identifier_In_Model;
        }
    }
}
