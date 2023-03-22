using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
      public SnakeManager snakeManager;
      private PlayerControls playerControls;
      public Rigidbody rb;
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
            Vector3 direction = new Vector3(movementInput.x, 0f, movementInput.y);
            rb.velocity = direction * snakeManager.speed;
            if (movementInput == Vector2.zero)
                  return;
            snakeManager.head.transform.rotation = Quaternion.Euler(0, Formulas.VectorFormulas.getAngleInDeg(new Vector3(movementInput.y, 0, movementInput.x), new Vector3(0, 0, 0)), 0);

      }

}
