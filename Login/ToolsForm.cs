using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class ToolsForm : Form
    {
        public ToolsForm()
        {
            InitializeComponent();

            // Обновить список инструментов
            UpdateList();

            // Отобразить всех пользователей в списке
            usersComboBox.DataSource = User.GetAll();
        }

        private void UpdateList()
        {
            // Отобразить все инструментов в списке
            listBox1.DataSource = DataBase.Session.Query<Tool>().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание и сохранение нового инструмента
            DataBase.Session.Save(new Tool
            {
                Description = richTextBox1.Text,
                Kupleno = dateTimePicker1.Value,
                Kolichestvo = (int)numericUpDown1.Value,
                Owner = usersComboBox.SelectedItem as User
            });

            // Подтвердить изменения
            DataBase.Session.Flush();

            // Обновить список инструментов
            UpdateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Удалить выбранный инструмент
            DataBase.Session.Delete(listBox1.SelectedItem);

            // Подтвердить изменения
            DataBase.Session.Flush();

            // Обновить список инструментов
            UpdateList();
        }
    }
}
