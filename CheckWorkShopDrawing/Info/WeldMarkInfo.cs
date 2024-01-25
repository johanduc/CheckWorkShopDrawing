using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

namespace CheckWorkShopDrawing.Info
{
    public class WeldMarkInfo
    {
        public int ID { get; set; }
        public tsm.ModelObject mainObject { get; set; }
        public tsm.ModelObject secondaryObject { get; set; }
        public double SizeAbove { get; set; }
        public double SizeBelow { get; set; }

        public static List<WeldMarkInfo> Get_Infos_Missing_Weld(List<Identifier> list_Weld_Identifier_Missing)
        {
            List<WeldMarkInfo> missing_weldMarkInfos = new List<WeldMarkInfo>();

            foreach (Identifier weld_Identifier in list_Weld_Identifier_Missing)
            {
                WeldMarkInfo weldMarkInfo = new WeldMarkInfo();
                tsm.BaseWeld baseWeld = Form1.model.SelectModelObject(weld_Identifier) as tsm.BaseWeld;
                weldMarkInfo.ID = baseWeld.Identifier.ID;
                weldMarkInfo.mainObject = baseWeld.MainObject;
                weldMarkInfo.secondaryObject = baseWeld.SecondaryObject;
                weldMarkInfo.SizeAbove = baseWeld.SizeAbove;
                weldMarkInfo.SizeBelow = baseWeld.SizeBelow;
                missing_weldMarkInfos.Add(weldMarkInfo);
            }

            return missing_weldMarkInfos;
        }
    }

}
