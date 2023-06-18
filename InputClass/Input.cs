using Microsoft.Xna.Framework.Input;

namespace GameFrst.InputClass
{
    public class Input
    {

        public KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;


        public void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }
    }
}
