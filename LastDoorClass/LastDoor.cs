using GameFrst.Animation;
using GameFrst.Anotogonist;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrst.Sprite;
using GameFrst.HelpersClass;
using Microsoft.Xna.Framework.Input;
using System.Reflection;

namespace GameFrst.LastDoorClass
{
    public class LastDoor
    {
        public Texture2D textureClose;
        public Texture2D textureOpen;

        public SoundEffect effect;

        public bool CanGoRight;

        public bool isOpen;
        private int timer;
        private bool isworking;

        public LastDoor(Texture2D textureClose, Texture2D textureOpen, SoundEffect effect)
        {
            this.textureClose = textureClose;
            this.textureOpen = textureOpen;
            this.effect = effect;
        }

        public void Update(GameTime gameTime, AntogonistModel antogonistModel, SpriteModel sprite)
        {
            if (!isOpen && antogonistModel.victory)
            {
                isOpen = true;

                effect.Play();
            }

            if (!isOpen)
                sprite.CanGoRightDoor = sprite.Rectangle.Intersects(new Rectangle(6550, 2495, 28, 383)) ? false : true;
            else
                sprite.CanGoRightDoor = true;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch,SpriteModel sprite, Helpers helpers)
        {
            if (!isOpen)
            {
                spriteBatch.Draw(textureClose, new Vector2(6510, 2495), Color.White);
                if (timer < 180 && (isworking || (Keyboard.GetState().IsKeyDown(Keys.E) && sprite.Rectangle.Intersects(new Rectangle(6550, 2495, 28, 383)))))
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
            }
                
            else
                spriteBatch.Draw(textureOpen, new Vector2(6538, 2413), Color.White);
        }
    }
}
