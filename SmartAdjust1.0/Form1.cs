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

        Process[] processlist;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            loadAllProcesses();
        }

        private void loadAllProcesses()
        {
            treeView1.Nodes.Clear();

            processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                //MessageBox.Show(theprocess.ProcessName + " " + treeView1.Nodes.IndexOfKey(theprocess.ProcessName));

                if (treeView1.Nodes.IndexOfKey(theprocess.ProcessName) > -1)
                {
                    //MessageBox.Show("Duplicate");
                    treeView1.Nodes[treeView1.Nodes.IndexOfKey(theprocess.ProcessName)].Nodes.Add("" + theprocess.Id, "" + theprocess.Id + "    "+theprocess.MainWindowTitle);
                    //treeView1.Nodes.Add(node);
                }
                else
                {
                    treeView1.Nodes.Add(theprocess.ProcessName, theprocess.ProcessName);
                    treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add("" + theprocess.Id, "" + theprocess.Id + "    " + theprocess.MainWindowTitle);
                }

            }

            //treeView1.Sort();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Boolean found = false;
            for (int j=treeView1.Nodes.Count-1; j>-1; j--)
            {
                TreeNode n = treeView1.Nodes[j];
                for (int i=n.Nodes.Count-1;i>-1;i--)
                {
                    //MessageBox.Show(cn.Text);
                    if (n.Nodes[i].Checked)
                    {
                        //MessageBox.Show(cn.Text);
                        found=true;
                        try
                        {
                            Process p = Process.GetProcessById(Convert.ToInt32(n.Nodes[i].Text.Split(' ')[0]));
                            p.Kill();
                        }
                        catch(Exception exp)
                        {
                            MessageBox.Show(exp.Message,"Error");
                        }

                        n.Nodes.RemoveAt(i);
                        //cn = n.Nodes[0];
                    }
                }

                if (n.Nodes.Count==0)
                {
                    treeView1.Nodes.RemoveAt(j);
                }

            }

            if (!found)
            {
                MessageBox.Show("Please Select a process first.");
            }


            loadAllProcesses();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadAllProcesses();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            //MessageBox.Show(treeView1.Nodes.IndexOf(TreeNode(sender.text).Text);
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively. 
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
    }
}
