using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
      public void Save() => SaveSystem.Save();
      private void Start()
      {
            SaveSystem.Load();
            InvokeRepeating("Save", 0, 0.1f);
      }
}
