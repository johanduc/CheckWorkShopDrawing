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
    public class BoltMarkInfo
    {
        public int ID { get; set; }
        public int numberOfBolt { get; set; }
        public double BoltSize { get; set; }
        public double Tolerance { get; set; }

        public static List<BoltMarkInfo> Get_Infos_Missing_Bolt(List<Identifier> list_Bolt_Identifier_Missing)
        {
            List<BoltMarkInfo> missing_BoltMarkInfos = new List<BoltMarkInfo>();

            foreach (Identifier bolt_Identifier in list_Bolt_Identifier_Missing)
            {
                BoltMarkInfo boltMarkInfo = new BoltMarkInfo();
                tsm.BoltGroup boltGroup = Form1.model.SelectModelObject(bolt_Identifier) as tsm.BoltGroup;
                boltMarkInfo.ID = boltGroup.Identifier.ID;
                boltMarkInfo.numberOfBolt = boltGroup.BoltPositions.Count;
                boltMarkInfo.BoltSize = boltGroup.BoltSize;
                boltMarkInfo.Tolerance = boltGroup.Tolerance;
                missing_BoltMarkInfos.Add(boltMarkInfo);
            }

            return missing_BoltMarkInfos;
        }
    }
}
