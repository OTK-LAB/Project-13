using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetector : MonoBehaviour
{
      public SnakeManager snakeManager;
      private void OnTriggerEnter(Collider other)
      {
            if (other.gameObject.tag == "Fruit")
                  GameManager.instance.fruitSpawner.fruitObjectsPool.Release(other.gameObject);
            else if (other.gameObject.tag == "Player" && !snakeManager.bodyParts.Contains(other.gameObject.transform.parent.gameObject))
                  Time.timeScale = 0;
      }


}
