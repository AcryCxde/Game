using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Animation
{
    public class AnimationController
    {
        private AnimationModel _animation;

        private float _timer;

        public AnimationController(AnimationModel animation)
        {
            _animation = animation;
        }

        public void Play(AnimationModel animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;

            _animation.CurrentFrame = 0;

            _timer = 0f;
        }

        public void Stop()
        {
            _timer = 0f;

            _animation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                    _animation.CurrentFrame = 0;
            }
        }
    }
}
