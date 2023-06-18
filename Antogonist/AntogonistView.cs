using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace GameFrst.Anotogonist
{
    public class AntogonistView
    {
        AntogonistModel model;
        public AntogonistView(AntogonistModel model)
        {
            this.model = model;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!model.isFreeze)
            {
                if (gameTime.TotalGameTime.Milliseconds >= 500)
                {
                    spriteBatch.Draw(model.texture,
                    model.position,
                    new Rectangle(model.texture.Width / 2, 0, model.texture.Width / 2, model.texture.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                        0);
                }
                else
                    spriteBatch.Draw(model.texture,
                    model.position,
                    new Rectangle(0, 0, model.texture.Width / 2, model.texture.Height),
                        Color.White,
                        0, Vector2.Zero,
                        1,
                        SpriteEffects.None,
                        0);
            }
            else
                spriteBatch.Draw(model.texture,
                model.position,
                new Rectangle(0, 0, model.texture.Width / 2, model.texture.Height),
                        Color.White,
                        0, Vector2.Zero,
                        1,
                        SpriteEffects.None,
                0);

            //spriteBatch.Draw(model.texture, model.Rectangle4Platform, Color.Blue);
        }
    }
}
