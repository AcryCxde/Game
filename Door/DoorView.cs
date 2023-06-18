using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameFrst.HelpersClass;
using Microsoft.Xna.Framework.Input;
using GameFrst.Sprite;

namespace GameFrst.Door
{
    public class DoorView
    {
        private DoorModel model;

        private bool isworking;
        private int timer;

        public DoorView(DoorModel model = null)
        {
            this.model = model;
        }

        public void Draw(SpriteBatch spriteBatch,SpriteModel sprite, Helpers helpers)
        {
            if (model.doorCondition != 3 && timer < 180 && (isworking || (Keyboard.GetState().IsKeyDown(Keys.E) && sprite.Rectangle.Intersects(model.DoorDownLine))))
            {
                isworking = true;
                helpers.DrawHelpDoor(spriteBatch, sprite.Position);
                timer++;
            }
            else if (timer == 180)
            {
                isworking = false;
                timer = 0;
            }

            spriteBatch.Draw(model.doorTex,
                model.doorPos,
                new Rectangle(model.doorCondition * 384, 0, 384, model.doorTex.Height),
                Color.White,
                0,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                0);

            //spriteBatch.Draw(model.doorTex, model.DoorRightLine, Color.Blue);
        }

    }
}
