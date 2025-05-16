
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
    private Texture2D tempcruise;
    private Map _map; 
    public static GraphicsDevice GDevice;
    public static ContentManager CManager{ get; set; }
    public static SpriteBatch SpriteBatch { get; set; } 
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
        tempcruise = Content.Load<Texture2D>(assetName:"tempcruise");
        player1 = new Player1(tempcruise, new Vector2(70,720),50,27);
        GDevice = GraphicsDevice;
        _map = new();
        
        

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
            

        // TODO: Add your update logic here
        player1.Update();
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        player1.Draw(_spriteBatch);
        _map.Draw();
        _spriteBatch.End();

        // TODO: Add your drawing code here


        base.Draw(gameTime);
    }
}
 