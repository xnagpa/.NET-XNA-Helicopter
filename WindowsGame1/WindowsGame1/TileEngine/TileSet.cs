using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.TileEngine
{
    class TileSet : Microsoft.Xna.Framework.GameComponent
    {
       
        
       public Texture2D Tile_Texture;
       public Vector2 Tile_Position;
      public Point Tile_frameSize;
      public Point Tile_currentFrame;
      public Point Tile_sheetSize;
      public TimeSpan Tile_elapsedTime = TimeSpan.Zero;
      float period_in_sec;

        public  TileSet(Game game,Texture2D image,Vector2 position,Point frameSize, Point currentFrame,Point sheetSize,float period_in_sec ):base(game)
        {
            this.Tile_Texture = image;
            this.Tile_Position = position;
            this.Tile_frameSize = frameSize;
            this.Tile_currentFrame = currentFrame;
            this.Tile_sheetSize = sheetSize;
            this.period_in_sec = period_in_sec;

        }

        public void Update(GameTime gameTime)
        {
            
            Tile_elapsedTime += gameTime.ElapsedGameTime;

            if (Tile_elapsedTime > TimeSpan.FromSeconds(period_in_sec))
            {
                Tile_elapsedTime -= TimeSpan.FromSeconds(period_in_sec);
               Tile_currentFrame.X++;
               if (Tile_currentFrame.X > Tile_sheetSize.X)
                    Tile_currentFrame.X = 0;
            }

           
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 position)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Tile_Texture, position, new Rectangle(
                                Tile_frameSize.X * Tile_currentFrame.X,
                                Tile_frameSize.Y * Tile_currentFrame.Y,
                                Tile_frameSize.X,
                                Tile_frameSize.Y),
                                Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.End();

        }



    }
}
