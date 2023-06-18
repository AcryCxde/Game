using GameFrst.InputClass;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace GameFrst.Button
{
    public class ButtonModel
    {
        public Texture2D tex;
        public Vector2 position;
        public SoundEffect soundEf;

        public Input input;

        public bool isActive = false;

        public ButtonController controller;
        public ButtonView view;

        public ButtonModel(Texture2D tex, Vector2 position, SoundEffect song)
        {
            this.tex = tex;
            this.position = position;
            soundEf = song;

            input = new Input();

            controller = new ButtonController(this);
            view = new ButtonView(this);
        }
    }
}
