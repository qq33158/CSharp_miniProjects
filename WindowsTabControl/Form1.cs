using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTabControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Member
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public bool IsMarry { get; set; }
        }
        List<Member> members = new List<Member>();
        private void Form1_Load(object sender, EventArgs e)
        {
            txtShow.Dock = DockStyle.Fill;
            txtShow.Font = new Font(txtShow.Font.FontFamily, 11, FontStyle.Regular);
            txtShow.ReadOnly = true;
            rdbF.Checked = true;
            chkIsMarry.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (rdbM.Checked)
            {
                gender = "先生";
            }
            else
            {
                gender = "小姐";
            }
            members.Add(new Member()
            {
                ID = txtId.Text,
                Name = txtName.Text,
                Gender = gender,
                IsMarry = chkIsMarry.Checked
            });

            MessageBox.Show("會員新增成功");

            txtId.Text = "";
            txtName.Text = "";
            rdbF.Checked = true;
            chkIsMarry.Checked = false;
        }
        // 請留意txtshow的Multiline屬性要設定為ture, Environment.NewLine才有作用
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                txtShow.Text = "編號\t姓名\t性別\t是否已婚" + Environment.NewLine;
                txtShow.Text += "================================" + Environment.NewLine;
                for (int i = 0; i < members.Count; i++)
                {
                    txtShow.Text += $"{members[i].ID}\t" + $"{members[i].Name}\t{members[i].Gender}\t" +
                                    $"{(members[i].IsMarry? "是": "否")}" + Environment.NewLine;
                }
            }
        }
    }
}
