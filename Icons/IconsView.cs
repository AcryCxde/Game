using GameFrst.FlashLight;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrst.Shoker;

namespace GameFrst.Icons
{
    public class IconsView
    {
        public IconsModel model;

        public IconsView(IconsModel model)
        {
            this.model = model;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (FlashLightModel.IsActive)
                spriteBatch.Draw(model.texLight,
                    model.posLight,
                    new Rectangle(0, 0, model.texLight.Width / 2, model.texLight.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);
            else
                spriteBatch.Draw(model.texLight,
                    model.posLight,
                    new Rectangle(model.texLight.Width / 2, 0, model.texLight.Width / 2, model.texLight.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);

            if (ShokerModel.isFiring || gameTime.TotalGameTime.TotalSeconds - ShokerModel.lastShotTime < 10f
)
                spriteBatch.Draw(model.texShoker,
                model.posShoker,
                new Rectangle(model.texShoker.Width / 2, 0, model.texShoker.Width / 2, model.texShoker.Height),
                Color.White,
                0, Vector2.Zero,
                1,
                SpriteEffects.None,
                    0);
            else
                spriteBatch.Draw(model.texShoker,
                    model.posShoker,
                    new Rectangle(0, 0, model.texShoker.Width / 2, model.texShoker.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);
        }
    }
}
