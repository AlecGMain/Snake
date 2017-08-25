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
      
        public int Direction = 4;
        private Color color;



        public SnakePiece(Texture2D image, Vector2 position, Color color, int direction) 
            : base(image, position, color)
        {
          
        }
        public override void Update(GameTime gameTime)
        {
            if (Direction == 1)
            {
               position.Y += image.Height;
            }
            if (Direction == 2)
            {
                position.Y -= image.Height;
            }
            if (Direction == 3)
            {
                position.X -= image.Height;
            }
            if (Direction == 4)
            {
                position.X += image.Height;
            }
            base.Update(gameTime);
        }
    }
}
