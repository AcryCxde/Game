using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.HelpersClass
{
    public class Helpers
    {
        public Texture2D texture;

        public Helpers(Texture2D texture)
        {
            this.texture = texture;
        }

        public void DrawHelpEmerlads(SpriteBatch spriteBatch,Vector2 playerPos)
        {
            spriteBatch.Draw(texture,
                    new Vector2(playerPos.X - 144, playerPos.Y + 178),
                    new Rectangle(0, 0, texture.Width / 3, texture.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);
        }

        public void DrawHelpDoor(SpriteBatch spriteBatch, Vector2 playerPos)
        {
            spriteBatch.Draw(texture,
                    new Vector2(playerPos.X - 144, playerPos.Y + 178),
                    new Rectangle(texture.Width / 3, 0, texture.Width / 3, texture.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);
        }

        public void DrawHelpMachine(SpriteBatch spriteBatch, Vector2 playerPos)
        {
            spriteBatch.Draw(texture,
                    new Vector2(playerPos.X - 144, playerPos.Y + 178),
                    new Rectangle(texture.Width / 3 * 2, 0, texture.Width / 3, texture.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    0);
        }
    }
}
