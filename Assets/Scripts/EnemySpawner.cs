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
                  if (EnemyList.Count < maxSize)
                  {
                        CreateEnemy();
                        time -= duration;
                  }

            }
      }
      void CreateEnemy()
      {
            Vector3 RandomPos = Formulas.RandomFormulas.ChooseRandomSpotInArena(GameArena);
            Vector3 spawnPos = new Vector3(RandomPos.x, 0, RandomPos.z);
            GameObject obj = Instantiate(EnemyPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
            SnakeManager snakeManager = obj.GetComponent<SnakeManager>();
            snakeManager.head.transform.position = spawnPos;
            foreach (GameObject part in snakeManager.bodyParts) part.transform.position = spawnPos;
            EnemyList.Add(obj);
      }
}
