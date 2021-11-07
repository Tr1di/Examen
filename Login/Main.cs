using System;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class Main : Form
    {
        public User User { get; private set; }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Открыть авторизацию сразу при запуске прложения
            Login();
        }

        private void Login()
        {
            var dialog = new LoginDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                User = dialog.User;
                panel1.BackgroundImage = User.Photo;
                
                foreach (Panel panel in Controls.OfType<Panel>()) { panel.Show(); }

                // Отобразить функционал, доступный данному типу пользователей
                switch (User.Type)
                {
                    case "Директор":
                        break;
                    case "Менеджер":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User = null;
            
            Hide();
            Login();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ToolsForm().ShowDialog();
        }
    }
}
