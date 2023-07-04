using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS408ClientSide
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;


        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button3_Select_Click(object sender, EventArgs e)
        {

            try
            {
                string SelectedGrid = textBox_GridSel.Text;

                if (SelectedGrid != "" && SelectedGrid.Length <= 1024)
                {
                    Byte[] buffer = Encoding.Default.GetBytes(SelectedGrid);
                    clientSocket.Send(buffer);
                }

                logs.AppendText("Grid " + SelectedGrid + " is selected.\n");

                Thread receiveThread = new Thread(Receive);
                receiveThread.Start();

            }
            catch
            {
                logs.AppendText("Problem occured while selecting...\n");
            }
        }

        private void button1_Connect_Click_1(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_ip.Text;
            button_disconnect.Enabled = true;
            int portNum;
            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    string name = textBox_name.Text;
                    if (name != "" && name.Length <= 64)
                    {
                        Byte[] buffer_name = Encoding.Default.GetBytes(name);
                        clientSocket.Send(buffer_name);
                    }

                    Byte[] buffer_server_response = new Byte[8];

                    clientSocket.Receive(buffer_server_response);
                    string server_response = Encoding.Default.GetString(buffer_server_response);
                    server_response = server_response.Substring(0, server_response.IndexOf("\0"));


                    /*
                     * The followings are the scenarios to follow according to the server response 
                     * after the client tries to connect
                     */

                    if (server_response == "Yes") // can connect and there is no game in play
                    {
                        textBox_ip.Enabled = textBox_name.Enabled = textBox_port.Enabled = button_connect.Enabled = false;
                        connected = true;

                        logs.AppendText("Connected to the server!\n\n");
                        logs.AppendText("Succesfully connected to the game with the name: " + name + "\n");
                        connected = true;
                        Thread receiveThread = new Thread(Receive);
                        receiveThread.Start();
                    }
                    else if (server_response == "No") // the name is already taken
                    {
                        logs.AppendText("Name is already taken. Please try another name!\n");
                    }
                    else if (server_response == "Full") // server is full
                    {
                        logs.AppendText("The server is full right now. Please try again later!\n");
                    }
                    else if (server_response == "Game") // connected but there is a game already in play
                    {
                        textBox_ip.Enabled = textBox_name.Enabled = textBox_port.Enabled = button_connect.Enabled = false;
                        connected = true;

                        logs.AppendText("Connected to the server!\n\n");
                        Thread receiveThread = new Thread(Receive);
                        connected = true;
                        receiveThread.Start();
                        logs.AppendText("Game already started, Wait until next game!\n");
                    }


                }
                catch
                {
                    logs.AppendText("Problem occured while connecting...\n");
                }
            }
            else
            {
                logs.AppendText("Check the port\n");
            }
        }

        private void Receive()
        {
            String instructions;

            while (connected)
            {
                try
                {
                    Byte[] buffer_question = new Byte[1024];
                    clientSocket.Receive(buffer_question);
                    string incomingMessage = Encoding.Default.GetString(buffer_question);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    if (incomingMessage.Contains("\x4"))
                    {
                        incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\x4"));
                        logs.AppendText(incomingMessage + "\nGame Ended.\n\n");
                    }
                    else
                    {
                        if (incomingMessage.Contains("yourTurn"))  // this client's turn. Enable grid selection
                        {
                            logs.AppendText("Your Turn!\n");
                            textBox_GridSel.Enabled = button_Select.Enabled = true;
                        }
                        else if (incomingMessage.Contains("GameSt")) // game grid is sent
                        {
                            game_rtb.Clear();
                            game_rtb.Focus();
                            incomingMessage = incomingMessage.Replace("GameSt", "");
                            game_rtb.AppendText(incomingMessage + "\n");
                        }
                        else if (incomingMessage.Contains("newGame")) // new game is started
                        {
                            game_rtb.Clear();
                            game_rtb.Focus();
                            logs.AppendText("Started a new game!!" + "\n");
                            textBox_GridSel.Enabled = button_Select.Enabled = false;
                        }
                        else if (incomingMessage.Contains("terminate")) // game is terminated by server. Close socket and form
                        {
                            game_rtb.Clear();
                            game_rtb.Focus();
                            logs.Clear();
                            logs.Focus();
                            logs.AppendText("The game is terminated by server\n");
                            Thread.Sleep(3000);
                            clientSocket.Close();
                            this.Close();
                            textBox_GridSel.Enabled = button_Select.Enabled = false;
                        }
                        else if (incomingMessage.Contains("notYourTurn"))  // Not this client's turn. Disable grid selection
                        {
                            logs.AppendText("Its not your turn. Wait. \n");
                            textBox_GridSel.Enabled = button_Select.Enabled = false;
                        }
                        else if (incomingMessage.Contains("instructions")) // sent instructions
                        {
                            logs.AppendText(incomingMessage.Replace("instructions", "") + "\n");
                            instructions = incomingMessage.Replace("instructions", "") + "\n";
                            textBox_GridSel.Enabled = true;
                        }
                        else if (incomingMessage.Contains("invalidCell")) // cell selection negative response
                        {
                            logs.AppendText("Invalid Cell Number! \n");
                            textBox_GridSel.Enabled = button_Select.Enabled = true;
                        }
                        else if (incomingMessage.Contains("cellFull")) // cell selection negative response
                        {
                            logs.AppendText("That cell is already taken. Please choose another one! \n");
                            textBox_GridSel.Enabled = button_Select.Enabled = true;
                        }
                        else
                        {
                            logs.AppendText(incomingMessage + "\n");
                            textBox_GridSel.Enabled = button_Select.Enabled = false;
                        }

                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n");
                        button_connect.Enabled = true;
                        textBox_ip.Enabled = true;
                        textBox_port.Enabled = true;
                        textBox_name.Enabled = true;
                        button_disconnect.Enabled = true;
                        textBox_GridSel.Enabled = false;
                        button_Select.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button2_Disconnect_Click(object sender, EventArgs e)
        {
            logs.AppendText("You have disconnected from the server.\n");
            button_connect.Enabled = true;
            textBox_ip.Enabled = true;
            textBox_port.Enabled = true;
            textBox_name.Enabled = true;
            button_disconnect.Enabled = false;
            textBox_GridSel.Enabled = false;
            button_Select.Enabled = false;
            clientSocket.Close();
            connected = false;
        }

        private void textBox4_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void logs_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            logs.SelectionStart = logs.Text.Length;
            // scroll it automatically
            logs.ScrollToCaret();
        }

        private void game_rtb_TextChanged(object sender, EventArgs e)
        {
            //logs.SelectionFont = new Font("Tahoma", 12, FontStyle.Bold);
        }
    }
}
