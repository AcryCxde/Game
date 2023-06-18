using GameFrst.Anotogonist;
using GameFrst.InputClass;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.FlashLight
{
    public class FlashLightController
    {
        FlashLightModel model;

        public FlashLightController(FlashLightModel model)
        {
            this.model = model;
        }

        public void Update(GameTime gameTime, Vector2 playerPos)
        {
            model.input.Update();

            model.position = new Vector2(playerPos.X - 523, playerPos.Y - 390);


            if (model.input.IsKeyPressed(Keys.F))
                FlashLightModel.IsActive = !FlashLightModel.IsActive;
        }
    }
}
