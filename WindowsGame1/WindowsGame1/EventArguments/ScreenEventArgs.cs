using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.GameComponents;

namespace WindowsGame1.EventArguments
{
   public class ScreenEventArgs:EventArgs
    {
       GameScreen gameScreen;
       public GameScreen GameScreen
       {
           get { return gameScreen; }
           set { gameScreen = value; }
       }

       public ScreenEventArgs(GameScreen gameScreen)
       {
           GameScreen = gameScreen;
       }
    }
}
