using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using WindowsGame1.GameScreens;
using WindowsGame1.TileEngine;
using WindowsGame1.BadGuys;



namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    
    public class GamePlayScreen : GameScreen
    {
        Sprite Ship;
     //   Engine engine = new Engine(4, 4);
        TimeSpan elapsedTime;
        Texture2D texture;
        Texture2D fon;
        Texture2D tileSetTexture;
        Texture2D Score_texture;
        Texture2D shot_texture;
        ScreenManager scr_manager;
        StartScreen start_screen;
        Texture2D Enemy_texture;
        Texture2D Tank_texture;
        ScoreBoard board;
        BackgroundComponent Background;
        Texture2D dialog_picture;
        Texture2D helicopter_enemy;
        bool[] Wave_flags;
        HitMessage hitMessage;


        TileSet tileset;
      //  Timer timer = new Timer(5000);
        string Message;
        Random rnd = new Random();

      

       Dialogue dialog;  
     

        List<Enemy> Enemy_list;
        List<Shot> Shot_list;
        List<HitText> HitText_list;

        SpriteFont font;
        bool Pause = true;
        public GamePlayScreen(Game game)
            : base(game)
        {
           // timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            Content = Game.Content;
            Shot_list = new List<Shot>();
            Enemy_list = new List<Enemy>();
            HitText_list = new List<HitText>();
            Message = "1";
          
           
          //  timer.Start();
         
            
            
          
          

            // TODO: Construct any child components here
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
          //  Enemy_list.Add(new Enemy(Game, Enemy_texture, new Vector2(rnd.Next(Game.Window.ClientBounds.Width - Enemy_texture.Width), 0)));
        }

        protected override void LoadContent()
        {
            Wave_flags = new bool[10];
            for (int i = 0; i < Wave_flags.Length; i++)
            {
                Wave_flags[i] = false;
            }
            dialog_picture = Content.Load<Texture2D>("dialog");
          
            fon = Content.Load<Texture2D>("shovless");
            Background = new BackgroundComponent(Game, fon, DrawMode.Fill);
          
            //tileSetTexture = Content.Load<Texture2D>("Tile");
            //tileset = new TileSet(tileSetTexture, 4, 0, 100, 100);
            texture = Content.Load<Texture2D>("fon");
            shot_texture = Content.Load<Texture2D>("Shot");
            Enemy_texture = Content.Load<Texture2D>("Enemy");
            Tank_texture = Content.Load<Texture2D>("tank1");
            Score_texture=Content.Load<Texture2D>("Back2");
            helicopter_enemy = Content.Load<Texture2D>("helicopter_enemy");
            board = new ScoreBoard(Game, Score_texture);
            font = Content.Load<SpriteFont>("SpriteFont1");
            Ship = new Sprite(Game, texture, new Vector2(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2));           
          //  Enemy_list.Add(new Enemy(Game, Enemy_texture, new Vector2(50, 0)));
            dialog = new Dialogue(Game, dialog_picture, "Начинаааееем!!!!");

            base.LoadContent();

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            scr_manager = new ScreenManager(Game);
            start_screen = new StartScreen(Game, scr_manager);
            elapsedTime = TimeSpan.Zero;
            
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            board.Update(gameTime);
            if (dialog != null)
            dialog.Update(gameTime);
            if (dialog != null)
            if (dialog.dispose_flag == true)
            {
                dialog.Dispose();
                dialog = null; 
            }

            if (((float)board.int_score>5000)&&(board.int_score!=0))
            {
                if (dialog == null)
                dialog = new Dialogue(Game, dialog_picture, "Чмаф! Уровень пройден.");
                Pause = true;

             
            }
            Background.Update();

            if (InputManager.KeyPressed(Keys.Space))
            {
                Shot_list.Add(new Shot(Game, shot_texture, Ship.position, "P"));
                Shot_list.Add(new Shot(Game, shot_texture, new Vector2(Ship.position.X + texture.Width - shot_texture.Width, Ship.position.Y), "P"));
                Pause = false;

            }
            //Esc check
            if ((InputManager.KeyPressed(Keys.Escape)) || (board.end_flag == true))
            {

                scr_manager.ChangeScreens(start_screen);
                this.Dispose();
            }

            if (Pause != true)
            {
                elapsedTime += gameTime.ElapsedGameTime;
                //Enemy generator
                if (elapsedTime > TimeSpan.FromSeconds(1)&&(Wave_flags[0]==false))
                {
                  
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(100, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(300, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(50, -150)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(350, -150)));
                    Enemy_list.Add(new Gunner(Game, helicopter_enemy, new Vector2(200, -50)));
                    Wave_flags[0] = true;
                   
                }

                if (elapsedTime > TimeSpan.FromSeconds(5) && (Wave_flags[1] == false))
                {
                   
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(50, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(350, -50)));
                    Enemy_list.Add(new Gunner(Game, helicopter_enemy, new Vector2(100, -50)));

                    Wave_flags[1] = true;

                }

                if (elapsedTime > TimeSpan.FromSeconds(8) && (Wave_flags[2] == false))
                {

                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(100, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(300, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(50, -150)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(350, -150)));
                   
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(10, -250)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(390, -250)));
                    Enemy_list.Add(new Gunner(Game, helicopter_enemy, new Vector2(200, -50)));

                    Wave_flags[2] = true;

                }
                if (elapsedTime > TimeSpan.FromSeconds(14) && (Wave_flags[3] == false))
                {
                   
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(100, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(300, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(50, -150)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(350, -150)));
                    Enemy_list.Add(new Gunner(Game, helicopter_enemy, new Vector2(250, -50)));
                    Enemy_list.Add(new Gunner(Game, helicopter_enemy, new Vector2(200, -50)));
                    Wave_flags[3] = true;

                }

                if (elapsedTime > TimeSpan.FromSeconds(16) && (Wave_flags[4] == false))
                {

                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(50, -50)));
                    Enemy_list.Add(new Tank(Game, Tank_texture, new Vector2(350, -50)));

                    Wave_flags[4] = true;

                }

              
               
                    Ship.Update(gameTime);
                    //Shot
                    



                    for (int i = 0; i < Shot_list.Count; i++)
                    {
                        Shot_list[i].Update(gameTime);
                    }

                    for (int j = 0; j < HitText_list.Count; j++)
                    {
                        HitText_list[j].Update(gameTime);
                    }



                    for (int i = 0; i < Shot_list.Count; i++)
                    {
                        if (Shot_list[i].remove_flag == true)
                        {
                            Shot_list.RemoveAt(i);
                        }
                    }

                    //Я кого-то замочил
                    for (int i = 0; i < Shot_list.Count; i++)
                        for (int j = 0; j < Enemy_list.Count; j++)
                        {

                            if (Shot_list[i].Shot_Rectangle.Intersects(Enemy_list[j].Enemy_ship) && (Shot_list[i].player_attack == true))
                            {
                                
                                switch (rnd.Next(0, 5))
                                {
                                    case 0:
                                        Message = "One Down!!!";
                                        HitText_list.Add(new HitText(Game, "HOLY SH...", Color.White, Color.Orange, Enemy_list[j].Enemy_position));
                                        hitMessage=new HitMessage(Game, Message,Color.White,Color.Black,new Vector2(12,12));
                                        board.UpdateScore(50);
                                        break;
                                    case 1:
                                          HitText_list.Add(new HitText(Game, "BOOM!", Color.White, Color.OrangeRed, Enemy_list[j].Enemy_position));
                                          Message = "Nice shot!!!";
                                          hitMessage = new HitMessage(Game, Message, Color.White, Color.Black, new Vector2(12, 12));
                                board.UpdateScore(50);
                                        break;
                                    case 2:
                                         Message = "Yeah!";
                                         hitMessage = new HitMessage(Game, Message, Color.White, Color.Black, new Vector2(12, 12));
                                          HitText_list.Add(new HitText(Game, "BANG!", Color.White, Color.IndianRed, Enemy_list[j].Enemy_position));
                                board.UpdateScore(50);
                                        break;
                                    case 3:
                                          Message = "Orraaaa!!!";
                                          hitMessage = new HitMessage(Game, Message, Color.White, Color.Black, new Vector2(12, 12));
                                          HitText_list.Add(new HitText(Game, "OH, GOSHH!", Color.White, Color.Gray, Enemy_list[j].Enemy_position));
                                board.UpdateScore(50);
                                        break;
                                    case 4:
                                          Message = "Come on!!!";
                                          hitMessage = new HitMessage(Game, Message, Color.White, Color.Black, new Vector2(12, 12));
                                          HitText_list.Add(new HitText(Game, "BURN!!", Color.White, Color.OrangeRed, Enemy_list[j].Enemy_position));
                                
                                        break;
                                    case 5:
                                        Message = "Hell yeah...";
                                        hitMessage = new HitMessage(Game, Message, Color.White, Color.Black, new Vector2(12, 12));
                                        HitText_list.Add(new HitText(Game, "FIRE!", Color.White, Color.DarkOrange, Enemy_list[j].Enemy_position));

                                        break;
                                }

                                board.UpdateScore(50);
                                Enemy_list[j].remove_flag = true;
                                Shot_list[i].remove_flag = true;


                            }
                            //Кто-то замочил меня
                            if (Shot_list[i].Shot_Rectangle.Intersects(Ship.ship) && (Shot_list[i].enemy_attack == true))
                            {

                                Message = "YOU Down!!!";
                                Pause = true;
                                board.DecrementLive(1);
                                HitText_list.Add(new HitText(Game, "FAIL...", Color.White, Color.Red, Ship.position));
                                Shot_list[i].remove_flag = true;
                                Ship.PutinStartPosition();
                                Enemy_list.Clear();
                                for (int c = 0; c < Wave_flags.Length; c++)
                                {
                                    Wave_flags[c] = false;
                                }
                                elapsedTime = TimeSpan.Zero;

                            }


                        }

                    for (int j = 0; j < Enemy_list.Count; j++)
                    {
                        if (Enemy_list[j].wanna_shot == true)
                        {
                            Shot_list.Add(new Shot(Game, shot_texture, new Vector2(Enemy_list[j].Enemy_position.X + Enemy_list[j].Enemy_ship.Width / 2 - shot_texture.Width/2, Enemy_list[j].Enemy_position.Y), "E"));
                            
                            Enemy_list[j].wanna_shot = false;
                        }
                    }



                    for (int i = 0; i < Enemy_list.Count; i++)
                    {
                        if (Enemy_list[i].remove_flag == true)
                        {
                            Enemy_list.RemoveAt(i);
                        }
                    }


                    for (int i = 0; i < Enemy_list.Count; i++)
                    {
                        Enemy_list[i].Update(gameTime);
                    }

                    if (hitMessage != null)
                    {
                        hitMessage.Update(gameTime);
                    }
                    base.Update(gameTime);

                
            }
        }

        public override void Draw(GameTime gameTime)
        {
            
            Background.Draw(Game1.spriteBatch);
           
            Game1.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
          //  particleEngine.Draw(Game1.spriteBatch);
            Game1.spriteBatch.End();
            
          //  Enemy.Draw(Game1.spriteBatch);
            board.Draw(Game1.spriteBatch);
          


            for (int i = 0; i < Shot_list.Count; i++)
            {
                Shot_list[i].Draw(Game1.spriteBatch);
            }
            for (int i = 0; i < Enemy_list.Count; i++)
            {
               Enemy_list[i].Draw(Game1.spriteBatch);
            }

            for (int j = 0; j < HitText_list.Count; j++)
            {
                HitText_list[j].Draw(Game1.spriteBatch);
            }


          //  for(int y=0;y<)

         //   Game1.spriteBatch.DrawString(font, Shot_list.Count.ToString(), new Vector2(10, 10), Color.White);
            Game1.spriteBatch.Begin();
            if (hitMessage != null)
            {
                hitMessage.Draw(Game1.spriteBatch);
            }
            base.Draw(gameTime);
            Game1.spriteBatch.End();
            Ship.Draw(Game1.spriteBatch);
            if (dialog != null)
                dialog.Draw(Game1.spriteBatch);
        }
    }
}
