using Microsoft.Xna.Framework;
using GameFrst.Sprite;

namespace GameFrst.CameraClass
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(SpriteModel target)
        {
            var position = Matrix.CreateTranslation(
              -target.Position.X - target.Rectangle.Width / 2,
              -target.Position.Y - target.Rectangle.Height / 2,
              0);

            var offset = Matrix.CreateTranslation(
                Main.ScreenWidth / 2,
                Main.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}