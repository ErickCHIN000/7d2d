using UnityEngine;

namespace _7d2dDev
{
    internal class Render : MonoBehaviour
    {
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

        public static Color Color
        {
            get
            {
                return GUI.color;
            }
            set
            {
                GUI.color = value;
            }
        }

        public static void DrawBox(Vector2 position, Vector2 size, Color color, bool centered = true)
        {
            Render.Color = color;
            Render.DrawBox(position, size, centered);
        }

        public static void DrawBox(Vector2 position, Vector2 size, bool centered = true)
        {
            Vector2 vector = centered ? (position - size / 2f) : position;
            GUI.DrawTexture(new Rect(position, size), Texture2D.whiteTexture, 0);
        }

        public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
        {
            Render.Color = color;
            Render.DrawString(position, label, centered);
        }

        public static void DrawString(Vector2 position, string label, bool centered = true)
        {
            GUIContent guicontent = new GUIContent(label);
            Vector2 vector = Render.StringStyle.CalcSize(guicontent);
            Vector2 vector2 = centered ? (position - vector / 2f) : position;
            GUI.Label(new Rect(vector2, vector), guicontent);
        }

        public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
        {
            Matrix4x4 matrix = GUI.matrix;
            bool flag = !Render.lineTex;
            if (flag)
            {
                Render.lineTex = new Texture2D(1, 1);
            }
            Color color2 = GUI.color;
            GUI.color = color;
            float num = Vector3.Angle(pointB - pointA, Vector2.right);
            bool flag2 = pointA.y > pointB.y;
            if (flag2)
            {
                num = -num;
            }
            GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
            GUIUtility.RotateAroundPivot(num, pointA);
            GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), Render.lineTex);
            GUI.matrix = matrix;
            GUI.color = color2;
        }

        public static void DrawBox(float x, float y, float w, float h, Color color, float thickness)
        {
            Render.DrawLine(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
            Render.DrawLine(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
            Render.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
            Render.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
        }

        public static void DrawBoxOutline(Vector2 Point, float width, float height, Color color, float thickness)
        {
            Render.DrawLine(Point, new Vector2(Point.x + width, Point.y), color, thickness);
            Render.DrawLine(Point, new Vector2(Point.x, Point.y + height), color, thickness);
            Render.DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x + width, Point.y), color, thickness);
            Render.DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x, Point.y + height), color, thickness);
        }

        public static Texture2D lineTex;
    }
}