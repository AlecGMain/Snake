using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeMonogame
{
    
    class SnakeHead : SnakePiece
    {
        
        public SnakeHead(Texture2D Image, Vector2 Position, Color Color, Direction direction) : base(Image, Position, Color, direction)
        {

        }


    }
}
