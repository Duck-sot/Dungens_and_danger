
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Dungens_and_danger
{
    public class Player1
    {
        private Texture2D textuer;
        private Vector2 position; 
        private Rectangle hitbox; 
        private int hp; 
        private KeyboardState kstate;
        private bool grounded = true;
        

        public Player1(Texture2D textuer, Vector2 position, int pixelSize, int hp)
        {
            this.textuer = textuer;
            this.position = position;
            this.hp = hp;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 160, 160);

        }


        public void Update() {
            kstate = Keyboard.GetState();
            Move();

        }
        public int Hp{
            get{return hp;}
            set{hp = value;}
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(textuer,hitbox,Color.NavajoWhite);
        }
        private void Move(){
            if (kstate.IsKeyDown(Keys.W) && grounded == true)
            {
                position.Y += 50;
                grounded = false;
            }
            

            if (kstate.IsKeyDown(Keys.D))
            {
                position.X += 10;
            }
            else if (kstate.IsKeyDown(Keys.A))
            {
                position.X -= 10;
            }
            hitbox.Location = position.ToPoint(); 
        }
        /*
        private void Shoot(){
            if(kstate.IsKeyDown(Keys.E)){
                Projectil projectil = new Projectil(textuer,position);
                foreach(Projectil p in projectil){
                    
                }
            }
        }
        */
    }
}