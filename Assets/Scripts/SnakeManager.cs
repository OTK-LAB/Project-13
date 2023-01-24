using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
      [Header("Dependencies")]
      public FruitSpawner fruitSpawner;
      public EnemySpawner EnemySpawner;
      public ScaleManager scale;
      public List<GameObject> bodyParts = new List<GameObject>();
      public GameObject BodyPartPrefab;
      public GameObject SnakeHead;
      [Header("Settings")]
      public float minDistanceBetween;
      public int MaxBodyPartsCount;
      public float speed;
      public Vector3 moveVector;
      private float minDistance = 0.75f;
      private float distanceBetween;
      private GameObject curBodyPart;
      private GameObject prevBodyPart;

      public int PointPerBody;
      private void Start()
      {
            Application.targetFrameRate = 60;
      }
      void FixedUpdate()
      {
            FixSnake();
            for (int i = 1; i < bodyParts.Count; i++)
            {
                  bodyParts[i].transform.localScale = SnakeHead.transform.localScale * 0.75f;
                  curBodyPart = bodyParts[i];
                  prevBodyPart = bodyParts[i - 1];
                  distanceBetween = Vector3.Distance(prevBodyPart.transform.localPosition, curBodyPart.transform.localPosition);
                  float T = Time.deltaTime * (distanceBetween / minDistance) * speed
                   * Mathf.Sqrt(Mathf.Pow(moveVector.x, 2) + Mathf.Pow(moveVector.z, 2));
                  if (T >= 0.5f)
                  {
                        T = 0.5f;
                  }
                  curBodyPart.transform.localPosition = Vector3.Slerp(curBodyPart.transform.localPosition, prevBodyPart.transform.localPosition, T);
                  curBodyPart.transform.rotation = Quaternion.Slerp(curBodyPart.transform.rotation, prevBodyPart.transform.rotation, T);
            }
      }
      private void FixSnake()
      {
            if (scale.Point / PointPerBody >= bodyParts.Count - 1 && bodyParts.Count < MaxBodyPartsCount)
            {
                  GameObject obj = Instantiate(BodyPartPrefab, bodyParts[bodyParts.Count - 1].transform.position, Quaternion.identity);
                  bodyParts.Add(obj);
                  obj.transform.SetParent(this.gameObject.transform);
            }
            minDistance = minDistanceBetween * SnakeHead.transform.localScale.x * SnakeHead.transform.localScale.x;
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localScale.y / 2, this.gameObject.transform.localPosition.z);
      }
}