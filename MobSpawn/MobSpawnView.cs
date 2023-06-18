using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameFrst.MobSpawn
{
    public class MobSpawnView
    {
        public MobSpawnModel model;

        public MobSpawnView(MobSpawnModel model)
        {
            this.model = model;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(model.texture, model.position, Color.White);
            //spriteBatch.Draw(texture, rectangle,Color.Red);
        }
    }
}
