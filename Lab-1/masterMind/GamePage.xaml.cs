using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MastermindTake1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        public GamePage()
        {
            this.InitializeComponent();
            // if game not in progress, then create a new board.
            // if game in progress, retrieve and show it.
            // first retrieve the settings, how many goes, how many pegs
            createNewBoard(6);

        }

        private void createNewBoard(int numberTurns)
        {

            // stack panel for all turns
            StackPanel spAllTurns = new StackPanel();
            spAllTurns.HorizontalAlignment = HorizontalAlignment.Center;
            spAllTurns.VerticalAlignment = VerticalAlignment.Center;


            // creates the container for turn
            StackPanel spSingleTurn;

            for (int i = 0; i < numberTurns; i++)
            {                
                spSingleTurn = new StackPanel();
                spSingleTurn.Name = "Turn_" + i.ToString();
                spSingleTurn.Height = 46;
                spSingleTurn.Margin = new Windows.UI.Xaml.Thickness(10);
                spSingleTurn.Orientation = Orientation.Horizontal;

                #region Create the Player Pegs

                // create the container for the player pegs
                StackPanel spPlayerPegs = new StackPanel();
                spPlayerPegs.Orientation = Orientation.Horizontal;
                spPlayerPegs.Margin = new Thickness(5);
                spPlayerPegs.Name = "PPegs_" + i.ToString();

                // for each turn, create 4 pegs.
                Ellipse myEllipse;
            
                for( int j = 0; j < 6; j++)
                {
                    myEllipse = new Ellipse();
                    myEllipse.Height = 30;
                    myEllipse.Width = 30;
                    myEllipse.Margin = new Thickness(3);
                    myEllipse.Fill = new SolidColorBrush(Colors.Transparent);
                    myEllipse.Stroke = new SolidColorBrush(Colors.Gray);
                    myEllipse.StrokeThickness = 1;

                    myEllipse.Name = "elPlayPeg_" + i.ToString() + "_" + j.ToString();
                    spPlayerPegs.Children.Add(myEllipse);

                }
                // add the pegs to the single turn
                spSingleTurn.Children.Add(spPlayerPegs);
                #endregion

                #region Create the Feedback Pegs

                // you add this:-)
                Grid grdFeedback = new Grid();

                #endregion

                // add the turn to the game grid
                spAllTurns.Children.Add(spSingleTurn);

            } // end for loop creating turns.

            grdGameGrid.Children.Add(spAllTurns);


        }

    }
}
