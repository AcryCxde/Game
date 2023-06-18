using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameFrst.FlashLight
{
    public class FlashLightView
    {

        FlashLightModel model;

        public FlashLightView(FlashLightModel model)
        {
            this.model = model;
        }
        public void Draw(Rectangle playerRect, SpriteBatch spriteBatch)
        {
            if (!playerRect.Intersects(new Rectangle(8448, 2021, 3899, 4023)))
            {
                if (FlashLightModel.IsActive)
                {
                    spriteBatch.Draw(model.texture,
                    model.position,
                    new Rectangle(model.texture.Width / 2, 0, model.texture.Width / 2, model.texture.Height),
                    Color.White,
                        0,
                        Vector2.Zero,
                        1,
                    SpriteEffects.None,
                        0);
                }
                else
                {
                    spriteBatch.Draw(model.texture,
                    model.position,
                        new Rectangle(0, 0, model.texture.Width / 2, model.texture.Height),
                        Color.White,
                        0,
                        Vector2.Zero,
                        1,
                        SpriteEffects.None,
                        0);
                }
            }
                
        }
    }
}
