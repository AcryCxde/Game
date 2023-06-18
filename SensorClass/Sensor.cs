using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GameFrst.InputClass;
using Microsoft.Xna.Framework.Input;
using GameFrst.Emeralds;
using GameFrst.GarageFinal;
using Microsoft.Xna.Framework.Audio;
using GameFrst.HelpersClass;
using GameFrst.Sprite;
using System.Threading;

namespace GameFrst.SensorClass
{
    public class Sensor
    {
        Texture2D texture;
        Vector2 position;
        SoundEffect soundEffect;

        public bool isActive;

        private bool isWorking;

        private int timer;

        Input input;

        public Sensor(Texture2D texture, Vector2 position, SoundEffect soundEf)
        {
            this.texture = texture;
            this.position = position;
            soundEffect = soundEf;

            input = new Input();
        }

        private Rectangle rectangle => new Rectangle((int)position.X, (int)position.Y, texture.Width / 2, texture.Height);

        public void Update(GameTime gameTime, Rectangle playerRect, EmeraldsModel emerald)
        {
            input.Update();
            if (!isActive && emerald.isPickedUp && playerRect.Intersects(rectangle) && input.IsKeyDown(Keys.E))
            {
                soundEffect.Play();
                isActive = true;
                GarageFinalModel.GarageCondition++;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch,Helpers helpers, SpriteModel sprite)
        {
            if (isActive)
                spriteBatch.Draw(texture,
                position,
                new Rectangle(texture.Width / 2, 0, texture.Width / 2, texture.Height),
                Color.White,
                0, Vector2.Zero,
                1,
                SpriteEffects.None,
                    0);
            else
            {
                spriteBatch.Draw(texture,
                position,
                new Rectangle(0, 0, texture.Width / 2, texture.Height),
                Color.White,
                0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);

                if (timer < 180 && (isWorking || (Keyboard.GetState().IsKeyDown(Keys.E) && sprite.Rectangle.Intersects(rectangle))))
                {
                    isWorking = true;
                    helpers.DrawHelpEmerlads(spriteBatch, sprite.Position);
                    timer++;
                }
                else if (timer == 180)
                {
                    isWorking = false;
                    timer = 0;
                }
            }
                
        }
    }
}
