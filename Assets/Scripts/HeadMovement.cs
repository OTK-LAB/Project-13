using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeadMovement : MonoBehaviour
{
      public float speed, rotationSpeed;
      private PlayerControls playerControls;
      public Vector3 moveVector;
      // Start is called before the first frame update
      private void Awake()
      {
            playerControls = new PlayerControls();
      }
      private void OnEnable()
      {
            playerControls.Enable();
      }
      private void OnDisable()
      {
            playerControls.Disable();
      }
      // Update is called once per frame
      private void FixedUpdate()
      {
            Vector2 movementInput = playerControls.Player.Move.ReadValue<Vector2>();
            moveVector = new Vector3(movementInput.x, 0f, movementInput.y);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(moveVector.x * speed, 0, moveVector.z * speed);

            if (moveVector != Vector3.zero)
            {
                  this.gameObject.transform.forward = moveVector;
            }
      }

}