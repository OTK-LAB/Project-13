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
      private float distanceBetween;
      private GameObject rearBodyPart;
      private GameObject frontBodyPart;

      private void Start()
      {
            Application.targetFrameRate = 60;
      }
      void FixedUpdate()
      {
            for (int i = 1; i < bodyParts.Count; i++)
            {
                  rearBodyPart = bodyParts[i];//rear
                  frontBodyPart = bodyParts[i - 1];//front
                  distanceBetween = Vector3.Distance(frontBodyPart.transform.position, rearBodyPart.transform.position);

                  float T = (distanceBetween / minDistanceBetween) *
                   Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2));
                  if (T >= 0.5f)
                        T = 0.5f;

                  rearBodyPart.transform.position = Vector3.Lerp(rearBodyPart.transform.position, frontBodyPart.transform.position, T);
                  Quaternion targetRotation = new Quaternion(0f, frontBodyPart.transform.rotation.y, 0f, 0f);
                  rearBodyPart.transform.rotation = Quaternion.Lerp(rearBodyPart.transform.rotation, targetRotation, T);


            }
      }


}