using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WindowsGame1.GameComponents;
using WindowsGame1.TileEngine;

namespace WindowsGame1.GameScreens
{
   
    class StartScreen : GameScreen
    {
        MenuComponent menu;
        SpriteFont spriteFont;
        string[] menuItems = { "New Game", "Load Game", "Exit" };
        ScreenManager Manager;
        GamePlayScreen gamePlayScreen;
        BackgroundComponent Background;
        Texture2D Back;
        Texture2D Tile_texture;
     
        Game game2;
        TileSet tileset;
      
        string str = "Serial #: CE4WE0-0D0040-EC162F-1E16AA-A6676A";

        public StartScreen(Game game, ScreenManager manager)
            : base(game)
        {
            Content = Game.Content;
            this.Manager=manager;
         //  
            game2 = game;
            gamePlayScreen = new GamePlayScreen(game);
           
            
        }

        protected override void LoadContent()
        {
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            menu = new MenuComponent(spriteFont, menuItems);
            menu.SetPosition(new Vector2(400,400));
            Back = Content.Load<Texture2D>("shovless");
           
            Background = new BackgroundComponent(game2, Back, DrawMode.Fill);
            Tile_texture = Content.Load<Texture2D>("tile");
            tileset = new TileSet(Game,Tile_texture,new Vector2(50,50),new Point(100,100),new Point(0,0),new Point(4,0),1);
           
            Vector2 str_length = spriteFont.MeasureString(str);
            if (str_length.X>100)
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            menu.Update();
          
            tileset.Update(gameTime);
            if (InputManager.KeyPressed(Keys.Enter))
            {
                switch ((int)menu.SelectedIndex)
                {
                    case 0:
                        Manager.ChangeScreens(gamePlayScreen);
                        this.Dispose();
                        break;
                    case 1:
                        Manager.ChangeScreens(gamePlayScreen);
                        this.Dispose();
                        break;
                    case 2:
                        Game.Exit();
                        this.Dispose();
                        break;

                }
            }
            Background.Update();
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Background.Draw(Game1.spriteBatch);
            menu.Draw(Game1.spriteBatch);
            tileset.Draw(Game1.spriteBatch,new Vector2(60,100));
           
            Game1.spriteBatch.Begin();
           
         //   Game1.spriteBatch.DrawString(spriteFont, str, new Vector2( 1,  1), Color.White);
            Game1.spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
