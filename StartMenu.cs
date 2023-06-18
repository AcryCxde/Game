using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameFrst.InputClass;
using Microsoft.Xna.Framework.Input;
using System.Reflection;
using Microsoft.Xna.Framework.Media;

namespace GameFrst
{
    public class StartMenu
    {
        public Texture2D texture;
        public Song song;

        public Input input;

        public bool isStart;

        public int menuCondition;

        private double currentGameTime;

        private bool IsPlaying;

        public StartMenu(Texture2D texture,Song song)
        {
            this.texture = texture;
            this.song = song;

            input = new Input();
        }

        public void Update(GameTime gameTime)
        {
            input.Update();

            if (menuCondition == 0)
            {
                if (input.IsKeyPressed(Keys.Enter))
                {
                    menuCondition = 2;
                    currentGameTime = gameTime.TotalGameTime.TotalSeconds;
                }
                if (input.IsKeyDown(Keys.Down))
                    menuCondition = 1;
            }

            if (menuCondition == 1)
            {
                if (input.IsKeyDown(Keys.Up))
                    menuCondition = 0;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    Main.exit = true;
            }

            if (menuCondition == 2)
            {
                if (gameTime.TotalGameTime.TotalSeconds - currentGameTime >= 1)
                    if (!isStart && input.IsKeyPressed(Keys.Enter))
                        isStart = true;
            }

            if (!IsPlaying)
            {
                MediaPlayer.Play(song);
                IsPlaying = true;
            }

            
                

        }

        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(texture,
            Vector2.Zero,
            new Rectangle(menuCondition * texture.Width / 3, 0, texture.Width / 3, texture.Height),
            Color.White,
            0,
            Vector2.Zero,
            1,
            SpriteEffects.None,
            0);

            spriteBatch.End();
        }
    }
}
