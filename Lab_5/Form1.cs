using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Equin.ApplicationFramework;
namespace Lab_5
{
    public partial class Form1 : Form
    {
        VacanciesRegister vacancies;
        BindingListView<Vacancy> vacanciesView; 
        public Form1()
        {
            InitializeComponent();
            statusStrip1.Text = Convert.ToString(DateTime.Now);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //string organization, string position, string qualification, double experience, decimal salary, bool insurance, int vacation)
            XDocument xDocument = XDocument.Load("config.xml");
            IEnumerable<Vacancy> vacanciesSequence = xDocument.Root.Elements("Vacancy").Select(item => new Vacancy(
            item.Element("Organization").Value,
            item.Element("Position").Value,
            item.Element("Qualification").Value,
            (double)item.Element("Experience"),
            (decimal)item.Element("Salary"),
            (bool)item.Element("Insurance"),
            (int)item.Element("Vacation")
            
        )); 
            vacancies = new VacanciesRegister(vacanciesSequence);



            vacanciesView = new BindingListView<Vacancy>(vacancies.Vacancies);
            bindingSource1.DataSource = vacanciesView;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveData();

        }

        private void SaveData()
        {
            XDocument xDocument = new XDocument();
            IEnumerable<XElement> vacanciesSequence = vacanciesView.Select(item => new XElement("Vacancy",
            new XElement("Organization", item.Organization),
            new XElement("Position", item.Position),
            new XElement("Qualification", item.Qualification),
            new XElement("Experience", item.Experience),
            new XElement("Salary", item.Salary),
            new XElement("Insurance", item.Insurance),
            new XElement("Vacation", item.Vacation)
        ));
            xDocument.Add(new XElement("Vacancies", vacanciesSequence));
            xDocument.Save("config.xml");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveData();
        }

     

      

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            checkBox1.Checked = false;
            vacanciesView.ApplyFilter(item => item.Vacation>1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string str1= textBox1.Text;
            string str2 = textBox2.Text; 
            decimal salary =Decimal.Parse(textBox3.Text);
            int vacation = int.Parse(textBox4.Text);

            bool b;
            if (checkBox1.Checked)
            {
                //b = true;
                //vacanciesView.ApplyFilter(item => item.Insurance.Equals(true));
                vacanciesView.ApplyFilter(item => item.Insurance.Equals(true) && item.Position.Contains(str1) && item.Qualification.Contains(str2) && item.Salary>= salary && item.Vacation >= vacation);
            }
            else
            {
                vacanciesView.ApplyFilter(item => item.Insurance.Equals(false) && item.Position.Contains(str1) && item.Qualification.Contains(str2) && item.Salary >= salary && item.Vacation >= vacation);
                //b = false;
                //vacanciesView.ApplyFilter(item => item.Insurance.Equals(false));
            }
            //MessageBox.Show(b.ToString());
        }
    }
}
