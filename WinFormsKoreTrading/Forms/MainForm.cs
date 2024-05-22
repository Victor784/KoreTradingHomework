using System.ComponentModel;
using WinFormsKoreTrading.Model;
using WinFormsKoreTrading.Services;

namespace WinFormsKoreTrading
{
    public partial class MainForm : Form
    {   
        private BindingList<Person> _persons;
        private PersonUpdator _personUpdater;

        public MainForm(BindingList<Person> pers, PersonUpdator persUpdator)
        {
            InitializeComponent();
            setUpDataGridView();
            _persons = pers;
            _personUpdater = persUpdator;

            LoadData();

            this.KeyPreview = true;
        }
        private void LoadData()
        {
            dataGridView1.DataSource = _persons;
        }

        private void setUpDataGridView()
        {
            dataGridView1.VirtualMode = true;
            dataGridView1.CellValueNeeded += dataGridView1_CellValueNeeded;
            dataGridView1.ReadOnly = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _persons.Count)
            {
                var person = _persons[e.RowIndex];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = person.Name;
                        break;
                    case 1:
                        e.Value = person.Age;
                        break;
                    case 2:
                        e.Value = person.Occupation;
                        break;
                    case 3:
                        e.Value = person.Gender;
                        break;
                    case 4:
                        e.Value = person.City;
                        break;

                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MainForm newForm = new MainForm(_persons, _personUpdater);
                newForm.Show();
            }
        }


    }
}
