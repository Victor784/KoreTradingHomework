using System.ComponentModel;
using WinFormsKoreTrading.Model;
using WinFormsKoreTrading.Services;

namespace WinFormsKoreTrading
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int nrOfPersons = 10000;
            BindingList<Person> _persons = new BindingList<Person>(PersonGenerator.GeneratePersons(nrOfPersons));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PersonUpdator _persUpdator = new PersonUpdator(_persons, null);

            MainForm mainForm = new MainForm(_persons, _persUpdator);
            _persUpdator.SetUIControl(mainForm);
            Application.Run(mainForm);

        }
    }
}