using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
      public static GameManager instance;
      public FruitSpawner fruitSpawner;
      public EnemySpawner enemySpawner;
      public GameObject player;
      private void Awake()
      {
            if (instance != this && instance != null) Destroy(this);
            else instance = this;
      }
      public void RespawnPlayer(SnakeManager snakeManager)
      {
            Vector3 RandomPos = Formulas.RandomFormulas.ChooseRandomSpotInArena(enemySpawner.GameArena);
            foreach (GameObject part in snakeManager.bodyParts) part.transform.position = new Vector3(RandomPos.x, part.transform.position.y, RandomPos.z);
            Time.timeScale = 1;
      }
}
