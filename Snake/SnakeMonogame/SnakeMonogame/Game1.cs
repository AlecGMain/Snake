﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SnakeMonogame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Food nom;
        KeyboardState ks;
        bool dead;
        SpriteFont font;
        Random r;
        SoundEffect catSoundEffect;
        SoundEffectInstance catSoundEffectInstance;
        TimeSpan currentTime;
        TimeSpan waitTime = TimeSpan.FromMilliseconds(250);
        List<SnakePiece> pieces = new List<SnakePiece>();
        bool firstpiece = true;
        int last;
        int score;
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
            pieces = new List<SnakePiece>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SnakePiece head = new SnakePiece(Content.Load<Texture2D>("Nyan"), new Vector2(1, 1), Color.White, Direction.Right);
            dead = false;
            font = Content.Load<SpriteFont>("Font");
            catSoundEffect = Content.Load<SoundEffect>("cat_screech2");
            pieces.Add(head);


            r = new Random();
            nom = new Food(Content.Load<Texture2D>("food"), new Vector2(r.Next(0, 540), r.Next(0, 540)), Color.White);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            { Exit(); }
            currentTime += gameTime.ElapsedGameTime;

            if (currentTime > waitTime)
            {
                if (dead == false)
                {
                    foreach (SnakePiece piece in pieces)
                    {
                        piece.Update(gameTime);

                        base.Update(gameTime);
                    }

                    for (int i = pieces.Count - 1; i > 0; i--)
                    {   
                        pieces[i].Direction = pieces[i - 1].Direction;
                    }
                }
                currentTime = TimeSpan.Zero;
            }

            ks = Keyboard.GetState();

            nom.Update(gameTime);


            pieces[0].Move(ks, Keys.Up, Keys.Down, Keys.Left, Keys.Right);

            for (int i = 2; i < pieces.Count; i++)
            {
                if ( pieces[i].hitbox.Intersects(pieces[0].hitbox))
                {
                    dead = true;
                }
            }

            if (pieces[0].position.X <= 0)
            {
                pieces[0].Direction = Direction.None;
                dead = true;
            }
            if (pieces[0].position.X >= 600 - pieces[0].image.Width)
            {
                pieces[0].Direction = Direction.None;
                dead = true;
            }
            if (pieces[0].position.Y <= 0)
            {
                pieces[0].Direction = Direction.None;
                dead = true;
            }
            if (pieces[0].position.Y >= 600 - pieces[0].image.Width)
            {
                pieces[0].Direction = Direction.None;
                dead = true;
            }

            if (dead)
            {
               
                if (catSoundEffectInstance == null)
                {
                    catSoundEffectInstance = catSoundEffect.CreateInstance();

                    catSoundEffect.Play();
                }
                if (ks.IsKeyDown(Keys.R))
                {
                    while (pieces.Count > 1)
                    {
                        pieces.Remove(pieces[1]);
                    }
                    pieces[0].Direction = Direction.Right;
                    pieces[0].position = new Vector2(1, 1);
                    dead = false;
                    score = 0;
                }
            }
        
            if (pieces[0].hitbox.Intersects(nom.hitbox))
            {
                nom.position = new Vector2(r.Next(0, 540), r.Next(0, 540));
                SnakePiece tailPiece = pieces[pieces.Count - 1];

                SnakePiece newPiece = new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(tailPiece.position.X, tailPiece.position.Y), Color.White, tailPiece.Direction);
                score++;
                if (tailPiece.Direction == Direction.Up)
                {
                    newPiece.position = new Vector2(newPiece.position.X, newPiece.position.Y + (tailPiece.image.Height ));
                }
                if (tailPiece.Direction == Direction.Down)
                {
                    newPiece.position = new Vector2(newPiece.position.X, newPiece.position.Y - (tailPiece.image.Height ));
                }
                if (tailPiece.Direction == Direction.Left)
                {
                    newPiece.position = new Vector2(newPiece.position.X + tailPiece.image.Width, (newPiece.position.Y ));
                }
                if (tailPiece.Direction == Direction.Right)
                {
                    newPiece.position = new Vector2(newPiece.position.X - tailPiece.image.Width, (newPiece.position.Y ));
                }

                pieces.Add(newPiece);
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            nom.Draw(spriteBatch);            

            foreach (SnakePiece piece in pieces)
            {
                piece.Draw(spriteBatch);
            }
            spriteBatch.DrawString(font, $"Score:{score}", new Vector2(530, 0), Color.Green);
            if (dead == true)
            {
                spriteBatch.DrawString(font, $"Nyan Cat died after running into a wall(or himself, no one knows for sure) at high speeds, lol", Vector2.Zero, Color.Red);
                spriteBatch.DrawString(font, $"Press R to play again!", new Vector2(300, 300), Color.Blue);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
