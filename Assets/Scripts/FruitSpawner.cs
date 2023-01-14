using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
      public float duration;
      public float time;
      public GameObject GameArena;
      public List<GameObject> FruitPrefabs;
      public List<GameObject> FruitObjects;

      void Update()
      {
            time += Time.deltaTime;
            if (time >= duration)
            {
                  if (FruitObjects.Count < 50)
                  {
                        time -= duration;
                        float scaleX = GameArena.transform.localScale.x;
                        float x = Random.Range(-50.5f * scaleX, 50.5f * scaleX);
                        float z = Random.Range(-50.5f * scaleX, 50.5f * scaleX);
                        GameObject fruit = Instantiate(FruitPrefabs[Random.Range(0, FruitPrefabs.Count)], new Vector3(x, 0.5f, z), Quaternion.identity);
                        FruitObjects.Add(fruit);
                  }
            }
      }
}
