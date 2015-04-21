using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class HitText : Microsoft.Xna.Framework.GameComponent
    {
        string text;
        Color color1;
        Color color2;
        Vector2 position;
        SpriteFont font;
        ContentManager manager;
        Random rnd;
        float rotation=MathHelper.ToRadians(0f);
     
        public HitText(Game game,string text,Color color1,Color color2,Vector2 position)
            : base(game)
        {
            this.text = text;
            this.color1 = color1;
            this.color2 = color2;
            this.position = position;
            manager = Game.Content;
            font = manager.Load<SpriteFont>("SpriteFont2");
            rnd = new Random();
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
            // TODO: Add your update code here
            position.Y -= 5;
            if (position.Y == 0)
                this.Dispose();
            rotation +=0.01f;
            
            if (rotation < -360)
                rotation = 0;


            base.Update(gameTime);


        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, text, position,color2, rotation, new Vector2(10, 10), 1, 0, 0);

                spriteBatch.DrawString(font, text, new Vector2(position.X + 5, position.Y + 5), color1, rotation, new Vector2(10, 10), 1, 0, 0);
                spriteBatch.End();
           
        }
    }
}
