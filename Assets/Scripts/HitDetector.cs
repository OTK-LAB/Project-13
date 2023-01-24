using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
      public SnakeManager snakeManager;
      public ScaleManager scaleManager;
      private void OnTriggerEnter(Collider other)
      {
            if (other.gameObject.tag == "Fruit")
            {
                  scaleManager.Point += 1;
                  snakeManager.fruitSpawner.FruitObjectsPool.Release(other.gameObject);
            }
            else if (other.gameObject.tag == "Player" && !snakeManager.bodyParts.Contains(other.gameObject))
            {
                  snakeManager.EnemySpawner.EnemyList.Remove(this.gameObject.transform.parent.gameObject);
                  Destroy(this.gameObject.transform.parent.gameObject);
            }
      }





}
