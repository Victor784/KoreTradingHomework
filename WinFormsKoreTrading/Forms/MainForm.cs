using System.ComponentModel;
using WinFormsKoreTrading.Model;
using WinFormsKoreTrading.Services;

namespace WinFormsKoreTrading
{
    public partial class MainForm : Form
    {
        private BindingList<Person> _persons;
        private PersonUpdator _dataUpdater;
        public MainForm(BindingList<Person> _pers)
        {
            InitializeComponent();
            _persons = _pers;
            
            LoadData();
            _dataUpdater = new PersonUpdator(_persons);
            this.KeyPreview = true;
        }
        private void LoadData()
        {
            //TODO move this to some init method or change the name of the data
            dataGridView1.DataSource = _persons;
            dataGridView1.ReadOnly = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MainForm newForm = new MainForm(_persons);
                newForm.Show();
            }
        }


    }
}
