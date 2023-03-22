using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
      public SnakeManager snakeManager;
      private void OnTriggerEnter(Collider other)
      {
            if (other.gameObject.tag == "Fruit")
                  GameManager.instance.fruitSpawner.fruitObjectsPool.Release(other.gameObject);
            else if (other.gameObject.tag == "Player" && !snakeManager.bodyParts.Contains(other.gameObject.transform.parent.gameObject))
            {
                  GameObject parent = this.gameObject.transform.parent.parent.gameObject;
                  GameManager.instance.enemySpawner.EnemyList.Remove(parent);
                  Destroy(parent);
            }
      }





}
