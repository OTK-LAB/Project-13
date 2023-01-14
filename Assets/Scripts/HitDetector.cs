using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
      public SnakeManager snakeManager;
      public FruitSpawner fruitSpawner;
      private void OnTriggerEnter(Collider other)
      {
            if (other.gameObject.tag == "Fruit")
            {
                  Debug.Log("Ate a fruit.");
                  fruitSpawner.FruitObjects.Remove(other.gameObject);
                  Destroy(other.gameObject);
            }
      }





}
