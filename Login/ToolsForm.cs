using System;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    enum OrderField
    {
        Name,
        PurchaseDate
    }

    public partial class ToolsForm : Form
    {
        private String SearchText => searchTextBox.Text;
        private OrderField OrderBy => (OrderField)comboBox4.SelectedIndex;
        private bool OrderDesc => checkBox1.Checked;
        
        public ToolsForm()
        {
            InitializeComponent();

            comboBox4.DataSource = Enum.GetValues(typeof(OrderField));
            comboBox4.SelectedIndex = 0;
            
            UpdateList();

            usersComboBox.DataSource = User.GetAll();
        }

        /// <summary>
        /// Обновление списка инструментов
        /// </summary>
        private void UpdateList()
        {
            var query = DataBase.Session.Query<Tool>();
            
            if (!string.IsNullOrEmpty(SearchText))
            {
                query = query.Where(x => x.Name.Contains(SearchText) || x.Description.Contains(SearchText));
            }

            var ordered = query.OrderBy(x => x.Name);
            
            switch (OrderBy)
            {
                case OrderField.Name:
                    if (OrderDesc) query.OrderByDescending(x => x.Name);
                    break;
                case OrderField.PurchaseDate:
                    if (OrderDesc) query.OrderByDescending(x => x.Purchased);
                    else query.OrderBy(x => x.Purchased);
                    break;
            }
            
            toolsList.DataSource = ordered.ToList();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DataBase.Session.Save(new Tool
            {
                Name = textBox1.Text,
                Description = richTextBox1.Text,
                Purchased = dateTimePicker1.Value,
                Count = (int)numericUpDown1.Value,
                Owner = usersComboBox.SelectedItem as User
            });
            DataBase.Session.Flush();

            UpdateList();
        }

        private void deleteToolButton_Click(object sender, EventArgs e)
        {
            DataBase.Session.Delete(toolsList.SelectedItem);
            DataBase.Session.Flush();

            UpdateList();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
