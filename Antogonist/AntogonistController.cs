using GameFrst.Shoker;
using Lab_n._12.CheatsClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Anotogonist
{
    public class AntogonistController : ICanCollide
    {
        public AntogonistModel model;

        SoundEffectInstance sound;

        public AntogonistController(AntogonistModel model)
        {
            this.model = model;
            sound = model.soundEffect.CreateInstance();
            sound.Pitch = 0.4f;
        }

        public Rectangle Rectangle => model.Rectangle;
        public void UpdateFlagDoor(bool up, bool down)
        {
            model.CanGoDownDoor = down;
            model.CanGoUpDoor = up;
        }

        public void UpdateFlagFloor(bool up, bool down, bool right, bool left)
        {
            model.CanGoDown = down;
            model.CanGoLeft = left;
            model.CanGoUp = up;
            model.CanGoRight = right;
        }

        private void Move()
        {
            if (model.distance.X < 0)
            {
                if (model.CanGoLeft)
                    model.velocity.X = -6.5f;
            }
            else if (model.distance.X > 0)
            {
                if (model.CanGoRight)
                    model.velocity.X = 6.5f;
            }
            if (model.distance.Y > 0)
            {
                if (model.CanGoDown && model.CanGoDownDoor)
                    model.velocity.Y = 6.5f;
            }

            else if (model.distance.Y < 0)
            {
                if (model.CanGoUp && model.CanGoUpDoor)
                    model.velocity.Y = -6.5f;
            }
        }

        private bool start(Rectangle playerRect)
        {
            if (!model.hasStarted && playerRect.Intersects(new Rectangle(1152, 4353, 40, 384)))
                model.hasStarted = true; // Устанавливаем hasStarted в true при первом вхождении в условие

            return model.hasStarted;
        }

        public bool Freeze(GameTime gameTime)
        {
            if (ShokerModel.isFiring && model.Rectangle.Intersects(ShokerModel.rectangle))
            {
                model.isFreeze = true;
                model.freezeStartTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }

            if (model.isFreeze && (float)gameTime.TotalGameTime.TotalSeconds - model.freezeStartTime >= 5f)
            {
                model.isFreeze = false;
            }

            return model.isFreeze;
        }

        public void Update(GameTime gameTime, Vector2 playerPos, Rectangle playerRect)
        {
            if (!Freeze(gameTime))
            {
                AntogonistModel.IsKill = false;

                model.distance = playerPos - model.position;


                if (playerRect.Intersects(model.Rectangle4Kill) && !Cheats.wantGodMode)
                {
                    AntogonistModel.IsKill = true;
                    model.position = new Vector2(962, 4072);
                }

                if (start(playerRect) && !model.victory)
                {
                    if (Vector2.Distance(playerPos, model.position) != 0 && Vector2.Distance(playerPos, model.position) >= 100)
                        sound.Volume = 100 / Vector2.Distance(playerPos, model.position);
                    sound.Play();

                    Move();
                }
                model.position += model.velocity;
                model.velocity = Vector2.Zero;
            }
        }
    }
}
