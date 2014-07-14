using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKControlGrid
{
    public partial class Form1 : Form
    {

        #region Global Variables
        static readonly int dpi = 96;
        static readonly Vector2 bottomLeft = new Vector2(50, 50);
        static readonly Vector2 upperRight = new Vector2(1650, 1050);
        static readonly Vector2 viewSize = new Vector2(1700, 1100);
        private const float thickLine = 2f;
        private const float thinLine = 1f;
        #endregion

        #region Initialization
        public Form1()
        {
            InitializeComponent();
            InitializeMyGLControl();
            InitializeMyScrollBar();
            InitializeMouseEvents();
            InitializeKeyboardControls();
            InitializeContextMenu();
        }
        bool loaded = false;
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.White);
            setupViewPort();
            loaded = true;
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            setupViewPort();
            glControl1.Invalidate();
        }
        private void InitializeMyGLControl()
        {
            glControl1.Size = new Size((int)viewSize.X, (int)viewSize.Y);
        }
        private void setupViewPort()
        {
            int w = (int)viewSize.X;
            int h = (int)viewSize.Y;
            //int w = glControl1.Width;
            //int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            
            //GL.Ortho(-w / 2, w / 2, -h / 2, h / 2, -1, 1);
            //GL.Viewport(-w / 2, -h / 2, w, h);
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h);
        }
        #endregion

        #region Draw
        float zoom = 1f;
        float dzoom = .025f;
        float transx = 0;
        float transy = 0;
        //float z = 0;
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            //check if loaded
            if (!loaded)
                return;
            
            //clear buffer
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //initialize
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            //background
            //GL.ClearColor(Color.Black);

            //depth
            GL.Enable(EnableCap.DepthTest);

            //zoom
            //label1.Text = "Zoom: " + zoom.ToString();
            label1.Text = "Test Angle: " + testangle.ToString();
            //if (zoom <= 0)
            //    zoom = dzoom;
            GL.Scale(zoom, zoom, 1);
            

            //pan
            label2.Text = "transx: " + transx + ", transy: " + transy;
            GL.Translate(-transx, transy, 0);
            
            //set viewport again
            //GL.Ortho(bottomLeft.X, upperRight.X, bottomLeft.Y, upperRight.Y, -1, 1);
            //GL.Viewport(0, 0, 100, 100);

            //draw
            int spacing = 100;
            if (((ToolStripMenuItem)glControl1.ContextMenuStrip.Items[0]).Checked)
                drawViewPort();
            if (((ToolStripMenuItem)glControl1.ContextMenuStrip.Items[1]).Checked)
                drawAxes();
            if (((ToolStripMenuItem)glControl1.ContextMenuStrip.Items[2]).Checked)
                drawPageOutline();
            if (((ToolStripMenuItem)glControl1.ContextMenuStrip.Items[3]).Checked)
            {
                Vector2 vec1 = new Vector2();
                Vector2 vec2 = new Vector2();
                if (plotToggleBtn.Text == "Grid 1")
                {
                    vec1 = bottomLeft;
                    vec2 = upperRight;
                }
                else if(plotToggleBtn.Text == "Grid 2")
                {
                    vec1 = new Vector2(250, 250);
                    vec2 = new Vector2(1650, 1050);//same as upperRight
                }
                else if(plotToggleBtn.Text == "Grid 3")
                {
                    vec1 = new Vector2(250, 550);
                    vec2 = new Vector2(1650, 1050);//same as upperRight
                }
                drawGrid(vec1, vec2, spacing);
            }
            glControl1.SwapBuffers();
        }

        private void drawAxes()
        {
            GL.Color3(Color.Blue);
            Draw.setLineWidth(thickLine);
            //x-axis
            Draw.Line(0, viewSize.Y / 2, viewSize.X, viewSize.Y / 2);

            //y-axis
            Draw.Line(viewSize.X / 2, 0, viewSize.X / 2, viewSize.Y);

            //z-axis (cannot see in orthographic projection)
            Draw.Line3D(new Vector3(viewSize.X / 2, viewSize.Y / 2, -50),
                        new Vector3(viewSize.X / 2, viewSize.Y / 2, 50));

            ////test functions
            ////Draw.FilledCircle(100, viewSize.X / 2, viewSize.Y / 2);
            //GL.PushMatrix();
            ////GL.Translate(new Vector3(viewSize.X / 2, viewSize.Y / 2, 0));
            //Draw.Rotate(testangle, new Vector3(0, 0, 1));
            //Draw.FilledRectangle2(new Vector2(viewSize.X / 2, viewSize.Y / 2),
            //    new Vector2(viewSize.X / 2 + 100, viewSize.Y / 2 + 100));
            //GL.Translate(new Vector3(viewSize.X / 2, viewSize.Y / 2, 0));
            //GL.PopMatrix();
            ////Draw.FillWedge(500, viewSize.X / 2, viewSize.Y / 2, 90, 360);
            ////Draw.Arc(100, viewSize.X / 2, viewSize.Y / 2, 90, 270);
            
        }
        int testangle = 0;
        private void drawViewPort()
        {
            Draw.setColor(Color.Black);
            Draw.setLineWidth(thickLine);
            Draw.Rectangle(new Vector2(0, 0), viewSize);
        }
        private void drawPageOutline()
        {
            Draw.setColor(Color.Black);
            Draw.setLineWidth(thickLine);
            Draw.Rectangle(bottomLeft, upperRight);
        }
        private void drawGrid(Vector2 v1, Vector2 v2, int spacing)
        {
            Draw.setColor(Color.Black);
            //plot horizontal lines
            int nHLines = (int)(v2.Y - v1.Y) / spacing;
            for (int i = 0; i < nHLines; i++)
            {
                for (int j = 0; j <= 10; j++)//for sub-lines
                {
                    float y = (spacing * i) + (spacing / 10 * j) + v1.Y;
                    if (j == 0 || j == 10)
                        Draw.setLineWidth(thickLine);
                    else
                        Draw.setLineWidth(thinLine);
                    Draw.Line(v1.X, y, v2.X, y);
                }
            }

            //plot vertical lines
            int nVLines = (int)(v2.X - v1.X) / spacing;
            for (int i = 0; i < nVLines; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    float x = (spacing * i) + (spacing / 10 * j) + v1.X;
                    if (j == 0 || j == 10)
                        Draw.setLineWidth(thickLine);
                    else
                        Draw.setLineWidth(thinLine);
                    Draw.Line(x, v1.Y, x, v2.Y);
                }
            }
        }
        #endregion

        #region Scrollbars
        HScrollBar hScrollBar1 = new HScrollBar();
        VScrollBar vScrollBar1 = new VScrollBar();

        private void InitializeMyScrollBar()
        {
            // Dock the scroll bar to the bottom of the form.
            hScrollBar1.Dock = DockStyle.Bottom;
            // Add the scroll bar to the form.
            Controls.Add(hScrollBar1);
            // Handle the scroll event
            hScrollBar1.Scroll += hScrollBar1_Scroll;


            // Dock the scroll bar to the bottom of the form.
            vScrollBar1.Dock = DockStyle.Right;
            // Add the scroll bar to the form.
            Controls.Add(vScrollBar1);
            // Handle the scroll event
            vScrollBar1.Scroll += vScrollBar1_Scroll;

            //set values for both scrollbars
            SetScrollBarValues();
        }
        public void SetScrollBarValues()
        {
            //Set the following scrollbar properties: 

            //Minimum: Set to 0 

            //SmallChange and LargeChange: Per UI guidelines, these must be set 
            //    relative to the size of the view that the user sees, not to 
            //    the total size including the unseen part.  In this example, 
            //    these must be set relative to the picture box, not to the image. 

            //Maximum: Calculate in steps: 
            //Step 1: The maximum to scroll is the size of the unseen part. 
            //Step 2: Add the size of visible scrollbars if necessary. 
            //Step 3: Add an adjustment factor of ScrollBar.LargeChange. 


            //Configure the horizontal scrollbar 
            //---------------------------------------------
            if (this.hScrollBar1.Visible)
            {
                this.hScrollBar1.Minimum = 0;
                this.hScrollBar1.SmallChange = this.glControl1.Width / 20;
                this.hScrollBar1.LargeChange = this.glControl1.Width / 10;

                this.hScrollBar1.Maximum = glControl1.Width;  //step 1 

                if (this.vScrollBar1.Visible) //step 2
                {
                    this.hScrollBar1.Maximum += this.vScrollBar1.Width;
                }

                this.hScrollBar1.Maximum += this.hScrollBar1.LargeChange; //step 3
            }

            //Configure the vertical scrollbar 
            //--------------------------------------------- 
            if (this.vScrollBar1.Visible)
            {
                this.vScrollBar1.Minimum = 0;
                this.vScrollBar1.SmallChange = this.glControl1.Height / 20;
                this.vScrollBar1.LargeChange = this.glControl1.Height / 10;

                this.vScrollBar1.Maximum = this.glControl1.Height; //step 1 

                if (this.hScrollBar1.Visible) //step 2
                {
                    this.vScrollBar1.Maximum += this.hScrollBar1.Height;
                }

                this.vScrollBar1.Maximum += this.vScrollBar1.LargeChange; //step 3
            }
        }

        void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            float hscrollScale = glControl1.Width / 90;
            //float hscrollScale = (upperRight.X - bottomLeft.X) / 90;
            transx += (e.NewValue - e.OldValue) * hscrollScale;

            //label1.Text = transx.ToString();
            glControl1.Invalidate();
        }
        void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            float vscrollscale = glControl1.Height / 90;
            //float vscrollscale = (upperRight.Y - bottomLeft.Y) / 90;
            transy += (e.NewValue - e.OldValue) * vscrollscale;
            
            //label2.Text = transy.ToString();
            glControl1.Invalidate();
        }

        //brings the scrollbars to front
        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            hScrollBar1.BringToFront();
            vScrollBar1.BringToFront();
        }
        #endregion

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            //GL.Frustum(0, viewSize.X, 0, viewSize.Y, -1, 0);
            zoom += 2 * dzoom;
            glControl1.Invalidate();
            glControl1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            zoom -= 2 * dzoom;
            if (zoom < dzoom)
                zoom = dzoom;
            glControl1.Invalidate();
            glControl1.Focus();
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            resetToDefaultScale();
        }
        private void resetToDefaultScale()
        {
            zoom = 1;
            transx = 0;
            transy = 0;
            hScrollBar1.Value = 0;
            vScrollBar1.Value = 0;
            glControl1.Invalidate();
            glControl1.Focus();
        }
        private void plotToggle_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Grid 1")
                ((Button)sender).Text = "Grid 2";
            else if (((Button)sender).Text == "Grid 2")
                ((Button)sender).Text = "Grid 3";
            else if (((Button)sender).Text == "Grid 3")
                ((Button)sender).Text = "Grid 1";
            glControl1.Invalidate();
            glControl1.Focus();
        }
        #endregion

        #region Mouse
        Point mousePos = new Point();
        private void InitializeMouseEvents()
        {
            glControl1.MouseWheel += glControl1_MouseWheel;
            glControl1.MouseMove += glControl1_MouseMove;
            glControl1.MouseDown += glControl1_MouseDown;
            glControl1.MouseUp += glControl1_MouseUp;
        }

        void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            //reset cursor back to default
            this.Cursor = Cursors.Default;
            glControl1.Invalidate();
        }

        void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                mousePos = e.Location;
            }

        }

        void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                this.Cursor = Cursors.Hand;
                transx -= (e.X - mousePos.X) * 2f;//set as a factor of 2 to move faster
                transy -= (e.Y - mousePos.Y) * 2f;//set as a factor of 2 to move faster

                mousePos = e.Location;
                glControl1.Invalidate();
            }
            label3.Text = e.Location.ToString();
        }

        void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            const int WHEEL_DELTA = 120;//windows default 120 units per line scroll
            zoom += e.Delta / WHEEL_DELTA * dzoom;
            if (zoom < dzoom)
                zoom = dzoom;
            glControl1.Invalidate();
        }

        #endregion

        #region Keyboard
        private void InitializeKeyboardControls()
        {
            glControl1.KeyPress += glControl1_KeyPress;
        }

        void glControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 'u')
                testangle += 5;
            else if (e.KeyChar == 'i')
                testangle -= 5;
            glControl1.Invalidate();
        }
        #endregion

        #region ContextMenu
        private void InitializeContextMenu()
        {
            ContextMenuStrip c = new ContextMenuStrip();
            c.Items.Add("Viewport");
            c.Items.Add("Axes");
            c.Items.Add("Page Outline");
            c.Items.Add("Grid");
            foreach (ToolStripMenuItem item in c.Items)
            {
                item.Checked = true;//enable all controls by default
                item.Click += contextMenuItem_Click;
            }
            glControl1.ContextMenuStrip = c;
        }
        void contextMenuItem_Click(object sender, EventArgs e)
        {
            //toggle check state
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            glControl1.Invalidate();
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            //reset the picture to scale to it will save correctly (currently not working)
            //resetToDefaultScale();
            
            //prompt user that scale is not unit scale and return
            if (zoom != 1)
            {
                MessageBox.Show("Please reset the scale and print again.");
                return;
            }
            //Print the image
            PrintImage();
        }
        Image glControlBits;
        private void PrintImage()
        {
            //print the document
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += pd_PrintPage;
            pd.DefaultPageSettings.PaperSize = new PaperSize("PDI", 1100, 1700);
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Landscape = true;
            //pd.DefaultPageSettings.PrinterResolution
            PrintDialog pdialog = new PrintDialog();
            pdialog.Document = pd;
            if (pdialog.ShowDialog() == DialogResult.OK)
            {
                //set the print image to be the bitmap of the glcontrol
                glControlBits = GrabScreenshot();
                //save the bitmap, for debugging purposes
                glControlBits.Save(@"C:\Users\Shane\Desktop\testbitmap.bmp");
                pd.Print();
            }
            else return;
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //double cmToUnits = 100 / 2.54;
            //e.Graphics.DrawImage(glControlBits, 0, 0, (float)(17 * cmToUnits), (float)(11 * cmToUnits));
            e.Graphics.DrawImage(glControlBits, 0, 0, 1700, 1100);
        }

        public Bitmap GrabScreenshot()
        {
            //get the bitmap
            Rectangle imageArea = new Rectangle(0, 0, (int)viewSize.X, (int)viewSize.Y);
            Bitmap bmp = new Bitmap(imageArea.Width, imageArea.Height);
            System.Drawing.Imaging.BitmapData data =
                bmp.LockBits(imageArea, System.Drawing.Imaging.ImageLockMode.WriteOnly,
                             System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.ReadPixels(0, 0, imageArea.Width, imageArea.Height, PixelFormat.Bgr, PixelType.UnsignedByte,
                          data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            //return the image
            return bmp;
        }

    }
}
