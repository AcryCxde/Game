using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Door
{
    public class DoorModel
    {
        public Texture2D doorTex;
        public Vector2 doorPos;
        public int doorCondition;

        public bool CanGoUp = true;
        public bool CanGoDown = true;
        public bool CanGoRight = false;

        public DoorController controller;
        public DoorView view;

        public DoorModel(Texture2D doorTex, Vector2 doorPos)
        {
            this.doorTex = doorTex;
            this.doorPos = doorPos;

            controller = new DoorController(this);
            view = new DoorView(this);
        }

        public Rectangle DoorDownLine
        {
            get
            {
                return new Rectangle((int)doorPos.X, (int)doorPos.Y + 110, doorTex.Width / 4, 5);
            }
        }
        public Rectangle DoorUpLine
        {
            get
            {
                return new Rectangle((int)doorPos.X, (int)doorPos.Y, doorTex.Width / 4, 5);
            }
        }

        public Rectangle DoorRightLine
        {
            get
            {
                return new Rectangle((int)doorPos.X, (int)doorPos.Y, 5, doorTex.Height);
            }
        }


    }
}
