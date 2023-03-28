using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
      public List<GameObject> bodyParts = new List<GameObject>();
      public GameObject bodyPartPrefab;
      public GameObject head;
      public Rigidbody rb;
      public float speed;
      [Header("Settings")]
      public float minDistanceBetween;
      public ScaleManager scaleManager;
      private float distanceBetween;
      private GameObject rearBodyPart;
      private GameObject frontBodyPart;

      private void Start()
      {
            Application.targetFrameRate = 60;
      }
      void FixedUpdate()
      {
            if (rb.velocity == Vector3.zero) return;
            for (int i = 1; i < bodyParts.Count; i++)
            {
                  rearBodyPart = bodyParts[i];//rear
                  frontBodyPart = bodyParts[i - 1];//front
                  distanceBetween = Vector3.Distance(frontBodyPart.transform.position, rearBodyPart.transform.position);

                  float T = (distanceBetween / minDistanceBetween)
                  * Mathf.Pow((scaleManager.initialScale.x / scaleManager.gameObject.transform.localScale.x), 3);
                  if (T >= 0.5f)
                        T = 0.5f;

                  rearBodyPart.transform.position = Vector3.Slerp(rearBodyPart.transform.position, frontBodyPart.transform.position, T);

                  rearBodyPart.transform.rotation = Quaternion.Slerp(rearBodyPart.transform.rotation, frontBodyPart.transform.rotation, T);



            }
      }


}