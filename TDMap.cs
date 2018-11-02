using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class TDMap
    {
        public static int GridSize = 30;

        public int Level;
        public List<TDPath> Paths = new List<TDPath>();

        private Color _BackColor = Color.LightGray;
        public Color BackColor
        {
            get { return _BackColor; }
            set
            {
                _BackColor = value;
                // update the filling of the action screen?
                BackgroundBrush = new SolidBrush(value);
            }
        }
        private Color _PathColor = Color.Gray;
        public Color PathColor
        {
            get
            {
                return _PathColor;
            }
            set
            {
                _PathColor = value;
                pathPen.Color = value;
            }
        }
        private Color _BaseColor = Color.Green;
        public Color BaseColor
        {
            get { return _BaseColor; }
            set
            {
                _BaseColor = value;
                // update any pens or other features?
                BaseBrush = new SolidBrush(value);
            }
        }

        private Image _PathImage;
        private Image _BackImage;
        private Image _BaseImage;

        public Image PathImage
        {
            get { return _PathImage; }
            set
            {
                _PathImage = value;
                if (value != null)
                {
                    pathPen.Brush = new TextureBrush(PathImage);
                }
            }
        }
        public Image BackImage
        {
            get { return _BackImage; }
            set
            {
                _BackImage = value;
                if (value != null)
                {
                    BackgroundBrush = new TextureBrush(value);
                }
            }
        }
        public Image BaseImage
        {
            get { return _BaseImage; }
            set
            {
                _BaseImage = value;
                if (value != null)
                {
                    BaseBrush = new TextureBrush(value);
                }
            }
        }

        Pen pathPen = new Pen(Color.Gray, GridSize);
        private Brush BackgroundBrush = new SolidBrush(Color.LightGray);
        private Brush BaseBrush = new SolidBrush(Color.Green);

        Graphics backGraphics;
        Image backGraphicsImage;
        
        public TDMap(int Level, List<TDPath> Paths)
        {
            this.Level = Level;
            this.Paths = Paths;
        }
        public TDMap(TDMap sourceTemplate)
        {
            if (sourceTemplate != null)
            {
                this.BackColor = sourceTemplate.BackColor;
                this.BackImage = sourceTemplate.BackImage;

                this.BaseColor = sourceTemplate.BaseColor;
                this.BaseImage = sourceTemplate.BaseImage;
                
                this.Level = sourceTemplate.Level;
                
                this.PathColor = sourceTemplate.PathColor;
                this.PathImage = sourceTemplate.PathImage;
                
                this.Paths = sourceTemplate.Paths;
            }
        }

        public void Draw(Graphics g)
        {
            if (backGraphicsImage == null)
            {
                backGraphicsImage = new Bitmap(TDForm.ThisForm.panelAction.Size.Width,
                                                TDForm.ThisForm.panelAction.Size.Height);

                backGraphics = Graphics.FromImage(backGraphicsImage);
                backGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

                // draw the background as an image if we have one
                backGraphics.FillRectangle(BackgroundBrush, 0, 0, TDForm.ThisForm.panelAction.Size.Width, TDForm.ThisForm.panelAction.Size.Height);

                DrawPaths(backGraphics);
            }

            g.DrawImage(backGraphicsImage, 0, 0, backGraphicsImage.Width, backGraphicsImage.Height);
        }

        private void DrawPaths(Graphics g)
        {
            foreach (TDPath p in Paths)
            {
                TDPathPoint lastPoint = null;
                foreach (TDPathPoint pp in p.PathPoints)
                {
                    if (lastPoint == null)
                    {
                        // don't draw the first point
                        lastPoint = pp;
                        continue;
                    }

                    try
                    {
                        // draw a line from this point back to our last point.
                        g.DrawLine(pathPen, (int)lastPoint.Location.X, (int)lastPoint.Location.Y, (int)pp.Location.X, (int)pp.Location.Y);

                        // draw the last point differently (the base).
                        if (pp == p.PathPoints[p.PathPoints.Count - 1])
                        {
                            // draw the base
                            if (BaseImage != null)
                            {
                                g.DrawImage(BaseImage, (int)(pp.Location.X - (BaseImage.Width / 2) + 1), (int)(pp.Location.Y - (BaseImage.Width / 2) + 1), BaseImage.Width, BaseImage.Width);
                            }
                            else
                            {
                                g.FillRectangle(BaseBrush, (int)(pp.Location.X - (pathPen.Width / 2) + 1), (int)(pp.Location.Y - (pathPen.Width / 2) + 1), pathPen.Width, pathPen.Width);
                            }
                        }
                        else
                        {
                            // draw this point, specifically (catches the corners of the path)
                            g.FillEllipse(pathPen.Brush, (int)(pp.Location.X - (pathPen.Width / 2)), (int)(pp.Location.Y - (pathPen.Width / 2)), pathPen.Width, pathPen.Width);
                        }
                    }
                    catch { } // just skip drawing during this frame (no need to get picky)

                    // reset who is the last point
                    lastPoint = pp;
                }
            }
        }

        public bool isTowerOnPath(TDTower t)
        {
            // first check if intersting any corner
            TDPathPoint lastPoint = null;
            foreach (TDPath p in this.Paths)
            {
                foreach (TDPathPoint pp in p.PathPoints)
                {
                    if (TDMath.Intersects(t.Location, t.Size, pp.Location, GridSize))
                    {
                        return true;
                    }
                    else
                    {
                        // check intersecting any line
                        if (lastPoint != null)
                        {
                            if (TDMath.Intersects(t, pp, lastPoint))
                            {
                                return true;
                            }
                        }

                        lastPoint = pp;
                    }
                }
            }

            return false;
        }

        internal void LoadMapData(TDMapTabData tab)
        {
            // colors, etc.
            DataRow row = tab.Table.Rows[0];

            BackColor = ParseColor(row, TDMapTabData.ColumnNames.BackColor);
            PathColor = ParseColor(row, TDMapTabData.ColumnNames.PathColor);
            BaseColor = ParseColor(row, TDMapTabData.ColumnNames.BaseColor);

            BackImage = ParseImage(row, TDMapTabData.ColumnNames.BackImage);
            PathImage = ParseImage(row, TDMapTabData.ColumnNames.PathImage);
            BaseImage = ParseImage(row, TDMapTabData.ColumnNames.BaseImage);
        }

        private Image ParseImage(DataRow row, string col)
        {
            Image i = null;
            string s = row[col].ToString();
            if (!String.IsNullOrEmpty(s))
            {
                if (!s.StartsWith("Images"))
                {
                    s = "Images" + Path.DirectorySeparatorChar + s;
                }

                s = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + s;

                try
                {
                    i = Image.FromFile(s);
                }
                catch { }
            }
            return i;
        }

        private Color ParseColor(DataRow row, string col)
        {
            string s = row[col].ToString();

            Color c = Color.Gray;
            try
            {
                c = Color.FromName(s);
            }
            catch { }
            return c;
        }

        internal void ResetBackGraphics()
        {
            backGraphicsImage = null;
        }
    }
}
