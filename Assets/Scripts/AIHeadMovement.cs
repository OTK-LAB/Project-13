using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Formulas;
public class AIHeadMovement : MonoBehaviour
{
      private bool Selected = false;
      public Vector3 desiredPoint;
      public SnakeManager snakeManager;


      void FixedUpdate()
      {
            Vector3 distanceVector = desiredPoint - snakeManager.head.transform.position;
            float distance = distanceVector.sqrMagnitude;

            if (!Selected)
                  ChooseRandomFruitPosition();
            else
                  MoveEnemy();

      }
      private void Update()
      {
            Vector3 distanceVector = desiredPoint - snakeManager.head.transform.position;
            float distance = distanceVector.sqrMagnitude;

            if (distance < Mathf.Pow(snakeManager.speed, 2) * 2)
                  Selected = false;
      }
      public void ChooseRandomFruitPosition()
      {
            Vector3 fruitpos = GameManager.instance.fruitSpawner.fruitObjects[Random.Range(0, GameManager.instance.fruitSpawner.fruitObjects.Count)].transform.position;
            desiredPoint = new Vector3(fruitpos.x, 0, fruitpos.z);
            Selected = true;
      }
      public void MoveEnemy()
      {
            Vector3 direction = desiredPoint - snakeManager.head.transform.position;
            snakeManager.rb.velocity = new Vector3(direction.normalized.x, 0f, direction.normalized.z) * snakeManager.speed;

      }
}
