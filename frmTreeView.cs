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

namespace demotestq1
{
    public partial class frmTreeView : Form
    {
        private List<string> lsts2 = new List<string>();
        private double scale = 1;
        private Graphics graphic;
        private XmlDocument doc;
        private int treeLevel;
        private int[] nodeNumberAtLevels;
        private int[] drewNodeIndexAtLevels;
        private int dem = 0;
        private Random rd = new Random();
        public frmTreeView(List<string> lst)
        {
            for(int i=0;i<lst.Count;i++)
            {
                lsts2.Add(lst[i]);
            }    
            InitializeComponent();
            cbbTrees.SelectedIndex = 0;
          
            
        }

        private void cbbTrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\" + "myXmFile" + ".xml");
            treeLevel = estimateDepth(doc.DocumentElement, 0);
            nodeNumberAtLevels = new int[treeLevel];
            nodeNumberAtLevels[0] = 1;
            for (int i = 1; i < treeLevel; ++i)
                nodeNumberAtLevels[i] = 0;
            drewNodeIndexAtLevels = new int[treeLevel];
            countChildNodes(doc.DocumentElement, 0);

            pnlChart.Width = (int)Math.Round((treeLevel * (40 + 150) + 40) * scale, 0);
            pnlChart.Height = (int)Math.Round((nodeNumberAtLevels.Max() * (40 + 100) + 40) * scale, 0);
            pnlChart.Refresh();
        }

        private int estimateDepth(XmlNode node, int level)
        {
            if (node.ChildNodes.Count == 0)
                return level + 1;
            else
            {
                int maxDepth = level + 1;
                int depth = 0;
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    depth = estimateDepth(childNode, level + 1);
                    if (maxDepth < depth)
                        maxDepth = depth;
                }
                return maxDepth;
            }
        }

        private void countChildNodes(XmlNode node, int level)
        {
            if (node.ChildNodes.Count > 0)
            {
                nodeNumberAtLevels[level + 1] += node.ChildNodes.Count;
                foreach (XmlNode childNode in node.ChildNodes)
                    countChildNodes(childNode, level + 1);
            }
        }

        

        private void drawANode(XmlNode node, int level, float previousNodeX, float previousNodeY)
        {

            graphic.FillEllipse(new SolidBrush(Color.Orange), (int)Math.Round((6 + level * (40 + 150)) * scale, 0), (int)Math.Round((6 + drewNodeIndexAtLevels[level] * (40 + 80)) * scale, 0), (int)Math.Round((48) * scale, 0), (int)Math.Round((48) * scale, 0));
            graphic.FillEllipse(new SolidBrush(Color.Red), (int)Math.Round((10 + level * (40 + 150)) * scale, 0), (int)Math.Round((10 + drewNodeIndexAtLevels[level] * (40 + 80)) * scale, 0), (int)Math.Round((40) * scale, 0), (int)Math.Round((40) * scale, 0));
            graphic.DrawString(node.Attributes["name"].Value, this.Font, new SolidBrush(Color.Black), (int)Math.Round((6 + level * (40 + 150)) * scale, 0), (int)Math.Round((6 + drewNodeIndexAtLevels[level] * (40 + 80)) * scale, 0));
            dem = dem + 1;
            if (level > 0)
            {
                graphic.DrawLine(new Pen(new SolidBrush(Color.DarkOrange)), (int)Math.Round((10 + level * (40 + 150) + 20) * scale, 0), (int)Math.Round((10 + drewNodeIndexAtLevels[level] * (40 + 80) + 20) * scale, 0), previousNodeX, previousNodeY);
                graphic.DrawString(rd.Next(0, 2).ToString(), this.Font, new SolidBrush(Color.Black), (int)(previousNodeX + (int)Math.Round((10 + level * (40 + 150) + 20) * scale, 0)) / 2, (previousNodeY + (int)Math.Round((10 + drewNodeIndexAtLevels[level] * (40 + 80) + 20) * scale, 0)) / 2);
            }
            foreach (XmlNode childNode in node.ChildNodes)
                drawANode(childNode, level + 1, (int)Math.Round((10 + level * (40 + 150) + 20) * scale, 0), (int)Math.Round((10 + drewNodeIndexAtLevels[level] * (40 + 80) + 20) * scale, 0));
            drewNodeIndexAtLevels[level] += 1;
        }

        private void trbZoom_ValueChanged(object sender, EventArgs e)
        {
            scale = trbZoom.Value / 100.0;
            pnlChart.Width = (int)Math.Round((treeLevel * (40 + 150) + 40) * scale, 0);
            pnlChart.Height = (int)Math.Round((nodeNumberAtLevels.Max() * (40 + 100) + 40) * scale, 0);
            pnlChart.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\" + "myXmFile" + ".xml");
            treeLevel = estimateDepth(doc.DocumentElement, 0);
            nodeNumberAtLevels = new int[treeLevel];
            nodeNumberAtLevels[0] = 1;
            for (int i = 1; i < treeLevel; ++i)
                nodeNumberAtLevels[i] = 0;
            drewNodeIndexAtLevels = new int[treeLevel];
            countChildNodes(doc.DocumentElement, 0);

            pnlChart.Width = (int)Math.Round((treeLevel * (40 + 150) + 40) * scale, 0);
            pnlChart.Height = (int)Math.Round((nodeNumberAtLevels.Max() * (40 + 100) + 40) * scale, 0);
            pnlChart.Refresh();
        }

        private void pnlChart_Paint_1(object sender, PaintEventArgs e)
        {
            //pnlChart.Refresh();
            graphic = pnlChart.CreateGraphics();
            drewNodeIndexAtLevels = new int[treeLevel];
            drawANode(doc.DocumentElement, 0, 0, 0);

            //textBox1.Text = doc.DocumentElement.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtnumber.Text != "")
            {
                txturl.Text = lsts2[int.Parse(txtnumber.Text)];
            }
        }
    }
}
