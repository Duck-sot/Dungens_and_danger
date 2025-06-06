
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungens_and_danger
{
    public class Platforms
    {
        private Rectangle hitbox;
        private Vector2 position;
        private Texture2D texture;


        public Platforms(Texture2D texture, Vector2 position, int pixelSize)
        {
            this.position = position;
            this.texture = texture;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 1500, 64);
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle Hitbox
        {
            get{ return hitbox;}
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.NavajoWhite);
        }

    }
}