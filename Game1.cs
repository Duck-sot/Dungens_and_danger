
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
    private Platforms platforms;
    private Texture2D tempcruise;
    private Texture2D ground;
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
        player1 = new Player1(tempcruise, new Vector2(200, 620), 50, 27);
        GDevice = GraphicsDevice;
        ground = Content.Load<Texture2D>(assetName: "groundtile");
        platforms = new Platforms(ground, new Vector2(200, 780), 50);



        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        playerGrpundcolision();
        // TODO: Add your update logic here
        player1.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        player1.Draw(_spriteBatch);
        platforms.Draw(_spriteBatch);
        _spriteBatch.End();

        // TODO: Add your drawing code here


        base.Draw(gameTime);
    }

    private void playerGrpundcolision()
    {
        if (platforms.Hitbox.Intersects(player1.Hitbox))
        {
            player1.Grounded = true;
            player1.JumpA = true;
        }
        else
        {
            player1.Grounded = false;
        }
    }
}
 