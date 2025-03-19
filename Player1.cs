using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation.DirectX;

namespace Dungens_and_danger
{
    public class Player1
    {
        private Texture2D textuer;
        private Vector2 position; 
        private Rectangle hitbox; 
        private int hp; 

        public int Hp{
            get{return hp;}
            set{hp = value;}
        }

        
    }
}