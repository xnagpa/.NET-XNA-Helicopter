using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MenuComponent 
    {
        string[] menuItems;
        int selectedIndex;
        float width;
        float height;
        Vector2 position;
        SpriteFont spriteFont;
        //SpriteBatch spriteBatch =new SpriteBatch(;

        //Конструктор
        #region Constructor
      

        public Color HiliteColor
        {
            get;
            set;
        }

        public Color NormalColor
        {
            get;
            set;
        }

        public float Width
        {
            get { return width; }
           
        }
        
        public float Height
        {
            get { return height; }

        }

        public float SelectedIndex
        {
            get { return selectedIndex ; }

        }
        //Конструктор
#endregion

        public MenuComponent(SpriteFont font, string[] items)
        {
            this.spriteFont = font;
            SetMenuItems(items);
            NormalColor = Color.White;
            HiliteColor = Color.Green;

        }

        #region Methods
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void SetMenuItems(string[] menuItems)
        {
            this.menuItems = (string[])menuItems.Clone();
            MeasureMenu();
        }

        private void MeasureMenu()
        {
            width = 0;
            height = 0;
            foreach(string s in menuItems)
            {
                if (width < spriteFont.MeasureString(s).X)
                    width = spriteFont.MeasureString(s).X;
                height += spriteFont.LineSpacing;
            }
        }

        public void Update()
        {
            if (InputManager.KeyReleased(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuItems.Length - 1;
            }

            if (InputManager.KeyReleased(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex >= menuItems.Length)
                    selectedIndex = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 menuPosition = position;

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(spriteFont, menuItems[i], new Vector2(menuPosition.X+1,menuPosition.Y+1), Color.Black);
                    spriteBatch.DrawString(spriteFont, menuItems[i], menuPosition, HiliteColor);

                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(spriteFont, menuItems[i], new Vector2(menuPosition.X + 1, menuPosition.Y + 1), Color.Black);
                    spriteBatch.DrawString(spriteFont, menuItems[i], menuPosition, NormalColor);
                    spriteBatch.End();
                }
                menuPosition.Y += spriteFont.LineSpacing;
            }
        }
        #endregion
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
     

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
     
    }
}
