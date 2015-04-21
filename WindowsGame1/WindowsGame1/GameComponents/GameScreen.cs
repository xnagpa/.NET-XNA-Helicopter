using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1.EventArguments;


namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameScreen : DrawableGameComponent
    {
        List<GameComponent> childComponents;
        protected ContentManager Content;

        public List<GameComponent> ChildComponents
        {
            get { return childComponents; }
        }

        public GameScreen(Game game)
            : base(game)
        {
            childComponents = new List<GameComponent>();
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
            foreach (GameComponent game in childComponents)
            {
                if (game.Enabled)
                    game.Update(gameTime);
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComponent;
            foreach (GameComponent game in childComponents)
            {
                if (game is DrawableGameComponent)
                {
                    drawComponent = game as DrawableGameComponent;

                    if (drawComponent.Visible)

                        drawComponent.Draw(gameTime);
                }
            }

            base.Update(gameTime);
        }

        internal protected virtual void ScreenChange(object sender,ScreenEventArgs e)
        {
            if (e.GameScreen == this)
            {
                Show();
            }
            else
                Hide();
        }

        private void Show()
        {
            Visible = true;
            Enabled = true;
            foreach(GameComponent component in ChildComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;
            }

        }

        private void Hide()
        {
            Visible = false;
            Enabled = false;
            foreach (GameComponent component in ChildComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }
    }
}
