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
      }

}
