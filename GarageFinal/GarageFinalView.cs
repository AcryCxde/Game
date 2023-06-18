using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameFrst.Anotogonist;
using GameFrst.HelpersClass;
using Microsoft.Xna.Framework.Input;
using GameFrst.Sprite;

namespace GameFrst.GarageFinal
{
    public class GarageFinalView
    {
        GarageFinalModel model;
        private int timer;
        private bool isWorking;

        public GarageFinalView(GarageFinalModel model)
        {
            this.model = model;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteModel sprite,Helpers helpers)
        {
            if (model.isReady)
                spriteBatch.Draw(model.texture,
                model.position,
                new Rectangle(model.texture.Width / 2, 0, model.texture.Width / 2, model.texture.Height),
                Color.White,
                0, Vector2.Zero,
                1,
                SpriteEffects.None,
                    0);
            else
            {
                spriteBatch.Draw(model.texture,
                model.position,
                new Rectangle(0, 0, model.texture.Width / 2, model.texture.Height),
                Color.White,
                0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);

                if (timer < 180 && (isWorking || (Keyboard.GetState().IsKeyDown(Keys.E) && sprite.Rectangle.Intersects(model.rectangle))))
                {
                    isWorking = true;
                    helpers.DrawHelpMachine(spriteBatch, sprite.Position);
                    timer++;
                }
                else if (timer == 180)
                {
                    isWorking = false;
                    timer = 0;
                }
            }
                
        }

        public void DrawVictory(SpriteBatch spriteBatch, AntogonistModel antogonist)
        {
            if (antogonist.victory)
                spriteBatch.Draw(model.texture,
                model.position,
                new Rectangle(model.texture.Width / 2, 0, model.texture.Width / 2, model.texture.Height),
                Color.White,
                0, Vector2.Zero,
                1,
                SpriteEffects.None,
                0);
        }
    }
}
