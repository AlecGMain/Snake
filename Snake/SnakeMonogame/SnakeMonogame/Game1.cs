using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeMonogame
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        Texture2D image;
        Vector2 position;
        Color tint;
  
        protected override void Initialize()
        {
           
            base.Initialize();
        }

     
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);
            image = Content.Load<Texture2D>("Tower1");
            position = new Vector2(0, 0);
            tint = Color.White;
         
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(image, position, tint);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
