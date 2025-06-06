using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Dungens_and_danger
{
    public class Player2
    {
        private Texture2D textuer;
        private Vector2 position_;
        private Rectangle hitbox;
        private int hp;
        private KeyboardState newkstate;
        private KeyboardState oldkstate;
        private bool grounded = true;
        //private const int offset = 10;
        private float jump = 300f;
        private float mspeed = 10f;
        private bool jumpA = true;
        private List<BulletP2R> bulletP2Rs = new List<BulletP2R>();
        private List<BulletP2L> bulletP2s = new List<BulletP2L>();
        private List<BlunderShootR> blunderShootRs = new List<BlunderShootR>();
        private List<BlunderShootL> blunderShootLs = new List<BlunderShootL>();




        public List<BulletP2L> BulletP2s
        {
            get { return bulletP2s; }
        }
        public List<BulletP2R> BulletP2Rs
        {
            get { return bulletP2Rs; }
        }
        public List<BlunderShootL> BlunderShootLs
        {
            get { return blunderShootLs; }
        }
        public List<BlunderShootR> BlunderShootRs
        {
            get { return blunderShootRs; }
        }
        public Player2(Texture2D textuer, Vector2 position_, int pixelSize, int hp)
        {
            this.textuer = textuer;
            this.position_ = position_;
            this.hp = hp;
            hitbox = new Rectangle((int)position_.X, (int)position_.Y, 100, 140);

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
            foreach (BulletP2R p in bulletP2Rs)
            {
                p.Update();
            }
            foreach (BulletP2L l in bulletP2s)
            {
                l.Update();
            }
            foreach (BlunderShootR s in blunderShootRs)
            {
                s.Update();
            }
            foreach (BlunderShootL b in blunderShootLs)
            {
                b.Update();
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
            foreach (BulletP2R p in bulletP2Rs)
            {
                p.Draw(spriteBatch);
            }
            foreach (BulletP2L l in bulletP2s)
            {
                l.Draw(spriteBatch);
            }
            spriteBatch.Draw(textuer, hitbox, Color.NavajoWhite);
            foreach (BlunderShootR s in blunderShootRs)
            {
                s.Draw(spriteBatch);
            }
            foreach (BlunderShootL b in blunderShootLs)
            {
                b.Draw(spriteBatch);
            }
        }
        private void Move()
        {
            if (grounded == false)
            {
                position_.Y += 100 * Game1.Time;
            }
            if (newkstate.IsKeyDown(Keys.Up) && jumpA == true)
            {
                position_.Y -= jump;
                grounded = false;
                jumpA = false;
            }
            if (newkstate.IsKeyDown(Keys.Down) &&  grounded == false)
            {
                position_.Y += 50;
            }


            if (newkstate.IsKeyDown(Keys.Right))
            {
                position_.X += mspeed;
            }
            else if (newkstate.IsKeyDown(Keys.Left))
            {
                position_.X -= mspeed;
            }
            hitbox.Location = position_.ToPoint();
        }

        private void Shoot()
        {
            if (newkstate.IsKeyDown(Keys.RightShift) && oldkstate.IsKeyUp(Keys.RightShift))
            {
                BulletP2R bulletP2R = new BulletP2R(textuer, position_);
                bulletP2Rs.Add(bulletP2R);
            }
            if (newkstate.IsKeyDown(Keys.RightAlt) && oldkstate.IsKeyUp(Keys.RightAlt))
            {
                BulletP2L bulletP2L = new BulletP2L(textuer, position_);
                bulletP2s.Add(bulletP2L);
            }
            if (newkstate.IsKeyDown(Keys.RightControl) && oldkstate.IsKeyUp(Keys.RightControl))
            {
                BlunderShootL blunderShootL = new BlunderShootL(textuer, position_);
                blunderShootLs.Add(blunderShootL);
            }
            if (newkstate.IsKeyDown(Keys.Enter) && oldkstate.IsKeyUp(Keys.Enter))
            {
                BlunderShootR blunderShootR = new BlunderShootR(textuer, position_);
                blunderShootRs.Add(blunderShootR);
            }
        }
    }
}