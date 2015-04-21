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
using WindowsGame1.TileEngine;

using WindowsGame1.GameComponents;


namespace WindowsGame1.BadGuys
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Gunner :Enemy
    {
        TimeSpan Tile_elapsedTime = TimeSpan.Zero;
        Point Tile_frameSize = new Point(64, 64);
        Point Tile_currentFrame = new Point(0, 0);
        Point Tile_sheetSize = new Point(3, 0);
        TileSet tileset;
       
        
        public Gunner(Game game, Texture2D texture, Vector2 position):base(game,texture,position)
            
        {


            tileset = new TileSet(game, texture, position, Tile_frameSize, Tile_currentFrame, Tile_sheetSize, 0.01f);
            remove_flag = false;
            this.Enemy_texture = texture;
            Enemy_position = position;
            rnd = new Random(this.GetHashCode());

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

            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > TimeSpan.FromSeconds(0.6f))
            {
                wanna_shot = true;
                elapsedTime -= TimeSpan.FromSeconds(0.6f);
            }

         

            //Движение по прямо
          // Enemy_position.Y += 2 *(float)Math.PI* Enemy_position.X;
            Enemy_position.X += 5 * (float)Math.Sin(Enemy_position.Y / 20);
            Enemy_position.Y += 2f;
            //----------------------------------------------
           tileset.Update(gameTime);

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
               Enemy_ship = new Rectangle((int)Enemy_position.X, (int)Enemy_position.Y, Tile_frameSize.X, Tile_frameSize.Y);
               //SpriteBatch.Draw(texture, ship, Color.White);
           //    SpriteBatch.Begin();
           ////    SpriteBatch.Draw(Enemy_texture, Enemy_position, Color.White);

           //    SpriteBatch.End();
               tileset.Draw(SpriteBatch, Enemy_position);
               //shot.Draw(SpriteBatch);
           }

        }
    }
}
