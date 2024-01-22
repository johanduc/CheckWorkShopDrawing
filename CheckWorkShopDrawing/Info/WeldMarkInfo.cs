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
    }         
}
