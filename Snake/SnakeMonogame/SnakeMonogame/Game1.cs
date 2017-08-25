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
        SnakeHead head;
        Food nom;
        KeyboardState ks;
        bool dead;
        SpriteFont font;
        Random r;
        SoundEffect catSoundEffect;
        SoundEffectInstance catSoundEffectInstance;
        TimeSpan currentTime;
        TimeSpan waitTime = TimeSpan.FromMilliseconds(250);
        List<SnakePiece> pieces;
        bool firstpiece = true;
        int last;
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
            pieces = new List<SnakePiece>();
        }

     
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);
            head = new SnakeHead(Content.Load<Texture2D>("Nyan"),new Vector2(1,1), Color.White, 4);
            dead = false;
            font = Content.Load<SpriteFont>("Font");
            catSoundEffect = Content.Load<SoundEffect>("cat_screech2");
        
         
            r = new Random();
            nom = new Food(Content.Load<Texture2D>("food"), new Vector2(r.Next(0,540), r.Next(0, 540)), Color.White);
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
                    int i = 0;
                    head.Update(gameTime);
                    foreach (SnakePiece piece in pieces)
                    {
                        if (i == 0)
                        {
                            piece.Direction = head.Direction;
                        }
                        else
                        {
                            piece.Direction = pieces[i - 1].Direction;
                        }
                        piece.Update(gameTime);
                        i++;

                        base.Update(gameTime);
                    }
                }
                currentTime = TimeSpan.Zero;
            }

            ks = Keyboard.GetState();

            nom.Update(gameTime);


            head.Move(ks, Keys.Up, Keys.Down, Keys.Left, Keys.Right);

            if (head.position.X <= 0)
            {
                head.Direction = 0;
                dead = true;
            }
            if (head.position.X >= 600 - head.image.Width)
            {
                head.Direction = 0;
                dead = true;
            }
            if (head.position.Y <= 0)
            {
                head.Direction = 0;
                dead = true;
            }
            if (head.position.Y >= 600 - head.image.Width)
            {
                head.Direction = 0;
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
            if (head.hitbox.Intersects(nom.hitbox))
            {
                if (firstpiece == false)
                {


                    last = pieces.Count - 1;
                }

            }
            if (head.hitbox.Intersects(nom.hitbox))
            {
                nom.position = new Vector2(r.Next(0, 540), r.Next(0, 540));
                if (firstpiece == true)
                {
                    if (head.Direction == 4)
                    {



                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(head.position.X - 60, head.position.Y), Color.White, 4));

                    }
                    else if (head.Direction == 3)
                    {


                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(head.position.X + 60, head.position.Y), Color.White, 3));

                    }
                    else if (head.Direction == 2)
                    {

                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(head.position.X, head.position.Y + 60), Color.White, 2));

                    }
                    else if (head.Direction == 1)
                    {


                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(head.position.X, head.position.Y - 60), Color.White, 1));

                    }
                    firstpiece = false;
                }
                else
                {
                    if (head.Direction == 1)
                    {
                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(pieces[last].position.X, pieces[last].position.Y - 60), Color.White, 1));
                    }
                    if (head.Direction == 2)
                    {
                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(pieces[last].position.X, pieces[last].position.Y + 60), Color.White, 2));
                    }
                    if (head.Direction == 3)
                    {
                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(pieces[last].position.X + 60, pieces[last].position.Y), Color.White, 3));
                    }
                    if (head.Direction == 4)
                    {
                        pieces.Add(new SnakePiece(Content.Load<Texture2D>("trail"), new Vector2(pieces[last].position.X - 60, pieces[last].position.Y), Color.White, 4));
                    }
                }
                
            } }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            nom.Draw(spriteBatch);
            head.Draw(spriteBatch);

  foreach (SnakePiece piece in pieces)
            {
                piece.Draw(spriteBatch);
            }

            if(dead == true)
            {
                spriteBatch.DrawString(font, $"Nyan Cat died after running into a wall(or himself, no one knows for sure) at high speeds, lol",Vector2.Zero, Color.Red);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
