using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameFrst.FloorElement
{
    public class FloorElementModel
    {
        public Texture2D tex;
        public float texX;
        public float texY;
        public string texSides;
        public int texWidth;
        public int texHeight;
        public bool Up = true;
        public bool Down = true;
        public bool Left = true;
        public bool Right = true;

        public FloorElementController controller;
        public FloorElementView view;

        public FloorElementModel(Texture2D texture)
        {
            tex = texture;
            texWidth = texture.Width;
            texHeight = texture.Height;

            texX = int.Parse(tex.ToString().Remove(0, 6).Split()[0]);
            texY = int.Parse(tex.ToString().Remove(0, 6).Split()[1]);
            texSides = tex.ToString().Remove(0, 6).Split()[2];

            // example of Name - "Floor/1344 8064 LDU"
            // "Floor/2112 8064 UR"

            controller = new FloorElementController(this);
            view = new FloorElementView(this);

        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)texX, (int)texY, texWidth, texHeight);
            }
        }
    }
}
