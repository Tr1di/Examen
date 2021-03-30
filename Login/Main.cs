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
            // Открыть авторизацию сразу при запуске прложения
            Login();
        }

        private void Login()
        {
            // Диалог авторизации
            var dialog = new LoginDialog();

            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                User = dialog.User;
                panel1.BackgroundImage = User.Photo;

                // Показать все панели, скрытые от текущего пользователя
                foreach (Panel panel in Controls.OfType<Panel>()) { panel.Show(); }

                // Отобразить функционал, доступный данному типу пользователей
                // (Скрыть остальной через рольPanel.Hide())
                switch (User.Type)
                {
                    case "Директор":
                        // Оставить окно директора
                        customerPanel.Hide();
                        break;
                    case "Заказчик":
                        // Оставить окно заказчика
                        directorPanel.Hide();
                        break;
                    // И так далее для каждого типа пользователя
                    default:
                        // Что делать для остальных
                        // Например, скрыть всё
                        directorPanel.Hide();
                        customerPanel.Hide();
                        break;
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке", "");
        }
    }
}
