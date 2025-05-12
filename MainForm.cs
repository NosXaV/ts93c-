using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace PhoenixTS93
{
    public partial class MainForm : Form
    {
        private PhoenixClient _client;

        public MainForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Phoenix TS93 Runner by XaV & ChatGPT";
            this.Width = 450;
            this.Height = 300;

            Label label = new Label() { Text = "Wybierz klienta PhoenixBot:", Left = 10, Top = 20, Width = 400 };
            this.Controls.Add(label);

            ComboBox comboClients = new ComboBox() { Name = "comboClients", Left = 10, Top = 50, Width = 400 };
            this.Controls.Add(comboClients);

            Button btnDetect = new Button() { Text = "Wykryj klientów", Left = 10, Top = 90, Width = 150 };
            btnDetect.Click += (sender, args) =>
            {
                var clients = PhoenixClientFinder.FindPhoenixClients();
                comboClients.Items.Clear();
                foreach (var client in clients)
                {
                    comboClients.Items.Add(client);
                }
                if (clients.Count > 0) comboClients.SelectedIndex = 0;
            };
            this.Controls.Add(btnDetect);

            Button btnConnect = new Button() { Text = "Połącz", Left = 170, Top = 90, Width = 100 };
            btnConnect.Click += (sender, args) =>
            {
                if (comboClients.SelectedItem != null)
                {
                    _client = new PhoenixClient(comboClients.SelectedItem.ToString());
                    if (_client.Connect())
                        MessageBox.Show("Połączono z klientem Phoenix.");
                    else
                        MessageBox.Show("Nie udało się połączyć.");
                }
            };
            this.Controls.Add(btnConnect);

            Button btnStart = new Button() { Text = "Start TS93", Left = 280, Top = 90, Width = 130 };
            btnStart.Click += (sender, args) => _client?.RunTS93();
            this.Controls.Add(btnStart);
        }
    }
}