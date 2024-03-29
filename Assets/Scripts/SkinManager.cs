using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SkinManager : MonoBehaviour
{
      public Database Database;
      public CinemachineFreeLook cinemachineFreeLook;
      private void Start()
      {
            ChangePlayerSkin(SaveSystem.gameFiles.equippedSkin);
      }

      public void ChangePlayerSkin(SkinID skinID)
      {
            GameObject oldPlayerObject = cinemachineFreeLook.LookAt.parent.gameObject;
            oldPlayerObject.SetActive(false);
            Destroy(oldPlayerObject);
            GameObject newPlayerObject = Instantiate(Database.skinDatabase[skinID].gameObject, Vector3.zero, Quaternion.identity);
            cinemachineFreeLook.LookAt = newPlayerObject.transform.Find("Head");
            cinemachineFreeLook.Follow = newPlayerObject.transform.Find("Head");
            newPlayerObject.transform.Find("Head").gameObject.GetComponent<CameraManager>().cinemachineFreeLook = cinemachineFreeLook;
            GameManager.instance.player = newPlayerObject;
      }

}
