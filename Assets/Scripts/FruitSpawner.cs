using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class FruitSpawner : MonoBehaviour
{
      public float duration;
      public float time;
      public GameObject gameArena;
      public List<GameObject> fruitPrefabs;
      public List<GameObject> fruitObjects;
      public IObjectPool<GameObject> fruitObjectsPool;
      public int maxSize;
      private void Awake()
      {
            fruitObjectsPool = new ObjectPool<GameObject>(
                  createFunc,
                  onGet,
                  onRelease,
                  onDestroy,
                  maxSize: maxSize
                  );

      }
      private void Start()
      {
            for (int i = 0; i < 25; i++)
                  fruitObjectsPool.Get();
      }
      public void onDestroy(GameObject obj)
      {
            fruitObjects.Remove(obj);
            Destroy(obj);
      }
      public void onGet(GameObject obj)
      {
            Vector3 RandomPos = Formulas.RandomFormulas.ChooseRandomSpotInArena(gameArena);
            obj.transform.position = new Vector3(RandomPos.x, 0.5f, RandomPos.z);
            obj.gameObject.SetActive(true);
            fruitObjects.Add(obj);
      }
      public void onRelease(GameObject obj)
      {
            obj.gameObject.SetActive(false);
            fruitObjects.Remove(obj);
      }
      public GameObject createFunc()
      {
            GameObject fruit = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Count)], Vector3.zero, Quaternion.identity);
            return fruit;
      }
      void Update()
      {
            time += Time.deltaTime;
            if (time >= duration)
            {
                  if (fruitObjects.Count < 1000)
                  {
                        fruitObjectsPool.Get();
                        time -= duration;
                  }

            }
      }
}
