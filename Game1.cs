using GameFrst.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection;

namespace GameFrst
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pers1; //
        Texture2D stena; //
        float speed = 3f;
        Vector2 pers1Pos;
       


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        // Выполняет начальную инициализацию игры
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1024; // Ширина окна
            graphics.PreferredBackBufferHeight = 768; // Длина окна
            graphics.ApplyChanges();                  // Принимаем изменения
            base.Initialize();
        }

        // Загружает ресурсы игры
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pers1 = Content.Load<Texture2D>("pers1"); //
            stena = Content.Load<Texture2D>("stena"); //

        }

        // Вызывается при завершении игры для выгрузки использованных ресурсов
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                pers1Pos.Y -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                pers1Pos.X -= speed;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                pers1Pos.Y += speed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                pers1Pos.X += speed;
            }

            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            spriteBatch.Draw(pers1, pers1Pos, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}