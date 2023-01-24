using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Formulas;
public class EnemySpawner : MonoBehaviour
{
      public float duration;
      public float time;
      public GameObject GameArena, EnemyPrefab;
      public List<GameObject> EnemyList;
      public int maxSize;

      void Update()
      {
            time += Time.deltaTime;
            if (time >= duration)
            {
                  if (EnemyList.Count < 1000)
                  {
                        CreateEnemy();
                        time -= duration;
                  }

            }
      }
      void CreateEnemy()
      {
            Vector3 RandomPos = Formulas.RandomFormulas.ChooseRandomSpotInArena(GameArena);
            GameObject obj = Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity);
            SnakeManager snakeManager = obj.GetComponent<SnakeManager>();
            snakeManager.SnakeHead.transform.position = new Vector3(RandomPos.x, 0, RandomPos.z);
            foreach (GameObject child in snakeManager.bodyParts)
            {
                  child.transform.position = new Vector3(RandomPos.x, 0, RandomPos.z);
            }
            snakeManager.fruitSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<FruitSpawner>();
            snakeManager.EnemySpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawner>();
            EnemyList.Add(obj);
      }
}
