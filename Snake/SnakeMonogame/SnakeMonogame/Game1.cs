using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        bool dead;
        SpriteFont font;

        SoundEffect catSoundEffect;
        SoundEffectInstance catSoundEffectInstance;

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
            head = new SnakeHead(Content.Load<Texture2D>("Nyan"),new Vector2(1,1), Color.White, 1);
            dead = false;
            font = Content.Load<SpriteFont>("Font");
            catSoundEffect = Content.Load<SoundEffect>("cat_screech2");
            catSoundEffectInstance = catSoundEffect.CreateInstance();
            catSoundEffectInstance.IsLooped = true;
            catSoundEffectInstance.Play();       
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
            if (head.position.X <= 0)
            {
                head.Speed = 0;
                dead = true;
            }
            if(head.position.X >= 600 - head.image.Width)
            {
                head.Speed = 0;
                dead = true;
            }
            if (head.position.Y <= 0)
            {
                head.Speed = 0;
                dead = true;
            }
            if (head.position.Y >= 600 - head.image.Width)
            {
                head.Speed = 0;
                dead = true;
            }

            if (dead)
            {
                if (catSoundEffectInstance == null)
                { 
                    catSoundEffectInstance = catSoundEffect.CreateInstance();
                    catSoundEffect.Play();
                }
            }

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            head.Draw(spriteBatch);
            if(dead == true)
            {
                spriteBatch.DrawString(font, $"Nyan Cat died after running into a wall(or himself, no one knows for sure) at high speeds, lol",Vector2.Zero, Color.Red);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
