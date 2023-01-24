using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
      public float duration;
      public float time;
      public GameObject GameArena, EnemyPrefab;
      public List<GameObject> EnemyList;
      public int maxSize;
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
            time += Time.deltaTime;
            if (time >= duration)
            {
                  if (EnemyList.Count < 1000)
                  {
                        float scaleX = GameArena.transform.localScale.x;
                        float x = Random.Range(-50.5f * scaleX, 50.5f * scaleX);
                        float z = Random.Range(-50.5f * scaleX, 50.5f * scaleX);
                        GameObject obj = Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity);
                        SnakeManager snakeManager = obj.GetComponent<SnakeManager>();
                        snakeManager.SnakeHead.transform.position = new Vector3(x, 0, z);
                        foreach (GameObject child in snakeManager.bodyParts)
                        {
                              child.transform.position = new Vector3(x, 0, z);
                        }
                        EnemyList.Add(obj);
                        snakeManager.fruitSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<FruitSpawner>();
                        snakeManager.EnemySpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawner>();
                        time -= duration;
                  }

            }

      }
}
