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
    public class PartMarkInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int StartNumber { get; set; }

        public static List<PartMarkInfo> Get_Infos_Missing_Part(List<Identifier> list_Part_Identifier_Missing)
        {
            List<PartMarkInfo> missing_PartMarkInfos = new List<PartMarkInfo>();

            foreach (Identifier part_Identifier in list_Part_Identifier_Missing)
            {
                PartMarkInfo partMarkInfo = new PartMarkInfo();
                tsm.Part part = Form1.model.SelectModelObject(part_Identifier) as tsm.Part;
                partMarkInfo.ID = part.Identifier.ID;
                partMarkInfo.Name = part.Name;
                partMarkInfo.Prefix = part.PartNumber.Prefix;
                partMarkInfo.StartNumber = part.PartNumber.StartNumber;
                missing_PartMarkInfos.Add(partMarkInfo);
            }

            return missing_PartMarkInfos;
        }
    }


}
