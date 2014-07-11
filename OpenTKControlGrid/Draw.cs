using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKControlGrid
{
    class Draw
    {
        /// <summary>
        /// Holds the 
        /// </summary>
        public Draw() { }

        #region Line
        //3D
        /// <summary>
        /// most generic form of drawline in 3D
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="lineThickness"></param>
        public void Line3D(Vector3 p1, Vector3 p2)
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(p1);
            GL.Vertex3(p2);
            GL.End();
        }
        [Obsolete("Draw.Line(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), lineThickness)")]
        public void Line3D(float x1, float y1, float z1, float x2, float y2, float z2, float lineThickness = 1)
        {
            Vector3 v1 = new Vector3(x1, x2, z1);
            Vector3 v2 = new Vector3(x1, x2, z2);
            Line3D(v1, v2);
        }
        //2D
        /// <summary>
        /// Converts a 2D vector into 3D vector and draws the line
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="z"></param>
        /// <param name="lineThickness"></param>
        public void Line(Vector2 p1, Vector2 p2, float z = 0)
        {
            Vector3 v1 = new Vector3(p1.X, p1.Y, z);
            Vector3 v2 = new Vector3(p2.X, p2.Y, z);
            this.Line3D(v1, v2);
        }
        //2D assumes z = 0
        /// <summary>
        /// choose specific coordinates to draw the line
        /// assumes z = 0
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z"></param>
        /// <param name="lineThickness"></param>
        public void Line(float x1, float y1, float x2, float y2)
        {
            Vector3 v1 = new Vector3(x1, y1, 0);
            Vector3 v2 = new Vector3(x2, y2, 0);
            this.Line3D(v1, v2);
        }
        /// <summary>
        /// sets the linewidth until furthur updated
        /// </summary>
        /// <param name="width"></param>
        public void setLineWidth(float width)
        {
            GL.LineWidth(width);
        }

        #endregion

        #region Rectrangle
        /// <summary>
        /// Draws a rectangle in 3 dimensional space
        /// </summary>
        /// <param name="lowerLeft"></param>
        /// <param name="upperRight"></param>
        /// <param name="zplane"></param>
        public void Rectangle3D(Vector3 lowerLeft, Vector3 upperRight, float zplane = 0)
        {
            Vector3 upperleft = new Vector3(lowerLeft.X, upperRight.Y, zplane);
            Vector3 lowerRight = new Vector3(upperRight.X, lowerLeft.Y, zplane);
            this.Line3D(lowerLeft, upperleft);
            this.Line3D(upperleft, upperRight);
            this.Line3D(upperRight, lowerRight);
            this.Line3D(lowerRight, lowerLeft);
        }
        /// <summary>
        /// Draws a rectangle, assumes z = 0
        /// </summary>
        /// <param name="lowerLeft"></param>
        /// <param name="upperRight"></param>
        /// <param name="z"></param>
        /// <param name="lineThickness"></param>
        public void Rectangle(Vector2 lowerLeft, Vector2 upperRight, float lineThickness = 1)
        {
            Vector3 v1 = new Vector3(lowerLeft.X, lowerLeft.Y, 0);
            Vector3 v2 = new Vector3(upperRight.X, upperRight.Y, 0);
            this.Rectangle3D(v1, v2, 0);
        }
        public void FilledRectangle2(Vector2 lowerLeft, Vector2 upperRight)
        {
            Vector2 upperLeft = new Vector2(lowerLeft.X, upperRight.Y);
            Vector2 lowerRight = new Vector2(upperRight.X, lowerLeft.Y);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(lowerLeft);
            GL.Vertex2(upperLeft);
            GL.Vertex2(upperRight);
            GL.Vertex2(lowerRight);
            GL.End();
        }
        #endregion

        #region Circle
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="radius">radius of circle</param>
        /// <param name="x">x coordinate of the center</param>
        /// <param name="y">y coordinate of the center</param>
        public void Circle(float radius, float x, float y)
        {
            const float DEG2RAD = (float)Math.PI / 180f;
            GL.Begin(PrimitiveType.LineLoop);
            
            //circles has 360 segments
            for (int i = 0; i <= 360; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(x + Math.Cos(degInRad) * radius, y + Math.Sin(degInRad) * radius);
            }
            GL.End();
        }
        public void FilledCircle(float radius, float x, float y)
        {
            const float DEG2RAD = (float)Math.PI / 180f;
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Vertex2(x, y);
            for (int i = 0; i <= 360; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(x + Math.Cos(degInRad) * radius, y + Math.Sin(degInRad) * radius);
            }
            GL.End();
        }
        #endregion

        
        

    }
}
