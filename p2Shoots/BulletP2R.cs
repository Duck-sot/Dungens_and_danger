using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Dungens_and_danger
{
    public class BulletP2R
    {
         private Texture2D texture;
        private Vector2 position; 
        private Rectangle hitbox;

        public Rectangle Hitbox
        {
            get { return hitbox; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public BulletP2R(Texture2D texture, Vector2 spawnPosition)
        {
            position = spawnPosition;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 60, 90);
        }
        public void Update() {
            position.X += 25 ;
            hitbox.Location = position.ToPoint();
        }
        public void Draw(SpriteBatch spriteBatch){
            texture = Game1.CManager.Load<Texture2D>(assetName: "Untitled");
            spriteBatch.Draw(texture,hitbox,Color.White);
        }
    }
}