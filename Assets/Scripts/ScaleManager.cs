using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
      public int Point;


      // Update is called once per frame
      void Update()
      {
            this.gameObject.transform.localScale = Vector3.one + Vector3.one * ((float)Point / 50f);
            if (this.gameObject.transform.localScale.x > 5)
            {
                  this.gameObject.transform.localScale = Vector3.one * 5;
            }
      }
}
