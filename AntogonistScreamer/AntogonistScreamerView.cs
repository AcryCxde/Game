using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrst.AntogonistScreamer
{
    public class AntogonistScreamerView
    {
        AntogonistScreamerModel _model;

        public AntogonistScreamerView(AntogonistScreamerModel model)
        {
            _model = model;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (AntogonistScreamerModel.timer < 90)
            {
                if (_model.isScream)
                    spriteBatch.Draw(_model.texture,
                    _model.newPosition,
                    new Rectangle(_model.texture.Width / 2, 0, _model.texture.Width / 2, _model.texture.Height),
                    Color.White,
                    0, Vector2.Zero,
                    1,
                        SpriteEffects.None,
                        0);
                else
                    spriteBatch.Draw(_model.texture,
                    _model.position,
                    new Rectangle(0, 0, _model.texture.Width / 2, _model.texture.Height),
                        Color.White,
                        0, Vector2.Zero,
                        1,
                        SpriteEffects.None,
                        0);
            }
        }
    }
}
