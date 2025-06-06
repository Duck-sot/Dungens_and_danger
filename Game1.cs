
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungens_and_danger;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player1 player1;
    private Player2 player2;
    private Platforms platforms;
    private Texture2D tempcruise;
    private Texture2D gus;
    private Texture2D ground;
    private FlyingP right;
    private FlyingP mid;
    private FlyingP left;
    //private Map _map;
    public static GraphicsDevice GDevice;
    public static ContentManager CManager { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static float Time { get; set; }

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        CManager = Content;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        SpriteBatch = _spriteBatch;
        tempcruise = Content.Load<Texture2D>(assetName: "tempcruise");
        player1 = new Player1(tempcruise, new Vector2(200, 620), 50, 1000);
        GDevice = GraphicsDevice;
        ground = Content.Load<Texture2D>(assetName: "groundtile");
        platforms = new Platforms(ground, new Vector2(100, 780), 50);
        gus = Content.Load<Texture2D>(assetName: "TrainP2");
        player2 = new Player2(gus, new Vector2(1680, 620), 50, 1000);
        right = new FlyingP(ground, new Vector2(1500, 450), 50);
        mid = new FlyingP(ground, new Vector2(845, 200), 50);
        left = new FlyingP(ground, new Vector2(420, 450), 50);



        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        player1Grpundcolision();
        player2Groundcolison();
        player1ShootsHit();
        Player2ShootsHit();
        // TODO: Add your update logic here
        player1.Update();
        player2.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        player1.Draw(_spriteBatch);
        platforms.Draw(_spriteBatch);
        player2.Draw(_spriteBatch);
        left.Draw(_spriteBatch);
        mid.Draw(_spriteBatch);
        right.Draw(_spriteBatch);
        _spriteBatch.End();

        // TODO: Add your drawing code here


        base.Draw(gameTime);
    }

    private void player1Grpundcolision()
    {
        if (platforms.Hitbox.Intersects(player1.Hitbox)||right.Hitbox.Intersects(player1.Hitbox)||left.Hitbox.Intersects(player1.Hitbox)||mid.Hitbox.Intersects(player1.Hitbox))
        {
            player1.Grounded = true;
            player1.JumpA = true;
        }
        else
        {
            player1.Grounded = false;
        }
    }
    private void player2Groundcolison()
    {
        if (platforms.Hitbox.Intersects(player2.Hitbox )|| right.Hitbox.Intersects(player2.Hitbox)||mid.Hitbox.Intersects(player2.Hitbox)|| left.Hitbox.Intersects(player2.Hitbox))
        {
            player2.Grounded = true;
            player2.JumpA = true;
        }
        else
        {
            player2.Grounded = false;
        }
    }

    private void player1ShootsHit()
    {
        for (int j = 0; j < player1.Projectils.Count; j++)
        {
            if (player2.Hitbox.Intersects(player1.Projectils[j].Hitbox))
            {
                player2.Hp -= 90;
                player1.Projectils.RemoveAt(j);
                j--;
                if (player2.Hp <= 0)
                {
                    Exit();
                }
            }
        }
        for (int l = 0; l < player1.ProjectileP1s.Count; l++)
        {
            if (player2.Hitbox.Intersects(player1.ProjectileP1s[l].Hitbox))
            {
                player2.Hp -= 90;
                player1.ProjectileP1s.RemoveAt(l);
                l--;
                if (player2.Hp <= 0)
                {
                    Exit();
                }
            }
        }
        for (int p = 0; p < player1.P1ShootUps.Count; p++)
        {
            if (player2.Hitbox.Intersects(player1.P1ShootUps[p].Hitbox))
            {
                player2.Hp -= 90;
                player1.P1ShootUps.RemoveAt(p);
                p--;
                if (player2.Hp <= 0)
                {
                    Exit();
                }
            }
        }
        for (int o = 0; o < player1.P1ShootDos.Count; o++)
        {
            if (player2.Hitbox.Intersects(player1.P1ShootDos[o].Hitbox))
            {
                player2.Hp -= 90;
                player1.P1ShootDos.RemoveAt(o);
                o--;
                if (player2.Hp <= 0)
                {
                    Exit();
                }
            }
        }
    }
    private void Player2ShootsHit()
    {
        for (int b = 0; b < player2.BulletP2Rs.Count; b++)
        {
            if (player1.Hitbox.Intersects(player2.BulletP2Rs[b].Hitbox))
            {
                player1.Hp -= 70;
                player2.BulletP2Rs.RemoveAt(b);
                b--;
                if (player1.Hp <= 0)
                {
                    Exit();
                }
            }
        }
        for (int s = 0; s < player2.BulletP2s.Count; s++)
        {
            if (player1.Hitbox.Intersects(player2.BulletP2s[s].Hitbox))
            {
                player1.Hp -= 70;
                player2.BulletP2s.RemoveAt(s);
                s--;
                if (player1.Hp <= 0)
                {
                    Exit();
                }
            }
        }
        for (int x = 0; x < player2.BlunderShootLs.Count; x++)
        {
            if (player1.Hitbox.Intersects(player2.BlunderShootLs[x].Hitbox))
            {
                player1.Hp -= 40;
                player2.BlunderShootLs.RemoveAt(x);
                x--;
                if (player1.Hp <= 0)
                {
                    Exit();
                }
                
            }
        }
        for (int z = 0; z < player2.BlunderShootRs.Count; z++)
        {
            if (player1.Hitbox.Intersects(player2.BlunderShootRs[z].Hitbox))
            {
                player1.Hp -= 40;

                player2.BlunderShootRs.RemoveAt(z);
                z--;
                if (player1.Hp <= 0)
                {
                    Exit();
                }
            }
        }
    }
}
 
 