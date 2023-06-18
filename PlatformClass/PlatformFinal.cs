using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameFrst.Anotogonist;
using GameFrst.Door;
using GameFrst.GarageFinal;

namespace GameFrst.PlatformClass
{
    public class PlatformFinal
    {
        Texture2D texture;
        Vector2 position;

        public PlatformFinal(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        private Rectangle rectangle => new Rectangle((int)position.X, (int)position.Y + texture.Height, texture.Width, 2);

        public void Update(AntogonistModel antogonist)
        {
            if (GarageFinalModel.GarageCondition == 4 && antogonist.Rectangle4Platform.Intersects(rectangle))
            {
                antogonist.victory = true;

                if (position.X != 4500)
                {
                    antogonist.position.X--;
                    position.X--;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

            //spriteBatch.Draw(texture, rectangle, Color.Red);
        }
    }
}
