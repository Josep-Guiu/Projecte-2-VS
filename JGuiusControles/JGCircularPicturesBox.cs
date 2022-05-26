using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Proyecto2.JGuiusControles
{
    class JGCircularPicturesBox : PictureBox
    {
        private int medidaBorde = 2;
        private Color colorBorde1 = Color.RoyalBlue;
        private Color colorBorde2 = Color.HotPink;
        private DashStyle estiloLiniaBorde = DashStyle.Solid;
        private DashCap estiloTapaBorde = DashCap.Flat;
        private float anguloDegradado = 50f;

        public JGCircularPicturesBox() {
            this.Size = new Size(100, 100);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int MedidaBorde  {
            get {
                return medidaBorde;
            }
            set {
                medidaBorde = value;
                this.Invalidate();
            }
        }
        public Color ColorBorde1 {
            get
            {
                return colorBorde1;
            }
            set
            {
                colorBorde1 = value;
                this.Invalidate();
            }
        }
        public Color ColorBorde2 {
            get
            {
                return colorBorde2;
            }
            set
            {
                colorBorde2 = value;
                this.Invalidate();
            }
        }
        public DashStyle EstiloLiniaBorde {
            get
            {
                return estiloLiniaBorde;
            }
            set
            {
                estiloLiniaBorde = value;
                this.Invalidate();
            }
        }
        public DashCap EstiloTapaBorde {
            get
            {
                return estiloTapaBorde;
            }
            set
            {
                estiloTapaBorde = value;
                this.Invalidate();
            }
        }
        public float AnguloDegradado {
            get
            {
                return anguloDegradado;
            }
            set
            {
                anguloDegradado = value;
                this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var graph = pe.Graphics;
            var rectContourSmooth = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectBorder = Rectangle.Inflate(rectContourSmooth, -medidaBorde, -medidaBorde);
            var smoothSize = medidaBorde > 0 ? medidaBorde * 3 : 1;
            using (var borderGColor = new LinearGradientBrush(rectBorder, colorBorde1, colorBorde2, anguloDegradado))
            using (var pathRegion = new GraphicsPath())
            using (var penSmooth = new Pen(this.Parent.BackColor, smoothSize))
            using (var penBorder = new Pen(colorBorde1, medidaBorde))
            {
                penBorder.DashStyle = estiloLiniaBorde;
                penBorder.DashCap = estiloTapaBorde;
                pathRegion.AddEllipse(rectContourSmooth);
                this.Region = new Region(pathRegion);
                graph.SmoothingMode = SmoothingMode.AntiAlias;

                graph.DrawEllipse(penSmooth, rectContourSmooth);
                if (medidaBorde > 0)
                {
                    graph.DrawEllipse(penBorder, rectBorder);
                }
            }
        }
    }
}
