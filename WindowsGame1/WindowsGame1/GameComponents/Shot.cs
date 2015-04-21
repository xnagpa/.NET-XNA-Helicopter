using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;


namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Shot : Microsoft.Xna.Framework.GameComponent
    {
        Texture2D Shot_texture;
        Vector2 Shot_position;
        public Rectangle Shot_Rectangle;
        Game game2;
        public bool remove_flag;
        public bool player_attack;
        public bool enemy_attack;
        ParticleEngine engine;
        public ContentManager manager;
        static List<Texture2D> EngineTextures = new List<Texture2D>();
        string fromstring;
        public TimeSpan elapsedTime = TimeSpan.Zero;

        ParticleEngine particleEngine = new ParticleEngine(EngineTextures, new Vector2(400, 240));

        public Shot(Game game, Texture2D texture, Vector2 position,string from)
            : base(game)
        {
            manager = Game.Content;
            this.Shot_texture = texture;
            this.Shot_position = position;
            remove_flag = false;
            game2 = game;
            EngineTextures.Add(manager.Load<Texture2D>("part1"));
            EngineTextures.Add(manager.Load<Texture2D>("part2"));
            EngineTextures.Add(manager.Load<Texture2D>("part3"));
            fromstring = from;
            if (from == "P")
                player_attack = true;

            else
                enemy_attack = true;
                

            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            player_attack = false;
            enemy_attack = false;
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > TimeSpan.FromSeconds(1))
                remove_flag = true;
            if (fromstring == "P")
            {
                particleEngine.emitterLocation = new Vector2(Shot_position.X + Shot_texture.Width / 2, Shot_position.Y + Shot_texture.Height);
                particleEngine.Update();
            }
            // TODO: Add your update code here
            if (player_attack)
            Shot_position.Y -= 20;
            else
            Shot_position.Y += 15;

            //if ((Shot_position.Y == 0) ||(Shot_position.Y > Game.Window.ClientBounds.Bottom))  
            //{
            //    remove_flag = true;
            //    particleEngine.Dispose();
            //}

            //----------------------------------------------
            base.Update(gameTime);
        }


        public void Draw(SpriteBatch SpriteBatch)
        {
           
            
                Shot_Rectangle = new Rectangle((int)Shot_position.X, (int)Shot_position.Y, Shot_texture.Width, Shot_texture.Height);
                // SpriteBatch.Draw(texture, ship, Color.White);
                SpriteBatch.Begin();
                if (fromstring == "P")
                {

                    particleEngine.Draw(SpriteBatch);
                }
                SpriteBatch.Draw(Shot_texture, Shot_position, Color.White);
                SpriteBatch.End();
            
        }
    }
}
