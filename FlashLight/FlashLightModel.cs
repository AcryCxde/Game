using GameFrst.InputClass;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameFrst.FlashLight
{
    public class FlashLightModel
    {
        public Texture2D texture;
        public Vector2 position;

        public static bool IsActive;

        public Input input;

        public FlashLightController controller;
        public FlashLightView view;

        public FlashLightModel(Texture2D texture)
        {
            this.texture = texture;

            input = new Input();

            controller = new FlashLightController(this);
            view = new FlashLightView(this);
        }
    }
}
