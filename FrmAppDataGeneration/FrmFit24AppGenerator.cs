using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fit24Data;

namespace FrmAppDataGeneration
{
    public partial class FrmFit24AppGenerator : Form
    {
        public Content contentFile = new Content();

        public FrmFit24AppGenerator()
        {
            InitializeComponent();
            TreeNode tn = new TreeNode("Fit24");
            tn.ContextMenuStrip = cmsTree;
            tn.Tag = contentFile;
            tv.Nodes.Add(tn);
            tv.AfterLabelEdit += Tv_AfterLabelEdit;
        }

        private void Tv_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ((Content)(e.Node.Tag)).ContentTitel = e.Label;
        }

        private void addPageEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != tv.SelectedNode)
            {
                TreeNode tn = new TreeNode("Seite");
                tn.BackColor = Color.Green;
                tn.ContextMenuStrip = cmsTree;
                tn.Tag = new ContentNewPage();
                ((Content)tn.Tag).ContentTitel = tn.Text;
                ((Content)tv.SelectedNode.Tag).Items.Add(tn.Tag as Content);
                tv.SelectedNode.Nodes.Add(tn);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofd.ShowDialog())
            {
                contentFile = Content.Load(ofd.FileName);
                tv.Nodes.Clear();
                TreeNode tn = new TreeNode(contentFile.ContentTitel);
                tn.Tag = contentFile;
                tn.BackColor = Color.Green;
                tv.Nodes.Add(tn);
                AddChildNodes(tn, contentFile);
            }
        }

        private void AddChildNodes(TreeNode tn, Content content)
        {
            foreach (Content ct in content.Items)
            {
                TreeNode tn1 = new TreeNode(ct.ContentTitel);
                tn1.Tag = ct;
                if (ct.ContentType == ContentType.newPage)
                {
                    tn1.BackColor = Color.Green;
                }
                tn.Nodes.Add(tn1);
                foreach (Content ctChildes in ct.Items)
                {
                    AddChildNodes(tn1, ctChildes);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == sfd.ShowDialog())
            {
                Content.Save(sfd.FileName, (Content)tv.Nodes[0].Tag);
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (null != tv.SelectedNode)
            {
                string contentTitel = "";
                object contentObject = null;
                Content node = (Content)tv.SelectedNode.Tag; //get the current node
                node.Items.Clear(); //clear all parameters
                foreach (DataGridViewRow row in dgv.Rows) //run trough each row
                {
                    if ((null != row.Cells[0].Value) && (0 < row.Cells[0].Value.ToString().Trim().Length))
                    {
                        contentTitel = row.Cells[0].Value.ToString();
                    }
                    if (null != row.Cells[1].Value)
                    {
                        contentObject = row.Cells[1].Value;
                    }
                    if ((0 == contentTitel.Length) && (null == contentObject))
                    {
                        continue;
                    }
                    ContentString cs = new ContentString();
                    cs.ContentTitel = contentTitel;
                    cs.ContentObject = row.Cells[1].Value;
                    node.Items.Add(cs);
                }
            }
        }

        private void bereichHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != tv.SelectedNode)
            {
                TreeNode tn = new TreeNode("Bereich");
                tn.ContextMenuStrip = cmsTree;
                tn.Tag = new Content();
                ((Content)tn.Tag).ContentTitel = tn.Text;
                ((Content)tv.SelectedNode.Tag).Items.Add(tn.Tag as Content);
                tv.SelectedNode.Nodes.Add(tn);
            }
        }
    }
}
