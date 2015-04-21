using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace WindowsGame1.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputManager : Microsoft.Xna.Framework.GameComponent
    {
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;

        public InputManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            keyboardState = Keyboard.GetState();
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
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyNotReleased(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyDown(key);
        }
    }
}
