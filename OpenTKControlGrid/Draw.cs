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
        public void Line(Vector3 p1, Vector3 p2, float lineThickness = 1)
        {
            GL.LineWidth(lineThickness);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(p1);
            GL.Vertex3(p2);
            GL.End();
        }
        [Obsolete("Draw.Line(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), lineThickness)")]
        public void Line(float x1, float y1, float z1, float x2, float y2, float z2, float lineThickness = 1)
        {
            Vector3 v1 = new Vector3(x1, x2, z1);
            Vector3 v2 = new Vector3(x1, x2, z2);
            Line(v1, v2, lineThickness);
        }
        //2D
        /// <summary>
        /// Converts a 2D vector into 3D vector and draws the line
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="z"></param>
        /// <param name="lineThickness"></param>
        public void Line(Vector2 p1, Vector2 p2, float z = 0, float lineThickness = 1)
        {
            Vector3 v1 = new Vector3(p1.X, p1.Y, z);
            Vector3 v2 = new Vector3(p2.X, p2.Y, z);
            this.Line(v1, v2, lineThickness);
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
        public void Line(float x1, float y1, float x2, float y2, float lineThickness = 1)
        {
            Vector3 v1 = new Vector3(x1, y1, 0);
            Vector3 v2 = new Vector3(x2, y2, 0);
            this.Line(v1, v2, lineThickness);
        }

        #endregion

        #region Rectrangle
        public void Rectangle(Vector3 lowerLeft, Vector3 upperRight, float zplane = 0, float lineThickness = 1)
        {
            Vector3 upperleft = new Vector3(lowerLeft.X, upperRight.Y, zplane);
            Vector3 lowerRight = new Vector3(upperRight.X, lowerLeft.Y, zplane);
            this.Line(lowerLeft, upperleft, lineThickness);
            this.Line(upperleft, upperRight, lineThickness);
            this.Line(upperRight, lowerRight, lineThickness);
            this.Line(lowerRight, lowerLeft, lineThickness);
        }
        public void Rectangle(Vector2 lowerLeft, Vector2 upperRight, float z = 0, float lineThickness = 1)
        {
            Vector3 v1 = new Vector3(lowerLeft.X, lowerLeft.Y, z);
            Vector3 v2 = new Vector3(upperRight.X, upperRight.Y, z);
            this.Rectangle(v1, v2, z, lineThickness);
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
            for (int i = 0; i < 360; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(x + Math.Cos(degInRad) * radius, y + Math.Sin(degInRad) * radius);
            }
            GL.End();
        }
        #endregion

    }
}
