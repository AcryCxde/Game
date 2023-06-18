using GameFrst.InputClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameFrst.FlashLight;

namespace GameFrst.Icons
{
    public class IconsModel
    {
        public Texture2D texShoker;
        public Texture2D texLight;

        public Vector2 posShoker;
        public Vector2 posLight;

        public Input input;

        public IconsController controller;
        public IconsView view;
        public IconsModel(Texture2D texShoker, Texture2D texLight)
        {
            this.texShoker = texShoker;
            this.texLight = texLight;
            input = new Input();

            controller = new IconsController(this);
            view = new IconsView(this);
        }
    }
}
