using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var login = Properties.Settings.Default.SavedLogin;

            if ( !string.IsNullOrEmpty(login) )
            {
                var user = User.ByLogin(login);

                if (user?.Password == Properties.Settings.Default.SavedPasswword)
                {
                    SetupFor(user);
                    return;
                }
            }

            // Открыть авторизацию сразу при запуске прложения
            Login();
        }

        private void SetupFor(User user)
        {
            User = user;
            panel1.BackgroundImage = User.Photo;

            // Показать все панели, скрытые от текущего пользователя
            foreach (Panel panel in Controls.OfType<Panel>()) { panel.Show(); }

            // Отобразить функционал, доступный данному типу пользователей
            // (Скрыть остальной через panel.Hide())
            switch (User.Type)
            {
                case "Директор":
                    // Оставить окно директора
                    break;
                case "Менеджер":
                    // Оставить окно менеджера
                    break;
                // И так далее для каждого типа пользователя
                default:
                    // Что делать для остальных
                    panel2.Hide();
                    break;
            }
        }

        private void Login()
        {
            // Диалог авторизации
            var dialog = new LoginDialog();

            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                SetupFor(dialog.User);
            }
            else // Если окно было закрыто без авторизации, то закрыть приложение
            {
                Application.Exit();
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Пользователь больше не войден в этот профиль
            User = null;

            Properties.Settings.Default.SavedLogin = "";
            Properties.Settings.Default.SavedPasswword = "";
            Properties.Settings.Default.Save();

            // Скрыть окно, оставив только диалог входа
            Hide();

            // Начать авторизацию пользователя
            Login();

            // Показать окно обратно
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ToolsForm().ShowDialog();
        }
    }
}
