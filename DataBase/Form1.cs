using System.Data;

namespace DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ȡ����ť
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
        }
        //ȷ�ϰ�ť
        private void button1_Click(object sender, EventArgs e)
        {
            if (login())
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
        }
        //�ж��û��������롢Ȩ��
        private bool login()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("���벻����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            switch (comboBox1.Text)
            {
                case "ѧ��":
                    {
                        string sql = "select *from student where sno = '" + textBox1.Text + "' and scode = '" + textBox2.Text + "'";
                        DB db = new DB();
                        IDataReader dr = db.read(sql);
                        if (dr.Read())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("�û������������");
                            return false;
                        }
                    }
                case "��ʦ":
                    {
                        string sql = "select *from teacher where tno = '" + textBox1.Text + "' and tcode = '" + textBox2.Text + "'";
                        DB db = new DB();
                        IDataReader dr = db.read(sql);
                        if (dr.Read())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("�û������������");
                            return false;
                        }
                    }
                case "����Ա":
                    {
                        string sql = "select* from manager where mno='" + textBox1.Text + "' and mcode='" + textBox2.Text + "'";
                        DB dB = new DB();
                        IDataReader dr = dB.read(sql);
                        if (dr.Read())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("�û������������");
                            return false;
                        }
                    }
            }
            return false;
        }
        //��¼״̬
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 180)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                if (comboBox1.Text == "ѧ��")
                {
                    string sql = "select * from student where sno = '" + textBox1.Text + "' and scode = '" + textBox2.Text + "'";
                    DB dB = new DB();
                    IDataReader dr = dB.read(sql);
                    dr.Read();
                    string sno = dr["sno"].ToString();
                    Form3 form3 = new Form3(sno);
                    form3.Show();
                    this.Hide();
                }
                else if (comboBox1.Text == "��ʦ")
                {
                    string sql = "select * from teacher where tno = '" + textBox1.Text + "' and tcode = '" + textBox2.Text + "'";
                    DB dB = new DB();
                    IDataReader dr = dB.read(sql);
                    dr.Read();
                    string tno = dr["tno"].ToString();
                    Form2 form2 = new Form2(tno);
                    form2.Show();
                    this.Hide();
                }
                else if (comboBox1.Text == "����Ա")
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }

                timer1.Stop();
            }
        }
    }
}