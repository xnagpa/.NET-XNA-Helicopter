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


namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Enemy : Microsoft.Xna.Framework.GameComponent
    {
        public Vector2[] WayPoints;
        public bool[] WayFlags;
        public Texture2D Enemy_texture;
        public Vector2 Enemy_position;
        public Rectangle Enemy_ship;
        public bool remove_flag;
        public bool wanna_shot;
        public Texture2D Shot_texture;
        public Random rnd;
        public Shot shot;
        public int shotDelay = 100;
        public ContentManager manager;
        Game game2;

        //int Yspeed;
        //int Xspeed;
        double Yspeed;
        double Xspeed;
        public TimeSpan elapsedTime = TimeSpan.Zero;



        public  Enemy(Game game, Texture2D texture, Vector2 position)
            : base(game)
        {
            manager = Game.Content;
            remove_flag = false;
            this.Enemy_texture = texture;
            this.Enemy_position = position;
            rnd = new Random(this.GetHashCode());

            WayFlags = new bool[4];
            for (int i = 0; i < WayFlags.Length; i++)
            {
                WayFlags[i] = false;
            }
          
            PutinStartPosition();
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
       public override  void Update(GameTime gameTime)
        {

            if (this.Enemy_position.X < 0)
                Enemy_position.X = 0;
            if (this.Enemy_position.X > Game.Window.ClientBounds.Width - this.Enemy_texture.Width - 300)
                Enemy_position.X = Game.Window.ClientBounds.Width - this.Enemy_texture.Width - 300;

            if ((Enemy_position.Y >= Game.Window.ClientBounds.Height) ||
               (Enemy_position.X >= Game.Window.ClientBounds.Width) || (Enemy_position.X <= 0))
            {
                remove_flag = true;

            }

            //elapsedTime += gameTime.ElapsedGameTime;
            //if (elapsedTime > TimeSpan.FromSeconds(1))
            //{
            //    wanna_shot = true;
            //    elapsedTime -= TimeSpan.FromSeconds(5);
            //}

            //Way points
            //if ((Enemy_position.Y < WayPoints[1].Y) && (WayFlags[1] == false))
            //{
            //    Enemy_position.Y += 1;
            //    //  Enemy_position.Y += 2;
            //    if ((Enemy_position.Y == WayPoints[1].Y))
            //        WayFlags[1] = true;
            //}

            //if ((Enemy_position.X < WayPoints[2].X) && (WayFlags[2] == false) && (WayFlags[1] == true))
            //{
            //    Enemy_position.X += 1;

            //    if ((Enemy_position.X == WayPoints[2].X))
            //        WayFlags[2] = true;
            //}

            //if ((Enemy_position.Y > WayPoints[3].Y) && (WayFlags[3] == false) && (WayFlags[2] == true))
            //{
            //    Enemy_position.Y -= 1;

            //    if ((Enemy_position.Y == WayPoints[3].Y))
            //        WayFlags[3] = true;
            //}


            //if ((Enemy_position.X > WayPoints[1].X) && (WayFlags[0] == false) && (WayFlags[3] == true))
            //{
            //    Enemy_position.X -= 1;

            //    if ((Enemy_position.X == WayPoints[1].X))
            //        for (int i = 0; i < WayFlags.Length; i++)
            //        {
            //            WayFlags[i] = false;
            //        }
            //}




            //else
            //    if (Enemy_position.X < WayPoints[0].X)
            //        Enemy_position.X -= 1;





            //Движение по синусу

            //Enemy_position.X += 5 * (float)Math.Sin(Enemy_position.Y / 20);
            //Enemy_position.Y += 2f;

            //----------------------------------------------


            base.Update(gameTime);
        }

        public virtual  void PutinStartPosition()
        {
            //Enemy_position.X = rnd.Next(Game.Window.ClientBounds.Width - Enemy_texture.Width);
            //Enemy_position.Y = 0;
            Enemy_position.X = Game.Window.ClientBounds.Width/2;
            Enemy_position.Y = -50;
            //Xspeed = rnd.NextDouble();
        }

        public virtual void Draw(SpriteBatch SpriteBatch)
        {
            if (remove_flag != true)
            {
                Enemy_ship = new Rectangle((int)Enemy_position.X, (int)Enemy_position.Y, Enemy_texture.Width, Enemy_texture.Height);
                // SpriteBatch.Draw(texture, ship, Color.White);
                SpriteBatch.Begin();
                SpriteBatch.Draw(Enemy_texture, Enemy_position, Color.White);
                SpriteBatch.End();
                // shot.Draw(SpriteBatch);
            }

        }
    }
}
