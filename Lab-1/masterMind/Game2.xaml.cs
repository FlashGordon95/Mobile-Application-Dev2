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
    public sealed partial class Game2 : Page
    {
        int _numberMoves = 10;
        public Game2()
        {
            int i;
            this.InitializeComponent();
            // read the number of moves from save state variable
            i = _numberMoves;
            // create the board
            createBoard(i);

        }

        private void createBoard(int numTurns)
        {
            // use a loop to add turns
            // add a stackpanel that holds stack panel and grid
            // with the 4 player pegs and the feedback
            int i, j, iPegs = 4;
            StackPanel spTurn;
            Ellipse el;
            Grid grd;
            RowDefinition rowD;
            ColumnDefinition colD;
           

            for (i = 0; i < numTurns; i++)
            {
                #region Create SingleTurn Stack Panel
                spTurn = new StackPanel();
                spTurn.Name = "spSingleTurn" + i.ToString();
                spTurn.Orientation = Orientation.Horizontal;
                spTurn.HorizontalAlignment = HorizontalAlignment.Center;
                spTurn.Height = 36;
                // add that to the playerturns
                spPlayerTurns.Children.Add(spTurn);
                #endregion

                #region Create the Player Pegs
                for (j = 0; j < iPegs; j++)
                {
                    el = new Ellipse();
                    el.Name = "elPlayPeg" + j.ToString();
                    el.Height = 22;
                    el.Width = 22;
                    el.Fill = new SolidColorBrush(Colors.Transparent);
                    el.Stroke = new SolidColorBrush(Colors.Black);
                    el.Margin = new Thickness(4);
                    spTurn.Children.Add(el);
                }

                #endregion

                #region Create the Feedback Pegs
                // create a grid
                grd = new Grid();
                grd.Name = "grdFeedback" + i.ToString();
                grd.Height = 30;
                grd.Width = 30;
                grd.Margin = new Thickness(3);
                spTurn.Children.Add(grd);
                // add rows and columns
                rowD = new RowDefinition();
                grd.RowDefinitions.Insert(grd.RowDefinitions.Count, rowD);
                rowD = new RowDefinition();
                grd.RowDefinitions.Insert(grd.RowDefinitions.Count, rowD);

                colD = new ColumnDefinition();
                grd.ColumnDefinitions.Insert(grd.ColumnDefinitions.Count, colD);
                colD = new ColumnDefinition();
                grd.ColumnDefinitions.Insert(grd.ColumnDefinitions.Count, colD);
                // add the ellipses (copy the code above)
                for (j = 0; j < 2; j++) // rows
                {
                    for (int k = 0; k < 2; k++) // cols
                    {
                        el = new Ellipse();
                        el.Name = "elFeedback" + j.ToString() + "_" + k.ToString();
                        el.Height = 11;
                        el.Width = 11;
                        el.Fill = new SolidColorBrush(Colors.Transparent);
                        el.Stroke = new SolidColorBrush(Colors.Black);
                        el.Margin = new Thickness(2);
                        el.SetValue(Grid.RowProperty, j);
                        el.SetValue(Grid.ColumnProperty, k );

                        grd.Children.Add(el);
                    }
                }
                #endregion

            }
        }
    }
}
