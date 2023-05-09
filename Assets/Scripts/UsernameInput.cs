using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UsernameInput : MonoBehaviour
{
      public TMP_InputField inputField;
      public void ChooseUserName()
      {
            SaveSystem.gameFiles.userName = inputField.text;
            SaveSystem.Save();
      }
}
