using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace WindowsGame1.GameComponents
{
    class Dialogue : Microsoft.Xna.Framework.GameComponent
    {
        bool Visible;
        Texture2D image;
        Texture2D bubble;
        Rectangle rect;
        Rectangle bubble_rect;
        string text;
        Vector2 position;
        ContentManager manager;
        bool close_flag = false;
        Timer text_timer;
        bool next_char=false;
        int i = 0;
        string str;
        string str2="";
        SpriteFont font;
        TimeSpan elapsedTime = TimeSpan.Zero;
        int alpha = 0;
        int old_i;
        int x = 0;
        int frameRate = 0;
        int frameCounter = 0;
        Vector2 text_length;
        int delta = 0;
        string str3 = "";
        public bool dispose_flag=false;

        public Dialogue(Game game,Texture2D image,string text)
            : base(game)
        {
            manager = Game.Content;
            bubble = manager.Load<Texture2D>("DialogBuble");
            font = manager.Load<SpriteFont>("DialogFont");
            this.image = image;
            
            position = new Vector2(-195, 100);
            bubble_rect = new Rectangle((int)position.X + 100, (int)position.Y + 200, bubble.Width, bubble.Height);

            str = text;

            
          
        }

       

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
               
                frameRate = frameCounter;
                frameCounter = 0;
            }

            if ((position.X + image.Width < image.Width))
            {
                
                position.X += 5;
              
            }
           
            if ((InputManager.KeyPressed(Keys.Space)))
            {
                close_flag =true;
               
            }

            if ( (close_flag == true))
            {
                position.X -= 10;
               
                
            }

            
          
             if (alpha<255)
                alpha += 1;
           
           
            base.Update(gameTime);

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            frameCounter++;
            string fps = string.Format("fps: {0}", frameRate);

            rect = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
            bubble_rect = new Rectangle(200,300, bubble.Width, bubble.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(image,rect,Color.Multiply(new Color(255,255,255,alpha),2f));
          


          
            if (close_flag != true)
            {
                spriteBatch.Draw(bubble, bubble_rect, Color.White);
                spriteBatch.DrawString(font, str2, new Vector2(bubble_rect.X+10, bubble_rect.Y+10), Color.Black);
                spriteBatch.DrawString(font, str2, new Vector2(bubble_rect.X+ 11, bubble_rect.Y+ 11), Color.White);
            }
            else
            {
                dispose_flag = true;
            }

            text_length = font.MeasureString(str3);
            text_length.X -= delta * (bubble_rect.Width);
           
            if ((elapsedTime > TimeSpan.FromMilliseconds(50)) && (i < str.Length))
            {
                if ((float)text_length.X/((float)bubble_rect.Width-10)>=1)
                {
                    delta++;
                  
                 
                    str2 += "\n";
                }
                str2 += str[i];
                str3 += str[i];

                elapsedTime -= TimeSpan.FromMilliseconds(50);
                             
                i++;

            }
              
              
           
            spriteBatch.End();
          
        }
    }
}
