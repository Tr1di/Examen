using System;
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
            // Пользователь больше не войден в этот профиль
            User = null;

            // Скрыть окно, оставив только диалог входа
            Hide();

            // Диалог авторизации
            var dialog = new LoginDialog();

            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                User = dialog.User;
                panel1.BackgroundImage = User.Photo;

                directorPanel.Visible = User.Type == "Директор";
                customerPanel.Visible = User.Type == "Заказчик";
            }
            else // Если окно было закрыто без авторизации, то закрыть приложение
            {
                Application.Exit();
            }

            // Показать окно обратно
            Show();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Начать авторизацию пользователя
            Login();
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
