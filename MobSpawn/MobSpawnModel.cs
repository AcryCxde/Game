using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.MobSpawn
{
    public class MobSpawnModel
    {
        public Texture2D texture;
        public Vector2 position;

        public bool IsMobAtHome;

        public MobSpawnController controller;
        public MobSpawnView view;

        public MobSpawnModel(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;

            controller = new MobSpawnController(this);
            view = new MobSpawnView(this);
        }
        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X + texture.Width / 2, (int)position.Y + texture.Height / 2, 30, 30);
            }
        }
    }
}
