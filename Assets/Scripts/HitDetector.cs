using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
      public SnakeManager snakeManager;
      public ScaleManager scaleManager;
      public FruitSpawner fruitSpawner;
      private void OnTriggerEnter(Collider other)
      {
            if (other.gameObject.tag == "Fruit")
            {
                  scaleManager.Point += 1;
                  fruitSpawner.FruitObjects.Remove(other.gameObject);
                  Destroy(other.gameObject);
            }
      }





}
