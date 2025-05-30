
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.X3DAudio;

namespace Dungens_and_danger
{
    public class Map
    { 
        private readonly RenderTarget2D _target;
        public static readonly int Tile_Size = 64;

        public static readonly int[,] tiles = {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        };
        private static Rectangle[,] hitbox {get;} = new Rectangle[tiles.GetLength(0), tiles.GetLength(1)];

        public Map()
        {
            _target = new(Game1.GDevice, tiles.GetLength(1) * Tile_Size, tiles.GetLength(0) * Tile_Size);

            var tile1texuer = (Game1.CManager.Load<Texture2D>("groundtile"));

            Game1.GDevice.SetRenderTarget(_target);
            Game1.GDevice.Clear(Color.Transparent);
            Game1.SpriteBatch.Begin();

            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    if (tiles[x, y] == 0) continue;
                    int posX = y * Tile_Size;
                    int posY = x * Tile_Size;
                    var tex = tiles[x, y] == 1 ? tile1texuer : null;
                    hitbox[x, y] = new(posX, posY, Tile_Size, Tile_Size);
                    Game1.SpriteBatch.Draw(tex, new Vector2(posX, posY), Color.White);
                }
            }
            Game1.SpriteBatch.End();
            Game1.GDevice.SetRenderTarget(null);
        }

        public static List<Rectangle> NerestHitbox(Rectangle bounds)
        {
            int leftTile = (int)Math.Floor((float)bounds.Left / Tile_Size);
            int rightTile = (int)Math.Ceiling((float)bounds.Right / Tile_Size);
            int topTile = (int)Math.Floor((float)bounds.Top / Tile_Size);
            int bottomTile = (int)Math.Ceiling((float)bounds.Bottom / Tile_Size);

            leftTile = MathHelper.Clamp(leftTile, 0, tiles.GetLength(1));
            rightTile = MathHelper.Clamp(rightTile, 0, tiles.GetLength(1));
            topTile = MathHelper.Clamp(topTile, 0, tiles.GetLength(0));
            bottomTile = MathHelper.Clamp(bottomTile, 0, tiles.GetLength(0));

            List<Rectangle> result = new();

            for (int x = topTile; x <= bottomTile; x++)
            {
                for (int y = leftTile; y <= rightTile; y++)
                {
                    if (tiles[x, y] != 0) result.Add(hitbox[x, y]);
                }
            }
            return result;
        }
        
        public void Draw()
        {
            Game1.SpriteBatch.Draw(_target, Vector2.Zero, Color.White);
        }

    }
}
