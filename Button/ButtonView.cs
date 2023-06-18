using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameFrst.Button
{
    public class ButtonView
    {
        ButtonModel model;
        public ButtonView(ButtonModel buttonModel)
        {
            model = buttonModel;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (model.isActive)
                spriteBatch.Draw(model.tex,
                    model.position,
                    new Rectangle(model.tex.Width / 2, 0, model.tex.Width / 2, model.tex.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);
            else
                spriteBatch.Draw(model.tex,
                    model.position,
                    new Rectangle(0, 0, model.tex.Width / 2, model.tex.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);
        }
    }
}
