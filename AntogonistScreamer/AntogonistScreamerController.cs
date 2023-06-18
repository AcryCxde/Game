using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

namespace GameFrst.AntogonistScreamer
{
    public class AntogonistScreamerController
    {
        AntogonistScreamerModel _model;

        public AntogonistScreamerController(AntogonistScreamerModel model)
        {
            _model = model;
        }

        public virtual void Update(GameTime gameTime, Rectangle playerRect)
        {
            _model.newPosition = _model.position;

            if (!_model.isScream && playerRect.Intersects(new Rectangle((int)_model.position.X, (int)_model.position.Y, 10, _model.texture.Height - 200)))
            {
                _model.isScream = true;
                _model.soundEffect.Play();
                MediaPlayer.Pause();
            }


            if (_model.isScream && AntogonistScreamerModel.timer <= 90)
            {
                _model.newPosition += new Vector2(_model.random.Next(0, 10), _model.random.Next(0, 10));
                AntogonistScreamerModel.timer++;
            }
            if (AntogonistScreamerModel.timer == 90)
                MediaPlayer.Resume();

        }
    }
}
