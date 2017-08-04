using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeMonogame
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SnakeHead head;
        KeyboardState ks;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
           
            base.Initialize();
        }

     
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);
            head = new SnakeHead(Content.Load<Texture2D>("Nyan"), Vector2.Zero, Color.White, 1);
         
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            { Exit(); }

            ks = Keyboard.GetState();



            head.Move(ks, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            if (head.Direction == 1)
            {
                head.position.Y += head.Speed;
            }
            if (head.Direction == 2)
            {
                head.position.Y -= head.Speed;
            }
            if (head.Direction == 3)
            {
                head.position.X -= head.Speed;
            }
            if (head.Direction == 4)
            {
                head.position.X += head.Speed;
            }
            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            head.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
