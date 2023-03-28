using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SceneLoader : MonoBehaviour
{
      public GameObject mainMenuStart, mainMenuLootBox, mainMenuText;

      public void LoadGameScene()
      {
            mainMenuLootBox.GetComponent<RectTransform>().DOAnchorPosX(-900, 1f);
            mainMenuStart.GetComponent<RectTransform>().DOAnchorPosX(-900, 1f);
            mainMenuText.GetComponent<RectTransform>().DOAnchorPosY(500, 1f).OnComplete(() =>
            SceneManager.LoadSceneAsync(1));
      }
      public void LoadMenuScene()
      {
            SceneManager.LoadSceneAsync(0);
      }

}
