using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMovement : MonoBehaviour
{
      public float RotationSpeed;
      void Update()
      {
            transform.Rotate(new Vector3(0, RotationSpeed, 0) * Time.deltaTime);
      }
}
