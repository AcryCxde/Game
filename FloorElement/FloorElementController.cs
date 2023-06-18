using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameFrst.FloorElement
{
    public class FloorElementController
    {
        FloorElementModel model;
        public FloorElementController( FloorElementModel model)
        {
            this.model = model;
        }

        public virtual void Update(Rectangle playerRect)
        {
            if (model.texSides.Contains('U'))
                model.Up = playerRect.Intersects(new Rectangle((int)model.texX, (int)model.texY - 160, model.texWidth, 5)) 
                    ? false : true;

            if (model.texSides.Contains('D'))
                model.Down = playerRect.Intersects(new Rectangle((int)model.texX, (int)model.texY + model.texHeight, model.texWidth, 5)) 
                    ? false: true;

            if (model.texSides.Contains('L'))
                model.Left = playerRect.Intersects(new Rectangle((int)model.texX - 60, (int)model.texY, 5, model.texHeight - 60)) 
                    ? false : true;

            if (model.texSides.Contains('R'))
                model.Right = playerRect.Intersects(new Rectangle((int)model.texX + model.texWidth + 60, (int)model.texY, 5, model.texHeight - 150)) 
                    ? false : true;
        }

        public virtual void Collide(ICanCollide collideObject)
        {
            if (collideObject.Rectangle.Intersects(model.Rectangle))
            {
                Update(collideObject.Rectangle);
                collideObject.UpdateFlagFloor(model.Up, model.Down, model.Right, model.Left);
            }
        }
    }
}
