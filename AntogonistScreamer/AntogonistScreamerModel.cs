using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.AntogonistScreamer
{
    public class AntogonistScreamerModel
    {
        public Texture2D texture;
        public Vector2 position;
        public SoundEffect soundEffect;
        public Vector2 newPosition;
        public static int timer;

        public Random random;

        public bool isScream;

        public AntogonistScreamerController controller;
        public AntogonistScreamerView view;
        public static int GetTimer() { return timer; }

        public AntogonistScreamerModel(Texture2D texture, Vector2 position, SoundEffect soundEffect)
        {
            this.texture = texture;
            this.position = position;
            this.soundEffect = soundEffect;

            random = new Random();

            controller = new AntogonistScreamerController(this);
            view = new AntogonistScreamerView(this);
        }
    }
}
