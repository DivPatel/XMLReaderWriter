using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace XMLReaderWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Read the XML file , already created by user, you can create your own
            XmlTextReader reader = new XmlTextReader("D:\\DIVYESH's DRIVE\\SEMESTER 5\\Visual Programming\\Databased\\XMLReaderWriter\\XMLReaderWriter\\XMLFile1.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                    MessageBox.Show(reader.Value);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //generate(Write) file by programme, path must be change to inorder to run or it will show "path wrong error"
            XmlTextWriter writer = new XmlTextWriter("C:\\Users\\Divyesh\\Desktop\\App.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Products");
            createnode("1", "Product 2", "100", writer);
            createnode("2", "Product 3", "1000", writer);
            createnode("3", "Product 4", "10000", writer);
            createnode("4", "Product 5", "100000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("created");

        }
        private void createnode(string pid, string pname, string pprice, XmlTextWriter writer)
        {
            writer.WriteStartElement("Product");
            writer.WriteStartElement("Product_id");
            writer.WriteString(pid);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_name");
            writer.WriteString(pname);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_price");
            writer.WriteString(pprice);
            writer.WriteEndElement();
            writer.WriteEndElement();



        }


        private void button2_Click(object sender, EventArgs e)
        {
            //need to change connection string, get it from property tab of your VS ,its name is divyeshdb.mdf
            SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = D:\\DIVYESH's DRIVE\\SEMESTER 5\\Visual Programming\\Databased\\XMLReaderWriter\\XMLReaderWriter\\divyeshdb.mdf; Integrated Security = True");
            conn.Open();
            DataSet dataset = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Table]", conn);
            da.Fill(dataset);
            dataset.WriteXml("STU.xml");
            MessageBox.Show("created");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filename = @"D:\\DIVYESH's DRIVE\\SEMESTER 5\\Visual Programming\\Databased\\XMLReaderWriter\\XMLReaderWriter\\XMLFile1.xml";
            DataSet d = new DataSet();
            d.ReadXml(filename);
            dataGridView1.DataSource = d.Tables[0];
        }
    }
}
