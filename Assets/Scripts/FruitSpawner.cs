using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class FruitSpawner : MonoBehaviour
{
      public float duration;
      public float time;
      public GameObject GameArena;
      public List<GameObject> FruitPrefabs;
      public List<GameObject> FruitObjects;
      public IObjectPool<GameObject> FruitObjectsPool;
      public int maxSize;
      private void Awake()
      {
            FruitObjectsPool = new ObjectPool<GameObject>(
                  createFunc,
                  onGet,
                  onRelease,
                  onDestroy,
                  maxSize: 1000
                  );

      }
      public void onDestroy(GameObject obj)
      {
            FruitObjects.Remove(obj);
            Destroy(obj);
      }
      public void onGet(GameObject obj)
      {
            float scaleX = GameArena.transform.localScale.x;
            float x = Random.Range(-50.5f * scaleX, 50.5f * scaleX);
            float z = Random.Range(-50.5f * scaleX, 50.5f * scaleX);
            obj.transform.position = new Vector3(x, 0, z);
            obj.gameObject.SetActive(true);
            FruitObjects.Add(obj);
      }
      public void onRelease(GameObject obj)
      {
            obj.gameObject.SetActive(false);
            FruitObjects.Remove(obj);
      }
      public GameObject createFunc()
      {
            GameObject fruit = Instantiate(FruitPrefabs[Random.Range(0, FruitPrefabs.Count)], Vector3.zero, Quaternion.identity);
            return fruit;
      }
      void Update()
      {
            time += Time.deltaTime;
            if (time >= duration)
            {
                  if (FruitObjects.Count < 1000)
                  {
                        FruitObjectsPool.Get();
                        time -= duration;
                  }

            }
      }
}
