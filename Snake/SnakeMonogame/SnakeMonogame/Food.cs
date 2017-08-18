using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeMonogame
{
    class Food : Sprite
    {
        public Food(Texture2D Image, Vector2 Position, Color Color) : base(Image, Position, Color)
        {
        }
    }
}
