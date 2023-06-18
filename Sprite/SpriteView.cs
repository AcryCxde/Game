using GameFrst.Animation;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.Sprite
{
    public class SpriteView
    {
        private SpriteModel model;
        public SpriteView(SpriteModel SpriteModel)
        {
            model = SpriteModel;
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (model._animationView != null)
                model._animationView.Draw(spriteBatch, model._currentAnimation);

        }
    }
}
