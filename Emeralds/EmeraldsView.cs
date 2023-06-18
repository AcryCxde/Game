using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Emeralds
{
    public class EmeraldsView
    {
        public EmeraldsModel model;

        public EmeraldsView(EmeraldsModel model)
        {
            this.model = model;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!model.isPickedUp)
                spriteBatch.Draw(model.texture, model.position, Color.White);
        }
    }
}
