using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GameFrst.Emeralds
{
    public class EmeraldsModel
    {
        public Texture2D texture;
        public Vector2 position;

        public bool isPickedUp;

        public EmeraldsController controller;
        public EmeraldsView view;

        public EmeraldsModel(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;

            controller = new EmeraldsController(this);
            view = new EmeraldsView(this);
        }

        public Rectangle rectangle => new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
    }
}
