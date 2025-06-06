

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
        private KeyboardState newkstate;
        private KeyboardState oldkstate; 
        private bool grounded = true;
        //private const int offset = 10;
        private float jump = 400f;
        private float mspeed = 10f;
        private bool jumpA = true;
        private List<Projectil> projectils = new List<Projectil>();
        private List<ProjectileP1L> projectileP1s = new List<ProjectileP1L>();
        private List<P1ShootDo> p1ShootDos = new List<P1ShootDo>();
        private List<P1ShootUp> p1ShootUps = new List<P1ShootUp>();


        public Vector2 Position_
        {
            get { return position_; }
            set { position_ = value; }
        }

        public List<Projectil> Projectils
        {
            get { return projectils; }
        }
        public List<ProjectileP1L> ProjectileP1s
        {
            get { return projectileP1s; }
        }
        public List<P1ShootDo> P1ShootDos
        {
            get { return p1ShootDos; }
        }
        public List<P1ShootUp> P1ShootUps
        {
            get { return p1ShootUps; }
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
            newkstate = Keyboard.GetState();
            Move();
            Shoot();
            //UpdatePosition();
            oldkstate = newkstate;
            foreach (Projectil p in projectils)
            {
                p.Update();
            }
            foreach (ProjectileP1L l in projectileP1s)
            {
                l.Update();
            }
             foreach (P1ShootUp d in p1ShootUps)
            {
                d.Update();
            }
            foreach (P1ShootDo u in p1ShootDos)
            {
                u.Update();
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
            foreach (ProjectileP1L l in projectileP1s)
            {
                l.Draw(spriteBatch);
            }
            foreach (P1ShootUp d in p1ShootUps)
            {
                d.Draw(spriteBatch);
            }
            foreach (P1ShootDo u in p1ShootDos)
            {
                u.Draw(spriteBatch);
            }
        }
        private void Move()
        {
            if (grounded == false)
            {
                position_.Y += 80 * Game1.Time;
            }
            if (newkstate.IsKeyDown(Keys.W) && jumpA == true)
            {
                position_.Y -= jump;
                grounded = false;
                jumpA = false;
            }


            if (newkstate.IsKeyDown(Keys.D))
            {
                position_.X += mspeed;
            }
            else if (newkstate.IsKeyDown(Keys.A))
            {
                position_.X -= mspeed;
            }
            hitbox.Location = position_.ToPoint();
        }

        private void Shoot()
        {
            if (newkstate.IsKeyDown(Keys.V) &&  oldkstate.IsKeyUp(Keys.V))
            {
                Projectil projectil = new Projectil(textuer, position_);
                projectils.Add(projectil);
            }
            if (newkstate.IsKeyDown(Keys.B) && oldkstate.IsKeyUp(Keys.B))
            {
                ProjectileP1L projectileP1 = new ProjectileP1L(textuer, position_);
                projectileP1s.Add(projectileP1);
            }
            if (newkstate.IsKeyDown(Keys.Space) && oldkstate.IsKeyUp(Keys.Space))
            {
                P1ShootUp p1ShootUp = new P1ShootUp(textuer, position_);
                p1ShootUps.Add(p1ShootUp);
            }
            if (newkstate.IsKeyDown(Keys.N) && oldkstate.IsKeyUp(Keys.N))
            {
                P1ShootDo p1ShootDo = new P1ShootDo(textuer, position_);
                p1ShootDos.Add(p1ShootDo);
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

