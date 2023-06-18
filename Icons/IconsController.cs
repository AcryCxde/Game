using GameFrst.InputClass;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Icons
{
    public class IconsController
    {
        public IconsModel model;

        public IconsController(IconsModel model)
        {
            this.model = model;
        }

        public void Update(GameTime gameTime, Vector2 playerPos)
        {
            model.input.Update();

            model.posShoker = playerPos + new Vector2(-403, 346);
            model.posLight = playerPos + new Vector2(492, 346);
        }
    }
}
