using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SnakeMonogame
{
    class SnakePiece : Sprite
    {
        public int Speed = 1;
        public SnakePiece(Texture2D image, Vector2 position, Color color, int speed) 
            : base(image, position, color)
        {
            Speed = speed;
        }
    }
}
