using GameFrst.Sprite;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrst.InputClass;
using System.Reflection;

namespace Lab_n._12.CheatsClass
{
    public class Cheats
    {
        Texture2D texture;
        Vector2 position;

        Input input;

        public static bool wantOpenFrstDoor;
        public static bool wantOpenScndDoor;
        public static bool wantGodMode;

        public Cheats(Texture2D texture)
        {
            this.texture = texture;
            input = new Input();

        }

        public void Update(SpriteModel sprite)
        {
            input.Update();

            position = new Vector2(128,146) + sprite.Position;

            if(input.IsKeyPressed(Keys.G))
                wantGodMode = !wantGodMode;

            if (input.IsKeyPressed(Keys.N))
                wantOpenFrstDoor = !wantOpenFrstDoor;

            if (input.IsKeyPressed(Keys.M))
                wantOpenScndDoor = !wantOpenScndDoor;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (wantGodMode)
            {
                spriteBatch.Draw(texture,
                position ,
                new Rectangle(0, 0, texture.Width,45),
                Color.White,
                0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                        0);
            }

            if (wantOpenFrstDoor)
            {
                spriteBatch.Draw(texture,
                position + new Vector2(0, 45),
                new Rectangle(0, 45, texture.Width, 45),
                Color.White,
                0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                        0);
            }

            if (wantOpenScndDoor)
            {
                spriteBatch.Draw(texture,
                position + new Vector2(0, 90),
                new Rectangle(0, 90, texture.Width, 45),
                Color.White,
                0, Vector2.Zero,
                    1,
                    SpriteEffects.None,
                        0);
            }
        }
    }
}
