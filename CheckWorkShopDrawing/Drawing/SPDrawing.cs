using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

using tsm = Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;

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
            MessageBox.Show(id.ID.ToString());
            tsd.ContainerView containerView = singlePartDR.GetSheet();
            tsd.DrawingObjectEnumerator drawingObjectEnumerator = containerView.GetAllViews();
        }
    }
}
