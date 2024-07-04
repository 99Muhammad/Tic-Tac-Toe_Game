using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        int Count = 0;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color black = Color.FromArgb(255, 255, 255, 255);
            Pen pen =new Pen(black);
            pen.Width = 10;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 350, 80, 350, 350);
            e.Graphics.DrawLine(pen, 500, 80, 500,350);


            e.Graphics.DrawLine(pen, 250, 170, 600, 170);
            e.Graphics.DrawLine(pen, 250, 270, 600, 270);

        }
        private void _ChangeImage(Button btn, EventArgs e)
        {

            if (btn.Tag.ToString() != "?")
            {
                MessageBox.Show("This option has been selected ,try another one!"
                  , "Error" ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            switch(lbl_Turn.Text)
            {
                case "Player1":
                    {
                        //_CheckWinner();
                        lbl_Turn.Text = "Player2";
                        btn.BackgroundImage = Resources.cross;
                        btn.Tag = "X";
                        break;
                    }
                case "Player2":
                    {
                        //_CheckWinner();
                        lbl_Turn.Text = "Player1";
                        btn.BackgroundImage = Resources.letter_o;
                        btn.Tag = "O";
                        break;
                    }
            }


        }

        private void button_Click(object sender, EventArgs e)
        {
            //if(++Count>9)
            //{
            //    _EndGame((Button)sender);
            //}
            ++Count;
            _ChangeImage((Button)sender, e);
            _CheckWinner();
        }
        private void _EnabledAndDisabledButtons( bool ToEnableOrDisableButtons)
        {
            button1.Enabled = ToEnableOrDisableButtons;
            button2.Enabled = ToEnableOrDisableButtons;
            button3.Enabled = ToEnableOrDisableButtons;
            button4.Enabled = ToEnableOrDisableButtons;
            button5.Enabled = ToEnableOrDisableButtons;
            button6.Enabled = ToEnableOrDisableButtons;
            button7.Enabled = ToEnableOrDisableButtons;
            button8.Enabled = ToEnableOrDisableButtons;
            button9.Enabled = ToEnableOrDisableButtons;
        }

        private void _EndGame(string Tagbtn)
        {
            if (Tagbtn == "X")
            {
                lbl_Winner.Text = "Player1";
                lbl_Turn.Text = "No turn";
                MessageBox.Show("Player1 is winner", "Round result",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
               
                //ToEnableOrDisableButtons = false;
                _EnabledAndDisabledButtons(false);

            }
            else if(Tagbtn == "O")
            {
                lbl_Winner.Text = "Player2";
                lbl_Turn.Text = "No turn";
                MessageBox.Show("Player2 is winner", "Round result",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ToEnableOrDisableButtons = false;

                _EnabledAndDisabledButtons(false);
            }
            else 
            {
                lbl_Winner.Text = "No winner";
                lbl_Turn.Text = "No turn";
                MessageBox.Show("No winner");
               
                //ToEnableOrDisableButtons = false;
                _EnabledAndDisabledButtons(false);
            }
        }

        private void _HilightButtons(Button btn1,Button btn2,Button btn3)
        {
            btn1.BackColor = Color.Green; 
            btn2.BackColor=Color.Green; 
            btn3.BackColor=Color.Green;
        }
        private void _CheckWinner()
        {
            if((button1.Tag.ToString() == button2.Tag.ToString()) &&
           (button1.Tag.ToString()==button3.Tag.ToString())&&
           button1.Tag.ToString()!="?")
            {
                _EndGame(button1.Tag.ToString());
                _HilightButtons(button1, button2, button3);
            }
            else if ((button4.Tag.ToString() == button5.Tag.ToString()) &&
           (button4.Tag.ToString() == button6.Tag.ToString()) &&
           button4.Tag.ToString() != "?")
            {
                _EndGame(button4.Tag.ToString());
                _HilightButtons(button4, button5, button6);
            }
            else if ((button7.Tag.ToString() == button8.Tag.ToString()) &&
           (button7.Tag.ToString() == button9.Tag.ToString()) &&
           button7.Tag.ToString() != "?")
            {
                _EndGame(button7.Tag.ToString());
                _HilightButtons(button7, button8, button9);
            }
            else if ((button1.Tag.ToString() == button4.Tag.ToString()) &&
           (button1.Tag.ToString() == button7.Tag.ToString()) &&
           button1.Tag.ToString() != "?")
            {
                _EndGame(button1.Tag.ToString());
                _HilightButtons(button1, button4, button7);
            }
            else if ((button2.Tag.ToString() == button5.Tag.ToString()) &&
           (button2.Tag.ToString() == button8.Tag.ToString()) &&
           button2.Tag.ToString() != "?")
            {
                _EndGame(button2.Tag.ToString());
                _HilightButtons(button2, button5, button8);
            }
            else if ((button3.Tag.ToString() == button6.Tag.ToString()) &&
           (button3.Tag.ToString() == button9.Tag.ToString()) &&
           button3.Tag.ToString() != "?")
            {
                _EndGame(button3.Tag.ToString());
                _HilightButtons(button3, button6, button9);
            }
            else if ((button1.Tag.ToString() == button5.Tag.ToString()) &&
           (button1.Tag.ToString() == button9.Tag.ToString()) &&
           button1.Tag.ToString() != "?")
            {
                _EndGame(button1.Tag.ToString());
                _HilightButtons(button1, button5, button9);
            }
            else if ((button3.Tag.ToString() == button5.Tag.ToString()) &&
           (button3.Tag.ToString() == button7.Tag.ToString()) &&
           button3.Tag.ToString() != "?")
            {
                _EndGame(button3.Tag.ToString());
                _HilightButtons(button3, button5, button7);
            }
            else if(Count>=9)
            {
                _EndGame("!");
            }
        }

        private void btn_Restart_Click(object sender, EventArgs e)
        {
            _EnabledAndDisabledButtons(true);

            Count = 0;

            button1.BackgroundImage = Resources.question;
            button2.BackgroundImage = Resources.question;
            button3.BackgroundImage = Resources.question;
            button4.BackgroundImage = Resources.question;
            button5.BackgroundImage = Resources.question;
            button6.BackgroundImage = Resources.question;
            button7.BackgroundImage = Resources.question;
            button8.BackgroundImage = Resources.question;
            button9.BackgroundImage = Resources.question;

            button1.Tag = "?";
            button2.Tag = "?";
            button3.Tag = "?";
            button4.Tag = "?";
            button5.Tag = "?";
            button6.Tag = "?";
            button7.Tag = "?";
            button8.Tag = "?";
            button9.Tag = "?";

            lbl_Turn.Text = "Player1";
            lbl_Winner.Text = "In Progress";


            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
            button6.BackColor = Color.Transparent;
            button7.BackColor = Color.Transparent;
            button8.BackColor = Color.Transparent;
            button9.BackColor = Color.Transparent;
 
        }
        private void btn_MouseHover(Button btn, EventArgs e)
        {
            btn.BackColor = Color.Yellow;
        }
        private void btn_MouseLeave(Button btn, EventArgs e)
        {
            btn.BackColor = Color.Transparent;
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            btn_MouseHover((Button)sender, e);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btn_MouseLeave((Button)sender, e);
        }


        //private void button1_MouseHover(object sender, EventArgs e)
        //{
        //    button1.BackColor = Color.Yellow;
        //}

        //private void button1_MouseLeave(object sender, EventArgs e)
        //{
        //    button1.BackColor = Color.Transparent;
        //}
    }
}
