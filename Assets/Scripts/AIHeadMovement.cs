using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Formulas;
public class AIHeadMovement : MonoBehaviour
{
      private bool Selected = false;
      public Vector3 DesiredPoint;

      public SnakeManager snakeManager;
      public FruitSpawner fruitSpawner;


      void FixedUpdate()
      {
            if (!Selected && fruitSpawner.FruitObjects.Count > 10)
            {
                  Vector3 fruitpos = fruitSpawner.FruitObjects[Random.Range(0, fruitSpawner.FruitObjects.Count)].transform.position; ;
                  DesiredPoint = new Vector3(fruitpos.x, 0, fruitpos.z);
                  Selected = true;
            }
            else if (fruitSpawner.FruitObjects.Count > 0 && DesiredPoint != null)
            {
                  if (Vector3.Distance(transform.localPosition, DesiredPoint) < 1)
                  {
                        Selected = false;
                  }
                  float Deg = VectorFormulas.getAngleInDeg(DesiredPoint, transform.localPosition);
                  snakeManager.moveVector = new Vector3(VectorFormulas.getXValueOfDeg(Deg), 0f, VectorFormulas.getYValueOfDeg(Deg));
                  this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(snakeManager.moveVector.x * snakeManager.speed, 0, snakeManager.moveVector.z * snakeManager.speed);
                  if (snakeManager.moveVector != Vector3.zero)
                  {
                        this.gameObject.transform.forward = snakeManager.moveVector;
                  }

            }

      }
}