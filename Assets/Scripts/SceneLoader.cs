using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
      public Animation anim;
      public void LoadGameScene()
      {
            StartCoroutine("SceneLoadWithDelay");
      }
      public void LoadMenuScene()
      {
            AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(0);
      }
      private IEnumerator SceneLoadWithDelay()
      {
            anim.Play();
            yield return new WaitForSeconds(1f);
            AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(1);
      }
}
