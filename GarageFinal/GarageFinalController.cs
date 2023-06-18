using GameFrst.Anotogonist;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.GarageFinal
{
    public class GarageFinalController
    {
        GarageFinalModel model;
        public GarageFinalController(GarageFinalModel model)
        {
            this.model = model;
        }

        public void Update(GameTime gameTime, AntogonistModel antogonist)
        {
            if (GarageFinalModel.GarageCondition == 4)
                model.isReady = true;
        }
    }
}
