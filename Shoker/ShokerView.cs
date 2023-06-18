using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameFrst.Shoker
{
    public class ShokerView
    {

        public ShokerModel model;

        public ShokerView(ShokerModel model)
        {
            this.model = model;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (ShokerController.Start(gameTime))
            {
                if (gameTime.TotalGameTime.Milliseconds % 20 >= 10)
                {
                    spriteBatch.Draw(model.currentTex,
                    model.shokerPos,
                    new Rectangle(0, 0, model.currentTex.Width / 2, model.currentTex.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                        0);
                }
                else
                    spriteBatch.Draw(model.currentTex,
                        model.shokerPos,
                        new Rectangle(model.currentTex.Width / 2, 0, model.currentTex.Width / 2, model.currentTex.Height),
                        Color.White,
                        0, Vector2.Zero,
                        1,
                        SpriteEffects.None,
                        0);
            }
            //spriteBatch.Draw(currentTex, rectangle, Color.Red);
        }
    }
}
