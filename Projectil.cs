using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Dungens_and_danger
{
    public class Projectil
    {
        private Texture2D texture;
        private Vector2 position; 
        private Rectangle hitbox;
        private int bounce;

        /*public int Bounce
        {
            
        }
        */
        public Rectangle Hitbox
        {
            get { return hitbox; }
        } 
        public Projectil(Texture2D texture,Vector2 spawnPosition){
            this.texture = texture; 
            position = spawnPosition;
            hitbox = new Rectangle((int)position.X,(int)position.Y,10,10);
        }
        public void Update() {
            hitbox.Location = position.ToPoint();
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,hitbox,Color.White);
        }
    }
}