using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrst.Anotogonist;

namespace GameFrst.GarageFinal
{
    public class GarageFinalModel
    {
        public Texture2D texture;
        public Vector2 position;

        public float depth = 0.2f;

        public bool isReady;

        public static int GarageCondition;

        public GarageFinalController controller;
        public GarageFinalView view;

        public Rectangle rectangle => new Rectangle((int)position.X, (int)position.Y, texture.Width / 2, texture.Height);

        public GarageFinalModel(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;

            controller = new GarageFinalController(this);
            view = new GarageFinalView(this);
        }
    }
}
