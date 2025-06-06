using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungens_and_danger
{
    public class ProjectileP1L
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
        public ProjectileP1L(Texture2D texture, Vector2 spawnPosition)
        {
            position = spawnPosition;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 40, 40);
        }
        public void Update() {
            position.X += 25 ;
            hitbox.Location = position.ToPoint();
        }
        public void Draw(SpriteBatch spriteBatch){
            texture = Game1.CManager.Load<Texture2D>(assetName: "projectile");
            spriteBatch.Draw(texture,hitbox,Color.White);
        }
    }
}
