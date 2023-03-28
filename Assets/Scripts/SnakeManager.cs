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
      public EntityType entityType;
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
                  minDistanceBetween = 3 * Mathf.Pow((scaleManager.gameObject.transform.localScale.x / scaleManager.initialScale.x), 2);
                  float T = (distanceBetween / minDistanceBetween);
                  if (T >= 0.5f)
                        T = 0.5f;

                  rearBodyPart.transform.position = Vector3.Slerp(rearBodyPart.transform.position, frontBodyPart.transform.position, T);

                  rearBodyPart.transform.rotation = Quaternion.Slerp(rearBodyPart.transform.rotation, frontBodyPart.transform.rotation, T);



            }
      }
      public void CreateBodyPart()
      {
            GameObject newBodyPart = Instantiate(bodyPartPrefab, bodyParts[bodyParts.Count - 1].transform.position, Quaternion.identity);
            newBodyPart.transform.SetParent(this.gameObject.transform);
            newBodyPart.transform.Find("Mesh").localScale = bodyParts[1].transform.parent.GetComponent<SnakeManager>().scaleManager.gameObject.transform.localScale;
            bodyParts.Add(newBodyPart);
      }

}
public enum EntityType
{
      AI, User
}