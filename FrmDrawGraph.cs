using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HtmlAgilityPack;
using HtmlDocument = System.Windows.Forms.HtmlDocument;

namespace demotestq1
{

    public partial class FrmDrawGraph : Form
    {



        private string linkweb = "https://hoctructuyen.vimaru.edu.vn/";
        private List<Color> pieChartColors;
        private List<string> lst = new List<string>();
        //Graphics graphic;
        private List<string> lstb = new List<string>();
        Graphics graphic;
        bool drawing = true;
        private List<Label> lstlb = new List<Label>();
        private List<string> lstsavefile = new List<string>();
        private int maxdothi;

        TreeNode root;
        

        public FrmDrawGraph(List<string> lst)
        {
            InitializeComponent();
            //linkweb = qs;

            //txttest.Text = lst[2];
            //txttest.Text = qs;



            
            
            //textBox1.Text = lst.Count.ToString();
            //pnlgraph.AutoScroll = true;

        }

        public static int countSL(string s, char c)
        {
            int res = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                    res++;
            }

            return res;
        }
        public static int compe(string a,string b)
        {
            int count = 0;
            string[] arrstr = a.Split('/');
            string[] arrstr1 = b.Split('/');
            int index = 0;
            int check = 5;
            if (arrstr.Length > arrstr1.Length)
            {
               
                while (index < arrstr.Length)
                {
                    for (int j = 0; j < arrstr1.Length; j++)
                    {
                        if (arrstr[index] == arrstr1[j])
                        {
                            check = 1;
                        }
                    }
                    if (check == 1)
                    {
                        count++;
                        check = 5;
                    }
                    index++;
                }
            }
            else
            {
             
                while (index < arrstr1.Length)
                {
                    for (int j = 0; j < arrstr.Length; j++)
                    {
                        if (arrstr1[index] == arrstr[j])
                        {
                            check = 1;
                        }
                    }
                    if (check == 1)
                    {
                        count++;
                        check = 5;
                    }
                    index++;
                }
            }






            return count;
        }

        static int removetrung(int[] arr, int n)
        {

            if (n == 0 || n == 1)
                return n;

            // To store index of next
            // unique element
            int j = 0;

            // Doing same as done in Method 1
            // Just maintaining another updated
            // index i.e. j
            for (int i = 0; i < n - 1; i++)
                if (arr[i] != arr[i + 1])
                    arr[j++] = arr[i];

            arr[j++] = arr[n - 1];

            return j;
        }


        public static int mostFrequent(int[] arr, int n)
        {

            // Sort the array
            Array.Sort(arr);

            // find the max frequency using
            // linear traversal
            int max_count = 1, res = arr[0];
            int curr_count = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1])
                    curr_count++;
                else
                {
                    if (curr_count > max_count)
                    {
                        max_count = curr_count;
                        res = arr[i - 1];
                    }
                    curr_count = 1;
                }
            }

            // If last element is most frequent
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = arr[n - 1];
            }

            return res;
        }

        static int demsolanxuathien(int[] arr,
                            int n, int x)
        {
            int res = 0;

            for (int i = 0; i < n; i++)
                if (x == arr[i])
                    res++;

            return res;
        }


        private void drawPieChart()
        {




        }

        // noi 

        //for (int i = 0; i < lst.Count(); i++)
        //{

        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            /* Label mylab = new Label();
             mylab.Text = "GeeksforGeeks";
             mylab.Location = new Point(222, 90);
             mylab.AutoSize = true;
             mylab.Font = new Font("Calibri", 18);
             mylab.ForeColor = Color.Green;

             // Adding this control to the form
             pnlPieChart.Controls.Add(mylab);
            */
            draw();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        public static DataTable ConvertListToDataTable(List<string> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }


        private void FrmDrawGraph_Load(object sender, EventArgs e)
        {

            //findLineMax();

            //lstlabel[i].Location = new Point((20 + d * h) + 6, day + 6);

            //pnlPieChart.Controls.Add(lstlabel[i]);
        }

        private void draw()
        {
            // Create tron
            graphic = pnlPieChart.CreateGraphics();
            
        
                
        }
        // tree view

        //ghi file
        //   string fileLPath = @"D:\output.txt";




        //   System.IO.File.WriteAllLines(fileLPath, lstsavefile);


      



        private void pnlPieChart_MouseHover(object sender, EventArgs e)
        {
       

            // Adding this control to the form
            //panel1.Controls.Add(mylab);
        }



        //float angle = 0.0f;
        ////PointF org = new PointF(250, 250);
        //float rad = 250;
        // Pen pen = new Pen(Brushes.Azure, 3.0f);
        // RectangleF area = new RectangleF(30, 30, 500, 500);
        // RectangleF circle = new RectangleF(0, 0, 50, 50);

        //PointF loc = PointF.Empty;
        //PointF img = new PointF(20, 20);
        //fg.Clear(Color.Black);
        //fg.DrawEllipse(pen, area);


    }
}



