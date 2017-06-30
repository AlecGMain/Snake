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

        public SnakePiece(Texture2D Image, Vector2 Position, Color Color) : base(Image, Position, Color)
        {

        }
    }
}
