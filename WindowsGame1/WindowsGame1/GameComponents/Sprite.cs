using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WindowsGame1.TileEngine;


namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Sprite : Microsoft.Xna.Framework.GameComponent
    {
       
       Texture2D Tile_texture;
     
       public Vector2 position;
       public Rectangle ship;
       TimeSpan Tile_elapsedTime = TimeSpan.Zero;
       Point Tile_frameSize = new Point(42, 67);
       Point Tile_currentFrame = new Point(0, 0);
       Point Tile_sheetSize = new Point(0, 5);
       TileSet tileset;


       static List<Texture2D> EngineTextures = new List<Texture2D>();

       ParticleEngine particleEngine = new ParticleEngine(EngineTextures, new Vector2(400, 240));
      
              
        ContentManager manager;
         
        public Sprite(Game game,Texture2D texture,Vector2 position)
            : base(game)
        {
            manager= Game.Content;
           // this.texture = texture;
            this.position = position;
            Tile_texture = manager.Load<Texture2D>("helicopter");
            tileset = new TileSet(Game, Tile_texture, new Vector2(50, 50), new Point(64, 64), new Point(0, 0), new Point(3, 0),0.01f);
            EngineTextures.Add(manager.Load<Texture2D>("part1"));
            EngineTextures.Add(manager.Load<Texture2D>("part2"));
            EngineTextures.Add(manager.Load<Texture2D>("part3"));
          
           
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

        public void PutinStartPosition()
        {
           position.X = 250 ;
           position.Y = 400;

         
           
        }
        
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            Tile_elapsedTime += gameTime.ElapsedGameTime;

            if (Tile_elapsedTime > TimeSpan.FromSeconds(1))
            {
                Tile_elapsedTime -= TimeSpan.FromSeconds(1);
                Tile_currentFrame.X++;
                if (Tile_currentFrame.X > 3)
                    Tile_currentFrame.X = 0;
            }
            // TODO: Add your update code here
            if (this.position.X < 0)
                position.X = 0;
            if (this.position.X > Game.Window.ClientBounds.Width - Tile_frameSize.X - 300)
                position.X = Game.Window.ClientBounds.Width - Tile_frameSize.X - 300;
            if (this.position.Y < 0)
                position.Y = 0;
            if (this.position.Y > Game.Window.ClientBounds.Height - Tile_frameSize.Y)
                position.Y = Game.Window.ClientBounds.Height - Tile_frameSize.Y;
           

            //----------------------------------------------
            if (InputManager.KeyNotReleased(Keys.Up))
            {
                position.Y -= 5;
            }
            if (InputManager.KeyNotReleased(Keys.Down))
            {
                position.Y += 5;
            }

            if (InputManager.KeyNotReleased(Keys.Left))
            {
                position.X -= 5;
            }

            if (InputManager.KeyNotReleased(Keys.Right))
            {
                position.X += 5;
            }
            tileset.Update(gameTime);
            //----------------------------------------------

            particleEngine.emitterLocation = new Vector2(position.X + Tile_frameSize.X / 2, position.Y + Tile_frameSize.Y);
            particleEngine.Update();
            //----------------------------------------------
            base.Update(gameTime);
        }


        public void Draw(SpriteBatch SpriteBatch)
        {


            //ship = new Rectangle((int)position.X, (int)position.Y, Tile_frameSize.X, Tile_frameSize.Y);
            //МАГИЯ!!!!Я перенес хитпоинт. поэтому такие цифры.
            ship = new Rectangle((int)position.X + 27, (int)position.Y+27, 10, 10);
            SpriteBatch.Begin();
          //  particleEngine.Draw(Game1.spriteBatch);
           
            //SpriteBatch.Draw(Tile_Texture, position, new Rectangle(
            //                    Tile_frameSize.X * Tile_currentFrame.X,
            //                    Tile_frameSize.Y * Tile_currentFrame.Y,
            //                    Tile_frameSize.X,
            //                    Tile_frameSize.Y),
            //                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            SpriteBatch.End();
            tileset.Draw(Game1.spriteBatch, position);

        }
    }
}
