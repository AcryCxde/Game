using GameFrst.HelpersClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Door
{
    public class DoorController
    {
        private DoorModel model;

        public DoorController(DoorModel model = null)
        {
            this.model = model;
        }

        public void Update(DoorModel doorModel, Rectangle playerRect)
        {
            if (doorModel.doorCondition != 3)
            {
                model.CanGoUp = playerRect.Intersects(model.DoorDownLine) ? false : true;
                model.CanGoDown = playerRect.Intersects(model.DoorUpLine) ? false : true;
                model.CanGoRight = playerRect.Intersects(model.DoorRightLine) ? false : true;
            }
        }

    }
}
