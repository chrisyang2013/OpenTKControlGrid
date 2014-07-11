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
        public Draw()
        { }

        public void Line(Vector2 p1, Vector2 p2, float z1 = 0, float z2 = 0, float lineThickness = 1)
        {
            GL.LineWidth(lineThickness);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(p1.X, p1.Y, z1);
            GL.Vertex3(p2.X, p2.Y, z2);
            GL.End();
        }
        public void Line(float x1, float y1, float x2, float y2, float z1 = 0, float z2 = 0, float lineThickness = 1)
        {
            GL.LineWidth(lineThickness);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x2, y2, z2);
            GL.End();
        }

        public void Rectangle(Vector2 lowerLeft, Vector2 upperRight, float z = 0, float lineThickness = 1)
        {
            Vector2 upperleft = new Vector2(lowerLeft.X, upperRight.Y);
            Vector2 lowerRight = new Vector2(upperRight.X, lowerLeft.Y);
            this.Line(lowerLeft, upperleft, z1: z, z2: z, lineThickness: lineThickness);
            this.Line(upperleft, upperRight, z1: z, z2: z, lineThickness: lineThickness);
            this.Line(upperRight, lowerRight, z1: z, z2: z, lineThickness: lineThickness);
            this.Line(lowerRight, lowerLeft, z1: z, z2: z, lineThickness: lineThickness);
        }

    }
}
