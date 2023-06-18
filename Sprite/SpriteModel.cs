using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrst.Animation;
using GameFrst.InputClass;
using Microsoft.Xna.Framework.Input;
using GameFrst.AntogonistScreamer;

namespace GameFrst.Sprite
{
    public class SpriteModel
    {
        public Vector2 _position;

        protected Texture2D _texture;

        public Dictionary<string, AnimationModel> _animations;

        public AnimationModel _currentAnimation;
        public AnimationView _animationView;
        public AnimationController _animationController;

        public SpriteController controller;
        public SpriteView view;

        public Input input;

        public bool CanGoUp = true;
        public bool CanGoDown = true;
        public bool CanGoRight = true;
        public bool CanGoLeft = true;

        public bool CanGoUpDoor = true;
        public bool CanGoDownDoor = true;
        public bool CanGoRightDoor = true;


        public float Speed = 6f;
        public Vector2 Velocity;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (_animationView != null)
                    _animationView.Position = _position;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 178, 178);
            }
        }

        public SpriteModel(Dictionary<string, AnimationModel> animations)
        {
            _animations = animations;
            _currentAnimation = _animations.First().Value;

            _animationController = new AnimationController(_currentAnimation);
            _animationView = new AnimationView(_currentAnimation);

            controller = new SpriteController(this);
            view = new SpriteView(this);

            input = new Input();
        }
    }
}
