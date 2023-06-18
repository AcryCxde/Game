using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.NPCClass
{
    public class NPC
    {
        Texture2D texture;
        Vector2 position;

        public NPC(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X + texture.Width / 2, (int)position.Y + texture.Height - 100, 5, 100);
            }
        }

        public void Update(GameTime gameTime, Rectangle playerRect, bool IsMobAtHome)
        {
            if (!IsMobAtHome)
            {
                if (playerRect.Intersects(
                    new Rectangle((int)position.X + texture.Width / 2 - 10, (int)position.Y + texture.Height / 2, 1, 1))
                    && Keyboard.GetState().IsKeyDown(Keys.D))

                    position.X += 6f;

                if (playerRect.Intersects(
                    new Rectangle((int)position.X + texture.Width / 2 + 10, (int)position.Y + texture.Height / 2, 1, 1))
                    && Keyboard.GetState().IsKeyDown(Keys.A))

                    position.X -= 6f;

                if (playerRect.Intersects(
                    new Rectangle((int)position.X + texture.Width / 2, (int)position.Y + texture.Height / 2 + 10, 1, 1))
                    && Keyboard.GetState().IsKeyDown(Keys.W))

                    position.Y -= 6f;

                if (playerRect.Intersects(
                    new Rectangle((int)position.X + texture.Width / 2, (int)position.Y + texture.Height / 2 - 10, 1, 1))
                    && Keyboard.GetState().IsKeyDown(Keys.S))

                    position.Y += 6f;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            //spriteBatch.Draw(texture, rectangle, Color.Blue);
        }
    }
}
