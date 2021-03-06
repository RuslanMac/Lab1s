using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_IS1
{
    public partial class Form1 : Form
    {
        public char[,] symbols;

        public string str;

        public Dictionary<char, int> table;

        
        public Form1()
        {
            InitializeComponent();

            symbols = new char[8,9] { 
                { 'а' ,'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з'},
                        { 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р'  },  
                            { 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч',   'ш', 'щ' }, 
                            { 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В' },
                            { 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К'},
                            { 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У'},
                            { 'Ф', 'Х', 'Ц', 'Ч',   'Ш',  'Щ', 'Ъ', 'Ы', 'Ь'  },
                            { 'Э' ,  'Ю', 'Я',  ' ', '.', ':', '!', '?', ',' }
            };




        }

     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string ConvertMessage(string str)
        {
            string str1 = "";
            
            for(int i=0; i<str.Length; i++)
            {
                str1 += FindValue(str[i]); 
            }

            return str1;
        }

        public string ConvertNewMessage(string str1)
        {
            string message = "";
            string strCopy = str1;
            int i = 0;
            int j = 0;
            while (strCopy != "")
            {
                i = Convert.ToInt32(strCopy.Substring(0, 1));
                j = Convert.ToInt32(strCopy.Substring(1, 1));
                message = message + FindOrder(i, j);
                strCopy = strCopy.Substring(2);
            }
            return message;
            
           
        }

        public string FindValue(char symbolKey)
        {
            int i = 0;
            int j = 0;
            while (i < 8 && j < 9 && symbols[i,j] != symbolKey && i+j<17)
            {
                j = j+1;
                if (j > 8)
                {
                    j = 0;
                    i = i +  1;
                }
              
            }
            return i.ToString() + j.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str = this.textBox1.Text;
            string str1;
            string message;
            try
            {
                str1 = ConvertMessage(str);
                this.label3.Text = str1;
                this.label5.Text = "";
                message = ConvertNewMessage(str1);
                this.label5.Text = message;
            }
            catch (Exception ex)
            {
                this.textBox1.Text = "ОШИБКА!!! Ввод не ясен, попробуйте заново.";
                this.label3.Text = "";
                this.label5.Text = "";
               
            }


        }

        public string FindOrder(int i, int j )
        {
            return symbols[i, j].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
