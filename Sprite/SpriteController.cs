using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using GameFrst.AntogonistScreamer;
using GameFrst.Door;
using GameFrst.Anotogonist;
using GameFrst.FlashLight;

namespace GameFrst.Sprite 
{
    public class SpriteController : ICanCollide
    {
        private SpriteModel model;

        public Rectangle Rectangle => model.Rectangle;

        public SpriteController(SpriteModel spriteModel)
        {
            model = spriteModel;
        }

        public virtual void UpdateFlagFloor(bool Up, bool Down, bool Right, bool Left)
        {
            model.CanGoUp = Up;
            model.CanGoDown = Down;
            model.CanGoLeft = Left;
            model.CanGoRight = Right;
        }

        public virtual void UpdateFlagDoor(bool Up, bool Down)
        {
            model.CanGoUpDoor = Up;
            model.CanGoDownDoor = Down;
        }


        public virtual void Move()
        {
            if (model.input.IsKeyDown(Keys.W))
            {
                if (model.CanGoUp && model.CanGoUpDoor)
                    model.Velocity.Y = -model.Speed;
            }
            else if (model.input.IsKeyDown(Keys.S))
            {
                if (model.CanGoDown && model.CanGoDownDoor)
                    model.Velocity.Y = model.Speed;
            }

            else if (model.input.IsKeyDown(Keys.A))
            {
                if (model.CanGoLeft)
                    model.Velocity.X = -model.Speed;
            }

            else if (model.input.IsKeyDown(Keys.D))
            {
                if (model.CanGoRight && model.CanGoRightDoor)
                    model.Velocity.X = model.Speed;
            }
        }

        protected virtual void SetAnimations()
        {
            if (model.Velocity.X > 0)
                model._currentAnimation = model._animations["MoveRight"];
            else if (model.Velocity.X < 0)
                model._currentAnimation = model._animations["MoveLeft"];
            else if (model.Velocity.Y > 0)
                model._currentAnimation = model._animations["MoveDown"];
            else if (model.Velocity.Y < 0)
                model._currentAnimation = model._animations["MoveUp"];
            else model._animationController.Stop();

            model._animationController.Play(model._currentAnimation);
        }

        public virtual void Update(GameTime gameTime,DoorModel doorModel)
        {
            model.input.Update();

            if (AntogonistScreamerModel.GetTimer() == 90 || AntogonistModel.IsKill)
            {
                model._position = new Vector2(4142, 6158);
                FlashLightModel.IsActive = false;
                doorModel.doorCondition = 0;
            }


            Move();

            SetAnimations();

            model._animationController.Update(gameTime);


            model.Position += model.Velocity;
            model.Velocity = Vector2.Zero;
        }
    }
}
