using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            map = new Bitmap(pictureBox.Width, pictureBox.Height);
            mapPrim = new Bitmap(map.Width, map.Height);
            ClearClick(button1, EventArgs.Empty);
            string directory = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
            directory = Directory.GetParent(directory).ToString();
            directory = Directory.GetParent(directory).ToString();
            //mapPict = new Bitmap(directory + @"\Images\night.png");
        }

        byte state;
        bool isMouseDown = false;
        int oldX;
        int oldY;

        Bitmap map;
        Bitmap mapPict;
        Bitmap mapPrim;
        List<Point> pointsPrim = new List<Point>();
        List<Point> pointsPrim2;

        Color color = Color.Black;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void ClearClick(object sender, EventArgs e)
        {
            Graphics graphics = Graphics.FromImage(map);
            graphics.Clear(Color.White);
            graphics = Graphics.FromImage(map);// mapPrim);
            graphics.Clear(Color.White);
            CancelClick(sender, e);
            pictureBox.Image = map;
        }

        void CancelClick(object sender, EventArgs e)
        {
            pointsPrim = new List<Point>();
            Graphics graphics = Graphics.FromImage(map);// mapPrim);
            graphics.Clear(Color.White);
            pictureBox.Image = map;
            if (state == 5 || state == 6)
                state = 1;
        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            Point new_p = new Point(e.X, e.Y);
            pointsPrim.Add(new_p);
            
            for(int x = e.X - 3; x < e.X + 3; x++)
            {
                for(int y = e.Y-3;  y < e.Y + 3; y++)
                {
                    map.SetPixel(x, y, color);
                }
            }
            pictureBox.Image = map;
        }
    }
}