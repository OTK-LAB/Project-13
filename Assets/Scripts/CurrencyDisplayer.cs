using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyDisplayer : MonoBehaviour
{
      public TMP_Text currencyText;


      void Update()
      {
            currencyText.text = "Currency: " + SaveSystem.gameFiles.currency.ToString();
      }
}
