
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1.GameComponents
{
    public enum DrawMode { Center, Fill }
    class BackgroundComponent
    {
        Rectangle ScreenRectangle;
        Rectangle destination;
        Rectangle destination2;
        Texture2D image;
        DrawMode drawMode;
        int BackgroundLocation_X = 0;
        int BackgroundLocation_Y = 0;
        int BackgroundLocation_Upper_Y = 0;
        int Bounds_Width = 0;
        int Bounds_Height = 0;

        public bool Visible
        {
            get;
            set;
        }

        public BackgroundComponent(Game game, Texture2D image, DrawMode drawMode)
        {
            Visible = true;
            this.image = image;
            this.drawMode = drawMode;
            BackgroundLocation_X = ScreenRectangle.X;
            BackgroundLocation_Y = ScreenRectangle.Y;

            Bounds_Width = game.Window.ClientBounds.Width;
            Bounds_Height = game.Window.ClientBounds.Height;
            BackgroundLocation_Upper_Y = (-1) * Bounds_Height;

            ScreenRectangle = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);

            switch (drawMode)
            {
                case DrawMode.Center:
                    destination = new Rectangle((ScreenRectangle.Width - image.Width) / 2, (ScreenRectangle.Height - image.Height) / 2, image.Width, image.Height);

                    break;
                case DrawMode.Fill:

                    destination = new Rectangle(BackgroundLocation_X, BackgroundLocation_Y, image.Width, image.Height);
                    break;


            }
        }

        public void Update()
        {

            BackgroundLocation_Y--;
            if (BackgroundLocation_Y == Bounds_Height)
                BackgroundLocation_Y -= Bounds_Height;

            BackgroundLocation_Upper_Y--;
            if (BackgroundLocation_Upper_Y == 0)
                BackgroundLocation_Upper_Y -= Bounds_Height;
        }

        public void Draw(SpriteBatch SpriteBatch)
        {

            destination2 = new Rectangle(BackgroundLocation_X, BackgroundLocation_Upper_Y, Bounds_Width, Bounds_Height);
            destination = new Rectangle(BackgroundLocation_X, BackgroundLocation_Y, Bounds_Width, Bounds_Height);
          

            if (Visible)
            {
                SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap,
     DepthStencilState.Default, RasterizerState.CullNone);
                SpriteBatch.Draw(image, Vector2.Zero, destination2, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                SpriteBatch.Draw(image, Vector2.Zero, destination, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            
                SpriteBatch.End();

            }

        }
    }
}
