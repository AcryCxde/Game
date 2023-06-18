using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GameFrst.Door;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace GameFrst.Button
{
    public class ButtonController
    {
        ButtonModel model;
        public ButtonController(ButtonModel model)
        {
            this.model = model;
        }

        public void Update(DoorModel doorModel, Rectangle playerRect)
        {
            if (!model.isActive)
            {
                model.input.Update();

                if (playerRect.Intersects(new Rectangle((int)model.position.X, (int)model.position.Y, model.tex.Width / 2, model.tex.Height))
                && model.input.IsKeyPressed(Keys.E))
                {
                    model.soundEf.Play();
                    model.isActive = true;
                    doorModel.doorCondition++;
                }
            }
        }
    }
}
