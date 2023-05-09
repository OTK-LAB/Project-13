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
      private void Start()
      {
            SaveSystem.Load();
            InvokeRepeating("Save", 0.5f, 0.5f);
      }
      public void Save() => SaveSystem.Save();
      public void RespawnPlayer()
      {
            SnakeManager snakeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeManager>();
            Vector3 RandomPos = Formulas.RandomFormulas.ChooseRandomSpotInArena(enemySpawner.GameArena);
            foreach (GameObject part in snakeManager.bodyParts) part.transform.position = new Vector3(RandomPos.x, part.transform.position.y, RandomPos.z);
            Time.timeScale = 1;
      }
}
