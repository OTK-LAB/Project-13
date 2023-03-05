using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuPresenter : MonoBehaviour
{
      public GameObject deathMenu;
      void Update()
      {
            if (Time.timeScale == 0) deathMenu.SetActive(true);
      }
}
