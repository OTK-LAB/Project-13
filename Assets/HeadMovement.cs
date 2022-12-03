using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
      public float speed, rotationSpeed;
      // Start is called before the first frame update
      void Start()
      {
            Application.targetFrameRate = 60;
      }

      // Update is called once per frame
      void FixedUpdate()
      {
            float angle = Mathf.Deg2Rad * this.gameObject.transform.eulerAngles.y;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sin(angle) * speed, 0, Mathf.Cos(angle) * speed);

      }
      void Update()
      {
            if (Input.GetAxis("Horizontal") != 0)
            {
                  this.gameObject.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
            }
      }
}
