using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.CSharp;


using WindowsGame1.GameComponents;


namespace WindowsGame1.BadGuys
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Tank :Enemy
    {
       
        SnowEngine engine;
        List<Texture2D> EngineTextures;

        public Tank(Game game, Texture2D texture, Vector2 position):base(game,texture,position)
            
        {
            EngineTextures = new List<Texture2D>();
            EngineTextures.Add(manager.Load<Texture2D>("Snow1"));
            EngineTextures.Add(manager.Load<Texture2D>("Snow2"));
            EngineTextures.Add(manager.Load<Texture2D>("Snow3"));
            remove_flag = false;
            this.Enemy_texture = texture;
            Enemy_position = position;
            rnd = new Random(this.GetHashCode());
            engine = new SnowEngine(EngineTextures, Enemy_position);
            WayFlags = new bool[4];
            for (int i = 0; i < WayFlags.Length; i++)
            {
                WayFlags[i] = false;
            }
          
           
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
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
            engine.emitterLocation = new Vector2(Enemy_position.X + Enemy_texture.Width / 2, Enemy_position.Y + Enemy_texture.Height);
            if (this.Enemy_position.X < 0)
                Enemy_position.X = 0;
            if (this.Enemy_position.X > Game.Window.ClientBounds.Width - this.Enemy_texture.Width - 300)
                Enemy_position.X = Game.Window.ClientBounds.Width - this.Enemy_texture.Width - 300;

            if ((Enemy_position.Y >= Game.Window.ClientBounds.Height) ||
               (Enemy_position.X >= Game.Window.ClientBounds.Width) || (Enemy_position.X <= 0))
            {
                remove_flag = true;

            }
            

            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > TimeSpan.FromSeconds(1f))
            {
                wanna_shot = true;
                elapsedTime -= TimeSpan.FromSeconds(1f);
             
            }

         

            //Движение по прямо
            Enemy_position.Y += 2;

            //----------------------------------------------

            
            base.Update(gameTime);
        }

       public override void PutinStartPosition()
        {
            //Tank_position.X = rnd.Next(Game.Window.ClientBounds.Width - Tank_texture.Width);
            //Tank_position.Y = 0;
            Random rnd = new Random(20);
            Enemy_position.X = (int)(Game.Window.ClientBounds.Width / 2 * rnd.NextDouble());
            Enemy_position.Y = -50;
            //Xspeed = rnd.NextDouble();
        }

       public override void Draw(SpriteBatch SpriteBatch)
       {
           if (remove_flag != true)
           {
             
               Enemy_ship = new Rectangle((int)Enemy_position.X, (int)Enemy_position.Y, Enemy_texture.Width, Enemy_texture.Height);
               //SpriteBatch.Draw(texture, ship, Color.White);
               SpriteBatch.Begin();
               engine.Draw(SpriteBatch);
               SpriteBatch.Draw(Enemy_texture, Enemy_position, Color.White);
               SpriteBatch.End();
              
               //shot.Draw(SpriteBatch);
           }

        }
    }
}
