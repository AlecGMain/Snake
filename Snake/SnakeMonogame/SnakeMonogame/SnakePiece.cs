using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnakeMonogame
{
    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    }
    class SnakePiece : Sprite
    {
      
        public Direction Direction = Direction.Right;
        private Color color;



        public SnakePiece(Texture2D image, Vector2 position, Color color, Direction direction) 
            : base(image, position, color)
        {
            Direction = direction;
        }
        public override void Update(GameTime gameTime)
        {
            if (Direction == Direction.Down)
            {
               position.Y += image.Height;
            }
            if (Direction == Direction.Up)
            {
                position.Y -= image.Height;
            }
            if (Direction == Direction.Left)
            {
                position.X -= image.Width;
            }
            if (Direction == Direction.Right)
            {
                position.X += image.Width;
            }
            base.Update(gameTime);
        
        }
        public void Move(KeyboardState ks, Keys Up, Keys Down, Keys Left, Keys Right)
        {
            if (ks.IsKeyDown(Up))
            {
                Direction = Direction.Up;
            }
            else if (ks.IsKeyDown(Down))
            {
                Direction = Direction.Down;

            }
            else if (ks.IsKeyDown(Left))
            {
                Direction = Direction.Left;
            }
            else if (ks.IsKeyDown(Right))
            {
                Direction = Direction.Right;
            }
        }
    }
}
