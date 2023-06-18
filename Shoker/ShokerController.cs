using GameFrst.Anotogonist;
using GameFrst.InputClass;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Shoker
{
    public class ShokerController
    {

        public ShokerModel model;

        public ShokerController(ShokerModel model)
        {
            this.model = model;
        }

        public static bool Start(GameTime gameTime)
        {
            if (AntogonistModel.IsKill)
                return true;
            float currentGameTime = (float)gameTime.TotalGameTime.TotalSeconds;

            if (ShokerModel.input.IsKeyPressed(Keys.Space))
            {
                if (!ShokerModel.isFiring && currentGameTime - ShokerModel.lastShotTime >= 10f)
                {
                    ShokerModel.isFiring = true;
                    ShokerModel.firingStartTime = currentGameTime;
                }
            }

            if (ShokerModel.isFiring && currentGameTime - ShokerModel.firingStartTime >= 1f)
            {
                ShokerModel.isFiring = false;
                ShokerModel.lastShotTime = currentGameTime;
            }

            return ShokerModel.isFiring;
        }

        private void ChooseSide()
        {
            if (ShokerModel.input.IsKeyDown(Keys.A))
            {
                model.currentTex = model.shokerDict["shokerL"];
                model.currentShift = model.LShift;
            }

            else if (ShokerModel.input.IsKeyDown(Keys.S))
            {
                model.currentTex = model.shokerDict["shokerUD"];
                model.currentShift = model.DShift;
            }

            else if (ShokerModel.input.IsKeyDown(Keys.W))
            {
                model.currentTex = model.shokerDict["shokerUD"];
                model.currentShift = model.UShift;
            }

            else if (ShokerModel.input.IsKeyDown(Keys.D))
            {
                model.currentTex = model.shokerDict["shokerR"];
                model.currentShift = model.RShift;
            }

            else if (model.currentTex == null)
            {
                model.currentTex = model.shokerDict["shokerUD"];
                model.currentShift = model.UShift;
            }
        }
        public void Update(GameTime gameTime, Vector2 playerPos)
        {
            ShokerModel.input.Update();
            ChooseSide();

            model.shokerPos = playerPos + model.currentShift;
            ShokerModel.rectangle = new Rectangle((int)model.shokerPos.X, (int)model.shokerPos.Y, model.currentTex.Width / 2, model.currentTex.Height);
        }
    }
}
