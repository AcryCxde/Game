using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameFrst.FloorElement
{
    public class FloorElementView
    {
        FloorElementModel model;
        public FloorElementView(FloorElementModel model)
        {
            this.model = model;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(model.tex, new Vector2(model.texX, model.texY), Color.White);

            //spriteBatch.Draw(model.tex, new Rectangle((int)model.texX, (int)model.texY - 160, model.texWidth, 5), Color.Red);
            //spriteBatch.Draw(model.tex, new Rectangle((int)model.texX, (int)model.texY + model.texHeight, model.texWidth, 5), Color.Blue);
            //spriteBatch.Draw(model.tex, new Rectangle((int)model.texX - 60, (int)model.texY, 5, model.texHeight - 60), Color.Green);
            //spriteBatch.Draw(model.tex, new Rectangle((int)model.texX + model.texWidth + 60, (int)model.texY, 5, model.texHeight - 150), Color.Black);
        }
    }   
}
