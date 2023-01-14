using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
      public List<GameObject> bodyParts = new List<GameObject>();

      public GameObject SnakeHead;

      public float minDistance = 0.5f;
      public GameObject bodyPrefab;

      private float dis;
      private GameObject curBodyPart;
      private GameObject prevBodyPart;

      private void Start()
      {
            Application.targetFrameRate = 60;

      }
      void FixedUpdate()
      {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.localScale.y / 2, this.gameObject.transform.position.z);
            for (int i = 1; i < bodyParts.Count; i++)
            {
                  curBodyPart = bodyParts[i];
                  prevBodyPart = bodyParts[i - 1];

                  dis = Vector3.Distance(prevBodyPart.transform.position, curBodyPart.transform.position);


                  float T = Time.deltaTime * (dis / minDistance) * SnakeHead.GetComponent<HeadMovement>().speed
                   * Mathf.Sqrt(Mathf.Pow(SnakeHead.GetComponent<HeadMovement>().moveVector.x, 2) + Mathf.Pow(SnakeHead.GetComponent<HeadMovement>().moveVector.z, 2));

                  if (T >= 0.5f)
                  {
                        T = 0.5f;
                  }

                  curBodyPart.transform.position = Vector3.Slerp(curBodyPart.transform.position, prevBodyPart.transform.position, T);
                  curBodyPart.transform.rotation = Quaternion.Slerp(curBodyPart.transform.rotation, prevBodyPart.transform.rotation, T);
            }
      }
}