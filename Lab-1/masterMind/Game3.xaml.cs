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
    public sealed partial class Game3 : Page
    {
        int _numTurns = 10;
        public Game3()
        {
            int iTurns = _numTurns;
            this.InitializeComponent();
            // read from settings the number of turns.
            // pass it to the createBoard function
            createBoard(iTurns);
        }

        private void createBoard(int iTurns)
        {
            int i, j, iPegs = 4;
            StackPanel spTurn;
            Ellipse el;
            Grid grd;

            for (i = 0; i < iTurns; i++)
            {
                #region Create spTurn Stack Panel
                spTurn = new StackPanel();
                spTurn.Name = "spTurn" + i.ToString();
                spTurn.Orientation = Orientation.Horizontal;
                spTurn.Margin = new Thickness(3);
                spTurn.HorizontalAlignment = HorizontalAlignment.Center;
                spAllTurns.Children.Add(spTurn);
                #endregion

                #region Add the player pegs
                for (j = 0; j < iPegs; j++)
                {
                    el = new Ellipse();
                    el.Name = "peg_" + i.ToString() + "_" + j.ToString();
                    // h, w, m, fill, stroke
                    el.Height = 30;
                    el.Width = 30;
                    el.Margin = new Thickness(3);
                    el.Fill = new SolidColorBrush(Colors.Transparent);
                    el.Stroke = new SolidColorBrush(Colors.Black);
                    spTurn.Children.Add(el);
                }
                #endregion

                #region Add the feedback pegs
                grd = new Grid();
                grd.Name = "grdFeedback" + i.ToString();
                grd.Height = 30;
                grd.Width = 30;
                grd.Margin = new Thickness(3);
                grd.RowDefinitions.Insert(grd.RowDefinitions.Count, new RowDefinition());
                grd.RowDefinitions.Insert(grd.RowDefinitions.Count, new RowDefinition());
                grd.ColumnDefinitions.Insert(grd.ColumnDefinitions.Count, new ColumnDefinition());
                grd.ColumnDefinitions.Insert(grd.ColumnDefinitions.Count, new ColumnDefinition());
                spTurn.Children.Add(grd);

                for (int r = 0; r < grd.RowDefinitions.Count; r++)
                {
                    for (int c = 0; c < grd.ColumnDefinitions.Count; c++)
                    {
                        el = new Ellipse();
                        el.Name = "FBPeg_" + i.ToString() + "_" +
                                            r.ToString() + "_" +
                                            c.ToString();
                        el.Fill = new SolidColorBrush(Colors.Transparent);
                        el.Stroke = new SolidColorBrush(Colors.Black);
                        el.Height = 11;
                        el.Width = 11;
                        el.Margin = new Thickness(2);
                        el.SetValue(Grid.RowProperty, r);
                        el.SetValue(Grid.ColumnProperty, c);
                        grd.Children.Add(el);

                    }

                }
                
                
                #endregion

            }



        }
    }
}
