using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Emeralds
{
    public class EmeraldsController
    {

        public EmeraldsModel model;

        public EmeraldsController(EmeraldsModel model)
        {
            this.model = model;
        }

        public void Update(GameTime gameTime, Rectangle playerRect)
        {
            if (playerRect.Intersects(model.rectangle))
                model.isPickedUp = true;
        }
    }
}
