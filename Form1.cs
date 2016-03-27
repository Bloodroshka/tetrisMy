﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List <Point> allpoints = new List<Point>();
        FIGURE figure = randomizer();
        private static FIGURE randomizer()
        {
            Random r = new Random();
            FIGURE res = new SQUARE();
            switch (r.Next(0, 7))
            {
                case 0:
                    res = new SQUARE();
                    break;
                case 1:
                    res = new STUUUUL_R();
                    break;
                case 2:
                    res = new STUUUUL_L();
                    break;
                case 3:
                    res = new LINE();
                    break;
                case 4:
                    res = new TTTTTT();
                    break;
                case 5:
                    break;
                case 6:
                    res = new G_R();
                    break;
            }
            return res;
        }
        int score = 0;
        bool [,] tetr = new bool[20, 40];
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameover())
            {
                if (canfall())
                {
                    figure.stepfigure();

                }
                else
                {
                    
                    foreach (Point p in figure.FillPoint)
                    {
                        
                        allpoints.Add(p);
                    }
                    foreach (Point p1t in figure.FillPoint)
                    {
                        tetr[p1t.X / figure.razm, p1t.Y / figure.razm] = true;
                    }
                    checkline();
                    figure = randomizer();
                }
                pictureBox1.Invalidate();
            }
            else
            {
                timer1.Stop();
                this.Text = "GAME OVER";
                MessageBox.Show("Вы не справились с возложенной на вас задачей. Остаётся лишь смириться с этим. Игра окончена. Прощайте.");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            figure.drawfigure(e.Graphics);
            paintallpoints(e.Graphics);
        }
        private void paintallpoints(Graphics holst)
        {
            Pen pn = new Pen(Color.Crimson, 2);
            SolidBrush br = new SolidBrush(figure.cl);
            foreach (Point p in allpoints)
            {
                holst.FillRectangle(br, p.X, p.Y, figure.razm, figure.razm);
                holst.DrawRectangle(pn, p.X, p.Y, figure.razm, figure.razm);
            }
            for (int i = 0; i < tetr.GetLength(0); i++)
            {
                for (int j = 0; j < tetr.GetLength(1); j++)
                {
                    if (tetr[i, j])
                    {
                        SolidBrush Brush = new SolidBrush(Color.HotPink);
                        holst.FillEllipse(Brush, new Rectangle(new Point(i * 15, j * 15), new Size(5, 5)));
                    }
                }
            }
        }
        private bool canfall()
        {
            bool a = true;
            if (figure.snt.Y + figure.razm < pictureBox1.Height)
            {
                foreach (Point p in figure.FillPoint)
                {
                    foreach (Point j in allpoints)
                    {
                        if (p.Y + figure.razm == j.Y && p.X == j.X)
                        {
                            a = false;
                        }
                        else a = a && true;
                    }
                }
            }
            else a = false;
            return a;
        }
        private bool gameover()
        {
            bool a = false;
            foreach(Point p in figure.FillPoint)
                foreach (Point j in allpoints)
                {
                    if ((p.Y == 0) && (j.Y == 0) && (p.X == j.X))
                    {
                        a = true;
                    }
                }
            return a;
        }
        public bool Canrotate()
        {
            int figurot = figure.state;
            figure.rotate();
            foreach (Point pp in figure.FillPoint)
                if (pp.X >= 0 && pp.Y < pictureBox1.Height && pp.X <= pictureBox1.Width)
                    foreach (Point po in allpoints)
                    {
                        if (po.Equals(pp))
                        {
                            figure.state = figurot;
                            return false;
                        }
                    }
                else
                {
                    figure.state = figurot;
                    return false;
                }
            figure.state = figurot;
            return true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (canleft())
                    {
                        figure.place = new Point(figure.place.X - figure.razm, figure.place.Y);
                        pictureBox1.Invalidate();
                    }
                    break;
                case Keys.D:
                    if (canright())
                    {
                        figure.place = new Point(figure.place.X + figure.razm, figure.place.Y);
                        pictureBox1.Invalidate();
                    }
                    break;
                case Keys.S:
                    while (canfall())
                    {
                        figure.stepfigure();
                    }
                    break;
                case Keys.Space:
                    if (Canrotate())
                    {
                        figure.rotate();
                    }
                    break;
            }
        }
        private bool canright()
        {
            bool a = true;
            if (figure.srt.X + 2*figure.razm <= pictureBox1.Width)
            {
                foreach (Point p in figure.FillPoint)
                {
                    foreach (Point j in allpoints)
                    {
                        if (p.X + figure.razm == j.X && p.Y == j.Y)
                        {
                            a = false;
                        }
                        else a = a && true;
                    }
                }
            }
            else a = false;
            return a;
        }
        private bool canleft()
        {
            bool a = true;
            if (figure.slt.X - figure.razm >= 0)
            {
                foreach (Point p in figure.FillPoint)
                {
                    foreach (Point j in allpoints)
                    {
                        if (p.X - figure.razm == j.X && p.Y == j.Y)
                        {
                            a = false;
                        }
                        else a = a && true;
                    }
                }
            }
            else a = false;
            return a;
        }
        private void checkline()
        {
            int lineseaten = 0;
            
        
            for (int i = 0; i < tetr.GetLength(1); i++)
            {
                bool isdel = true;
                for (int j = 0; j < tetr.GetLength(0); j++)
                {
                    if (!tetr[j, i])
                    {
                        isdel = false;
                        break;
                    }

                }
                if (isdel)
                {
                    lineseaten++;
                    for (int j = 0; j < tetr.GetLength(0); j++)
                    {
                        tetr[j, i]  = false;
                            for (int k = i; k > 0; k--)
                            {
                                tetr[j, k] = tetr[j, k - 1];

                            }
                    }
                    allpoints.Clear();
                    for (int i1 = 0; i1 < tetr.GetLength(0); i1++)
                    {
                        for (int j= 0; j < tetr.GetLength(1); j++)
                        {
                            if (tetr[i1, j])
                            {
                                Point pt = new Point(i1 * 15, j * 15);
                                allpoints.Add(pt);
                            }
                        }
                    }
                }
            }
        score += lineseaten * 100;
        label1.Text = Convert.ToString(score);
        label2.Text = Convert.ToString(lineseaten);
        }
    }
}
