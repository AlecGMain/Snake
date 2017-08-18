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
        
        public SnakeHead(Texture2D Image, Vector2 Position, Color Color) : base(Image, Position, Color)
        {

        }
        public void Move(KeyboardState ks, Keys Up, Keys Down, Keys Left, Keys Right)
        {
            if(ks.IsKeyDown(Up))
            {
                Direction = 2;
            }
            else if (ks.IsKeyDown(Down))
            {
                Direction = 1;

            }
            else if(ks.IsKeyDown(Left))
            {
                Direction = 3;
            }
            else if(ks.IsKeyDown(Right))
            {
                Direction = 4;
            }
        }

    }
}
