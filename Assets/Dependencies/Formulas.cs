using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Formulas
{
      public static class VectorFormulas
      {
            public static float getAngleInRad(Vector3 from, Vector3 to)
            {
                  return Mathf.Atan2(from.z - to.z, from.x - to.x);
            }
            public static float getAngleInDeg(Vector3 from, Vector3 to)
            {
                  return getAngleInRad(from, to) * Mathf.Rad2Deg;
            }
            public static float getAngleInRad(Vector2 from, Vector2 to)
            {
                  return Mathf.Atan2(from.y - to.y, from.x - to.x);
            }
            public static float getAngleInDeg(Vector2 from, Vector2 to)
            {
                  return getAngleInRad(from, to) * Mathf.Rad2Deg;
            }
            public static float getYValueOfDeg(float Degrees)
            {
                  return Mathf.Sin(Degrees);
            }
            public static float getXValueOfDeg(float Degrees)
            {
                  return Mathf.Cos(Degrees);
            }
      }
}