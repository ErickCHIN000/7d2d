using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace _7d2dDev
{
    internal class esp : MonoBehaviour
    {
        static Camera cam;
        private void Update()
        {
            if(cam == null)
            {
                cam = Camera.main;
            }
        }

        private void OnGUI()
        {
            ESP(GameObject.FindGameObjectsWithTag("E_Enemy"), 100f, Color.red, 2);
        }

        private static void ESP(GameObject[] gameObjects, float maxDistance, Color color, float thickness)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                try 
                { 
                    Vector3 vector = cam.WorldToScreenPoint(gameObject.transform.position);
                    bool flag = vector.z > 0f & vector.y < (float)(Screen.width - 2);
                    if (flag)
                    {
                        Bounds bounds = TransformToBounds(gameObject.transform);
                        float distance = Vector3.Distance(bounds.center, cam.transform.position);
                        Rect rect = BoundsToScreenRect(bounds);
                        if(distance < maxDistance)
                        {
                            Render.DrawString(new Vector2(rect.x, rect.y + rect.height + 10), $"{gameObject.transform.parent.name} : {distance}",color, false);
                            Render.DrawBoxOutline(new Vector2(rect.x, rect.y - rect.height), rect.width, rect.height * 2, color, thickness);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (main.debug) Debug.LogException(ex);
                }

            }
        }

        private static Bounds TransformToBounds(Transform t)
        {
            return new Bounds(t.position, t.localScale);
        }

        private static Rect BoundsToScreenRect(Bounds b)
        {
            Vector3[] array = new Vector3[]
            {
            cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
            cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
            cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
            cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z)),
            cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
            cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
            cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
            cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z))
            };
            for (int i = 0; i < array.Length; i++)
            {
                array[i].y = (float)Screen.height - array[i].y;
            }
            Vector3 lhs = array[0];
            Vector3 lhs2 = array[0];
            for (int j = 1; j < array.Length; j++)
            {
                lhs = Vector3.Min(lhs, array[j]);
                lhs2 = Vector3.Max(lhs2, array[j]);
            }
            Rect result = Rect.MinMaxRect(lhs.x, lhs.y, lhs2.x, lhs2.y);
            result.xMin -= 1f;
            result.xMax += 1f;
            result.yMin -= 1f;
            result.yMax += 1f;
            return result;
        }

        private static IEnumerator SleepFor(float time)
        {
            yield return new WaitForSeconds(time);
            yield break;
        }
    }
}
