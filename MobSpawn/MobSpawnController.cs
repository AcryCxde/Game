using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.MobSpawn
{
    public class MobSpawnController
    {
        public MobSpawnModel model;

        public MobSpawnController(MobSpawnModel model)
        {
            this.model = model;
        }

        public void Update(GameTime gameTime, Rectangle playerRect)
        {
            if (playerRect.Intersects(model.rectangle))
            {
                model.IsMobAtHome = true;
            }
        }
    }
}
