using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace GameFrst.Animation
{
    public class AnimationView
    {
        private AnimationModel _animation;
        public Vector2 Position;

        public AnimationView(AnimationModel animation)
        {
            _animation = animation;
        }

        public void Draw(SpriteBatch spriteBatch, AnimationModel animationModel)
        {
            _animation = animationModel;
            spriteBatch.Draw(_animation.Texture,
                             Position,
                             new Rectangle(_animation.CurrentFrame * _animation.FrameWidth,
                                           0,
                                           _animation.FrameWidth,
                                           _animation.FrameHeight),
                             Color.White);
        }
    }
}
