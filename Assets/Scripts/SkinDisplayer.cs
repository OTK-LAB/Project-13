using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkinDisplayer : MonoBehaviour
{
      public Database database;
      public SkinID idToDisplay;
      public Button buyButton, equipButton;
      public TMP_Text priceText;
      public bool IsSkinOwned()
      {
            return SaveSystem.gameFiles.ownedSkinIdList.Exists(x => x == idToDisplay);
      }
      private void Start()
      {
            priceText.text = "Price: " + database.skinDatabase[idToDisplay].price.ToString("F0");
      }
      void Update()
      {
            DisplayUI();
      }
      public void DisplayUI()
      {
            equipButton.gameObject.SetActive(IsSkinOwned());
            buyButton.gameObject.SetActive(!IsSkinOwned());
            priceText.gameObject.SetActive(!IsSkinOwned());
      }
      public void BuySkin()
      {
            SaveSystem.gameFiles.currency -= database.skinDatabase[idToDisplay].price;
            SaveSystem.gameFiles.ownedSkinIdList.Add(idToDisplay);
      }
      public void EquipSkin()
      {
            SaveSystem.gameFiles.equippedSkin = idToDisplay;
      }
}
