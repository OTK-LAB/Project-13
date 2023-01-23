using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
      public List<GameObject> bodyParts = new List<GameObject>();
      public GameObject SnakeHead;
      public float minDistanceBetween;
      private float minDistance = 0.75f;
      public int MaxBodyPartsCount;
      private float dis;
      private GameObject curBodyPart;
      private GameObject prevBodyPart;
      public ScaleManager scale;
      public GameObject BodyPartPrefab;
      public float speed;
      public Vector3 moveVector;
      private void Start()
      {
            Application.targetFrameRate = 60;
      }
      void FixedUpdate()
      {
            if (scale.Point / 50 >= bodyParts.Count && bodyParts.Count < MaxBodyPartsCount)
            {
                  GameObject obj = Instantiate(BodyPartPrefab, Vector3.zero, Quaternion.identity);
                  bodyParts.Add(obj);
                  obj.transform.SetParent(this.gameObject.transform.parent.transform);
            }
            minDistance = minDistanceBetween * SnakeHead.transform.localScale.x * SnakeHead.transform.localScale.x;
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localScale.y / 2, this.gameObject.transform.localPosition.z);
            for (int i = 1; i < bodyParts.Count; i++)
            {
                  bodyParts[i].transform.localScale = SnakeHead.transform.localScale * 0.75f;
                  curBodyPart = bodyParts[i];
                  prevBodyPart = bodyParts[i - 1];

                  dis = Vector3.Distance(prevBodyPart.transform.localPosition, curBodyPart.transform.localPosition);


                  float T = Time.deltaTime * (dis / minDistance) * speed
                   * Mathf.Sqrt(Mathf.Pow(moveVector.x, 2) + Mathf.Pow(moveVector.z, 2));

                  if (T >= 0.5f)
                  {
                        T = 0.5f;
                  }

                  curBodyPart.transform.localPosition = Vector3.Slerp(curBodyPart.transform.localPosition, prevBodyPart.transform.localPosition, T);
                  curBodyPart.transform.rotation = Quaternion.Slerp(curBodyPart.transform.rotation, prevBodyPart.transform.rotation, T);
            }
      }
}