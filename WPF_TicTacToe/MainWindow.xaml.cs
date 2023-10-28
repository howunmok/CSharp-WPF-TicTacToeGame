using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_TicTacToe
{
    public partial class MainWindow : Window
    {
        private string playerTurn = "X";
        private int xWins = 0;
        private int oWins = 0;
        private static readonly Brush DEFAULTBRUSH = new SolidColorBrush(Color.FromArgb(255, 142, 142, 166));
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Restart(object sender, RoutedEventArgs e)
        {
            ResetAllBtn();
            sp_Winner.Visibility = Visibility.Hidden;
            xWins = 0;
            oWins = 0;
            lb_OWins.Content = "O: 0";
            lb_XWins.Content = "X: 0";
        }
        
        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Click_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by:\nHo Wun Mok", "Information", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Click_Btn(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Foreground = Brushes.Black;
            btn.Content = playerTurn;
            btn.IsEnabled = false;

            // When player wins, display X / O in result
            if(IsWin(btn_A1, btn_A2, btn_A3))
            {
                GameOver(btn_A1.Content.ToString());
            }
            if (IsWin(btn_B1, btn_B2, btn_B3))
            {
                GameOver(btn_B1.Content.ToString());
            }
            if (IsWin(btn_C1, btn_C2, btn_C3))
            {
                GameOver(btn_C1.Content.ToString());
            }
            if (IsWin(btn_A1, btn_B1, btn_C1))
            {
                GameOver(btn_A1.Content.ToString());
            }
            if (IsWin(btn_A2, btn_B2, btn_C2))
            {
                GameOver(btn_A2.Content.ToString());
            }
            if (IsWin(btn_A3, btn_B3, btn_C3))
            {
                GameOver(btn_A3.Content.ToString());
            }
            if (IsWin(btn_A1, btn_B2, btn_C3))
            {
                GameOver(btn_A1.Content.ToString());
            }
            if (IsWin(btn_A3, btn_B2, btn_C1))
            {
                GameOver(btn_A3.Content.ToString());
            }

            // Draw condition
            if(!btn_A1.IsEnabled && !btn_A2.IsEnabled && !btn_A3.IsEnabled &&
                !btn_B1.IsEnabled && !btn_B2.IsEnabled && !btn_B3.IsEnabled &&
                !btn_C1.IsEnabled && !btn_C2.IsEnabled && !btn_C3.IsEnabled)
            {
                GameOver("");
            }
            
            // Exchange player
            playerTurn = playerTurn == "X" ? "O" : "X";
            
        }

        private bool IsWin(Button btn1, Button btn2, Button btn3)
        {
            // Check win requirement
            return !btn1.IsEnabled && btn1.Content == btn2.Content && btn1.Content == btn3.Content;
        }
            
        private void GameOver(string player)
        {
            // Prevent the GameOver method from being executed multiple times when the resuly has already been determined
            if (sp_Winner.Visibility == Visibility.Visible) { return; }

            if(player == "X")
            {
                lb_Winner.Content= "Player X Win!";
                lb_XWins.Content = $"X: {++xWins}";
            }
            else if(player == "O")
            {
                lb_Winner.Content = "Player O Win!";
                lb_OWins.Content = $"O: {++oWins}";
            }
            else
            {
                lb_Winner.Content = "Draw! No winner";
                lb_Winner.FontSize = 40;
            }

            // Display result StackPanel
            sp_Winner.Visibility = Visibility.Visible;

        }

        private void Enter_Btn(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Content = playerTurn;
        }

        private void Leave_Btn(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.IsEnabled)
            {
                btn.Content = "";
            }
        }

        private void ResetBtns (Button btn)
        {
            btn.Content = "";
            btn.IsEnabled = true;
            btn.Foreground = DEFAULTBRUSH;
        }

        private void ResetAllBtn()
        {
            ResetBtns(btn_A1);
            ResetBtns(btn_A2);
            ResetBtns(btn_A3);
            ResetBtns(btn_B1);
            ResetBtns(btn_B2);
            ResetBtns(btn_B3);
            ResetBtns(btn_C1);
            ResetBtns(btn_C2);
            ResetBtns(btn_C3);
        }

        private void Click_Reset(object sender, RoutedEventArgs e)
        {
            sp_Winner.Visibility = Visibility.Hidden;
            ResetAllBtn();
        }
    }
}
