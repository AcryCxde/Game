using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace GameFrst.Anotogonist
{
    public class AntogonistModel
    {
        public Vector2 position;
        public Texture2D texture;
        public SoundEffect soundEffect;


        public Vector2 distance;
        public Vector2 velocity;

        public bool CanGoUp = true;
        public bool CanGoDown = true;
        public bool CanGoLeft = true;
        public bool CanGoRight = true;

        public bool CanGoUpDoor = true;
        public bool CanGoDownDoor = true;

        public bool isFreeze;
        public float freezeStartTime = 0f;

        public bool hasStarted = false;

        public bool victory;

        public static bool IsKill;

        public AntogonistController controller;
        public AntogonistView view;


        public Rectangle Rectangle4Kill => new Rectangle((int)position.X + texture.Width / 4 - 50, (int)position.Y + texture.Height / 2 - 50, 50, 50);
        public Rectangle Rectangle => new Rectangle((int)position.X, (int)position.Y, texture.Width / 2, texture.Height);
        public Rectangle Rectangle4Platform => new Rectangle((int)position.X, (int)position.Y + texture.Height, texture.Width / 2, 2);

        public AntogonistModel(Texture2D texture,Vector2 position, SoundEffect sound)
        {
            this.texture = texture;
            this.position = position;
            soundEffect = sound;

            controller = new AntogonistController(this);
            view = new AntogonistView(this);
        }
    }
}
