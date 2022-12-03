using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
      public SnakeManager snakeManager;
      private void OnTriggerEnter(Collider other)
      {
            if (other.gameObject == snakeManager.bodyParts[1] || other.gameObject == snakeManager.bodyParts[2])
            {
                  Debug.Log("Collision of First and Second Body Part");
            }

            else
            {
                  Debug.Log("You Lost");
                  Destroy(snakeManager.gameObject);
            }

      }


}
