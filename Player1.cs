

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Dungens_and_danger
{
    public class Player1
    {
        private Texture2D textuer;
        private Vector2 position_;
        private Rectangle hitbox;
        private int hp;
        private KeyboardState kstate;
        private bool grounded = true;
        //private const int offset = 10;
        private float jump = 300f;
        private float mspeed = 10f;
        private bool jumpA = true;
        private List<Projectil> projectils = new List<Projectil>();




        public List<Projectil> Projectils
        {
            get { return projectils; }
        }
        public Player1(Texture2D textuer, Vector2 position_, int pixelSize, int hp)
        {
            this.textuer = textuer;
            this.position_ = position_;
            this.hp = hp;
            hitbox = new Rectangle((int)position_.X, (int)position_.Y, 90, 140);

        }


        public Rectangle Hitbox
        {
            get { return hitbox; }
        }

        public void Update()
        {
            kstate = Keyboard.GetState();
            Move();
            Shoot();
            //UpdatePosition();
            foreach (Projectil p in projectils)
            {
                p.Update();
            }

        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public bool Grounded
        {
            get { return grounded; }
            set { grounded = value; }
        }
        public bool JumpA
        {
            get { return jumpA; }
            set { jumpA = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textuer, hitbox, Color.NavajoWhite);
            foreach (Projectil p in projectils)
            {
                p.Draw(spriteBatch);
            }
        }
        private void Move()
        {
            if (grounded == false)
            {
                position_.Y += 100 * Game1.Time;
            }
            if (kstate.IsKeyDown(Keys.W) && jumpA == true)
            {
                position_.Y -= jump;
                grounded = false;
                jumpA = false;
            }


            if (kstate.IsKeyDown(Keys.D))
            {
                position_.X += mspeed;
            }
            else if (kstate.IsKeyDown(Keys.A))
            {
                position_.X -= mspeed;
            }
            hitbox.Location = position_.ToPoint();
        }
        
        private void Shoot(){
            if (kstate.IsKeyDown(Keys.E) && kstate.IsKeyDown(Keys.D))
            {
                Projectil projectil = new Projectil(textuer, position_);
                projectils.Add(projectil);
            }
        }
    }





        /*private void UppdatePosition()
        {
            grounded = false;
            var newPos = position + (position_ * Game1.Time);
            Rectangle newRecta = mapCollison(newPos);

            foreach (var hitboxs in Map.NerestHitbox(newRecta))
            {
                if (newPos.X != position.X)
                {
                    newRecta = mapCollison(new(newPos.X, newPos.Y));
                    if (newRecta.Intersects(hitboxs))
                    {
                        if (newPos.X > position.X) newPos.X = hitboxs.Left - textuer.Width + offset;
                        else newPos.X = hitboxs.Right - offset;
                        continue;
                    }
                }
                newRecta = mapCollison(new(position.X, newPos.Y));
                if (newRecta.Intersects(hitboxs))
                {
                    if (position_.Y > 0)
                    {
                        newPos.Y = hitboxs.Top - textuer.Height;
                        grounded = true;
                        position_.Y = 0;
                    }
                    else
                    {
                        newPos.Y = hitboxs.Bottom;
                        position_.Y = 0;
                    }
                }
            }
            position = newPos;
        }
        */





        /*
      private Rectangle mapCollison(Vector2 posW)
      {
          return new((int)posW.X + offset, (int)posW.Y, textuer.Width - (2 * offset), textuer.Height);
      }
      */  // Jag hade problem med att få att kartan fungerar så jag komenterar ut de delarna så att det fins bevis på det samt kolla failuer för resten av kartan.

}

