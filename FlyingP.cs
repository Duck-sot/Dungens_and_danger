using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungens_and_danger
{
    public class FlyingP
    {
        private Rectangle hitbox;
        private Vector2 position;
        private Texture2D texture;


        public FlyingP(Texture2D texture, Vector2 position, int pixelSize)
        {
            this.position = position;
            this.texture = texture;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 250, 64);
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.NavajoWhite);
        }
    }
}