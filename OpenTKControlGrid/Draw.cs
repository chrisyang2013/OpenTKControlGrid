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
        /// Implementation of GL graphics function for higher level use in WLP2
        /// </summary>
        public Draw() { }

        #region Setting
        /// <summary>
        /// Set the LINEWIDTH until function is called again
        /// </summary>
        /// <param name="linewidth">Specifies the LINEWIDTH to be drawn
        /// <para>Default: linewidth = 1</para></param>
        public static void setLineWidth(float linewidth = 1)
        {
            GL.LineWidth(linewidth);
        }
        /// <summary>
        /// Sets the COLOR until fucntion is called again
        /// </summary>
        /// <param name="color">Specifies the COLOR to be drawn
        /// <para>Default: color = Color.Black</para></param>
        public static void setColor(Color color)
        {
            GL.Color3(color);
        }

        #endregion

        #region Line
        //3D
        /// <summary>
        /// Draws a LINE in 3-D space
        /// </summary>
        /// <param name="p1">Coordinates that specify the starting point of the LINE</param>
        /// <param name="p2">Coordinates that specify the ending point of the LINE</param>
        public static void Line3D(Vector3 p1, Vector3 p2)
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(p1);
            GL.Vertex3(p2);
            GL.End();
        }
        [Obsolete("Draw.Line(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), lineThickness)")]
        public static void Line3D(float x1, float y1, float z1, float x2, float y2, float z2, float lineThickness = 1)
        {
            Vector3 v1 = new Vector3(x1, x2, z1);
            Vector3 v2 = new Vector3(x1, x2, z2);
            Line3D(v1, v2);
        }
        //2D
        /// <summary>
        /// Draws a LINE in 3-D space
        /// </summary>
        /// <param name="p1">Coordinates that specify the starting point of the LINE</param>
        /// <param name="p2">Coordinates that specify the ending point of the LINE</param>
        /// <param name="z">Specifies the Z-plane the LINE is drawn on
        /// <para>Default: z = 0</para></param>
        public static void Line(Vector2 p1, Vector2 p2, float z = 0)
        {
            Vector3 v1 = new Vector3(p1.X, p1.Y, z);
            Vector3 v2 = new Vector3(p2.X, p2.Y, z);
            Line3D(v1, v2);
        }
        /// <summary>
        /// Draws a LINE in 2-D space
        /// </summary>
        /// <param name="x1">X-Coordinates that specify the starting point of the LINE</param>
        /// <param name="y1">Y-Coordinates that specify the starting point of the LINE</param>
        /// <param name="x2">X-Coordinates that specify the ending point of the LINE</param>
        /// <param name="y2">Y-Coordinates that specify the ending point of the LINE</param>
        /// <param name="lineThickness"></param>
        public static void Line(float x1, float y1, float x2, float y2)
        {
            Vector3 v1 = new Vector3(x1, y1, 0);
            Vector3 v2 = new Vector3(x2, y2, 0);
            Line3D(v1, v2);
        }

        #endregion

        #region Rectrangle
        /// <summary>
        /// Draws a RECTANGLE in 3 dimensional space
        /// </summary>
        /// <param name="lowerLeft">Coordinates that specify the lower left corner of the RECTANGLE</param>
        /// <param name="upperRight">Coordinates that specify the upper right corner of the RECTANGLE</param>
        /// <param name="zplane">Specifies the Z-plane the RECTANGLE is on. 
        /// <para>Default: zplane = 0</para></param>
        public static void Rectangle3D(Vector3 lowerLeft, Vector3 upperRight, float zplane = 0)
        {
            Vector3 upperleft = new Vector3(lowerLeft.X, upperRight.Y, zplane);
            Vector3 lowerRight = new Vector3(upperRight.X, lowerLeft.Y, zplane);
            Line3D(lowerLeft, upperleft);
            Line3D(upperleft, upperRight);
            Line3D(upperRight, lowerRight);
            Line3D(lowerRight, lowerLeft);
        }
        /// <summary>
        /// Draws a RECTANGLE
        /// </summary>
        /// <param name="lowerLeft">Coordinates that specify the lower left corner of the RECTANGLE</param>
        /// <param name="upperRight">Coordinates that specify the upper right corner of the RECTANGLE</param>
        public static void Rectangle(Vector2 lowerLeft, Vector2 upperRight)
        {
            Vector3 v1 = new Vector3(lowerLeft.X, lowerLeft.Y, 0);
            Vector3 v2 = new Vector3(upperRight.X, upperRight.Y, 0);
            Rectangle3D(v1, v2, 0);
        }
        /// <summary>
        /// Draw a RECTANGLE with the inside filled
        /// </summary>
        /// <param name="lowerLeft">Coordinates that specify the lower left corner of the RECTANGLE</param>
        /// <param name="upperRight">Coordinates that specify the upper right corner of the RECTANGLE</param>
        public static void FilledRectangle2(Vector2 lowerLeft, Vector2 upperRight)
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
        /// Constant that represents the ratio between RADIANS and DEGREES
        /// </summary>
        private const float DEG2RAD = (float)Math.PI / 180f;
        /// <summary>
        /// Draws a CIRCLE
        /// </summary>
        /// <param name="radius">Radius of CIRCLE</param>
        /// <param name="x">X coordinate of the CIRCLE</param>
        /// <param name="y">Y coordinate of the CIRCLE</param>
        public static void Circle(float radius, float x, float y)
        {
            GL.Begin(PrimitiveType.LineLoop);
            //circles has 360 segments
            for (int i = 0; i <= 360; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(x + Math.Cos(degInRad) * radius, y + Math.Sin(degInRad) * radius);
            }
            GL.End();
        }
        /// <summary>
        /// Draws an circular ARC
        /// </summary>
        /// <param name="radius">Radius of the ARC</param>
        /// <param name="x">X coordinate of the center of the ARC</param>
        /// <param name="y">Y coordinate of the center of the ARC</param>
        /// <param name="startangle">Starting angle for the ARC</param>
        /// <param name="endangle">Ending angle for the ARC</param>
        public static void Arc(float radius, float x, float y, float startangle, float endangle)
        {
            GL.Begin(PrimitiveType.LineLoop);
            //circles has 360 segments
            for (float i = startangle; i <= endangle; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(x + Math.Cos(degInRad) * radius, y + Math.Sin(degInRad) * radius);
            }
            GL.End();
        }
        /// <summary>
        /// Draws a CIRCLE that is filled inside
        /// </summary>
        /// <param name="radius">Radius of the CIRCLE</param>
        /// <param name="x">X coordinate of the CIRCLE </param>
        /// <param name="y">Y coordinate of the CIRCLE</param>
        public static void FilledCircle(float radius, float x, float y)
        {
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Vertex2(x, y);
            for (int i = 0; i <= 360; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(x + Math.Cos(degInRad) * radius, y + Math.Sin(degInRad) * radius);
            }
            GL.End();
        }
        /// <summary>
        /// Draws a wedge of the circle
        /// </summary>
        /// <param name="radius">Radius of the circle for the WEDGE</param>
        /// <param name="x">X coordinate of the center of the WEDGE</param>
        /// <param name="y">Y coordinate of the center of the WEDGE</param>
        /// <param name="startangle">Starting angle for the WEDGE</param>
        /// <param name="endangle">Ending angle for the WEDGE</param>
        public static void FillWedge(float radius, float x, float y, float startangle, float endangle)
        {
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Vertex2(x, y);
            for (float i = startangle; i <= endangle; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(x + Math.Cos(degInRad) * radius, y + Math.Sin(degInRad) * radius);
            }
            GL.End();
        }
        #endregion

        #region Triangle
        /// <summary>
        /// Draws a TRIANGLE at the three coordinates given
        /// </summary>
        /// <param name="v1">First coordinate of the TRIANGLE</param>
        /// <param name="v2">Second coordinate of the TRIANGLE</param>
        /// <param name="v3">Thrid coordinate of the TRIANGLE</param>
        public static void Triangle(Vector2 v1, Vector2 v2, Vector2 v3)
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex2(v1);
            GL.Vertex2(v2);
            GL.Vertex2(v3);
            GL.End();
        }
        #endregion

    }
}
