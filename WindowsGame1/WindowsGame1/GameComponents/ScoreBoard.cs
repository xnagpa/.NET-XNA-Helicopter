using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using WindowsGame1.BadGuys;

namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ScoreBoard : Microsoft.Xna.Framework.GameComponent
    {
        Rectangle ScoreRect;
        Texture2D ScoreTexture;
        SpriteFont ScoreFont;
        SpriteFont ScoreFont2;
         string score;
        int old_score;
        string lives;
        int int_lives=3;
        public bool end_flag = false;
        string Time;
        public int int_score;
        ContentManager manager;
        SnowEngine engine;
        List <Texture2D> EngineTextures;

        public ScoreBoard(Game game, Texture2D ScoreTexture)
            : base(game)
        {
            EngineTextures = new List<Texture2D>();
            // TODO: Construct any child components here
            manager = Game.Content;
            EngineTextures.Add(manager.Load<Texture2D>("Snow1"));
            EngineTextures.Add(manager.Load<Texture2D>("Snow2"));
            EngineTextures.Add(manager.Load<Texture2D>("Snow3"));
            this.ScoreTexture = ScoreTexture;
            ScoreFont = manager.Load<SpriteFont>("ScoreFont");
            ScoreFont2 = manager.Load<SpriteFont>("ScoreFont2");
            ScoreRect = new Rectangle(500, 0, 300, 600);
            engine = new SnowEngine(EngineTextures,new Vector2(800,-100));
        }

        public void UpdateScore(int score)
        {
            int_score += score;
            if (int_score%900 == 0)
                int_lives += 1;
        }

        public void DecrementLive(int dec)
        {
            int_lives -= dec;
            if (int_lives < 0)
            {
                end_flag = true;
            }

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        /// 
        
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
            
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            engine.Update();
            // TODO: Add your update code here
            if (old_score != int_score)
            {
                old_score += 5;
            }
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
           
            SpriteBatch.Begin();
            SpriteBatch.Draw(ScoreTexture, ScoreRect, Color.White);
            SpriteBatch.DrawString(ScoreFont, "SCOREBOARD", new Vector2(536, 41), Color.Black);
            SpriteBatch.DrawString(ScoreFont, "SCOREBOARD", new Vector2(535, 40), Color.Yellow);
            
            SpriteBatch.DrawString(ScoreFont2,"Points: "+ old_score.ToString("0000000000"), new Vector2(530, 210), Color.Black);
            SpriteBatch.DrawString(ScoreFont2, "Points: " + old_score.ToString("0000000000"), new Vector2(531, 211), Color.Yellow);
            SpriteBatch.DrawString(ScoreFont2, "Lives: " + int_lives.ToString(), new Vector2(530, 380), Color.Black);
            SpriteBatch.DrawString(ScoreFont2, "Lives: " + int_lives.ToString(), new Vector2(531, 381), Color.Yellow);
            engine.Draw(SpriteBatch);
            SpriteBatch.End();


        }
    }
}
