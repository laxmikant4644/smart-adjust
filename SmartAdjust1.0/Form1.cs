using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace SmartAdjust1._0
{
    public partial class Form1 : Form
    {

        Process[] processlist = Process.GetProcesses();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(Process.GetProcessesByName(textBox1.Text).Length >=1){
            //    foreach(Process p in Process.GetProcessesByName(textBox1.Text)){
            //        MessageBox.Show(p.ProcessName);
            //        p.CloseMainWindow();
            //    }
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Process theprocess in processlist){
                //MessageBox.Show(theprocess.ProcessName + " " + treeView1.Nodes.IndexOfKey(theprocess.ProcessName));
      
                if (treeView1.Nodes.IndexOfKey(theprocess.ProcessName) > -1)
                {
                    //MessageBox.Show("Duplicate");
                    treeView1.Nodes[treeView1.Nodes.IndexOfKey(theprocess.ProcessName)].Nodes.Add("" + theprocess.Id, "" + theprocess.Id);
                    //treeView1.Nodes.Add(node);
                }
                else
                {
                    treeView1.Nodes.Add(theprocess.ProcessName, theprocess.ProcessName);
                    treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add("" + theprocess.Id, "" + theprocess.Id);   
                }
                
            }
            MessageBox.Show("" + treeView1.Nodes.Count);
        }
        
    }
}
