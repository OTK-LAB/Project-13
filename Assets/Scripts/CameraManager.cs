using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
      public CinemachineFreeLook cinemachineFreeLook;
      public int cameraValue;
      void Update()
      {
            cinemachineFreeLook.m_Orbits[1].m_Height = cameraValue * this.gameObject.transform.localScale.x / 1.6f;
            cinemachineFreeLook.m_Orbits[1].m_Radius = cameraValue * this.gameObject.transform.localScale.x / 1.2f;
      }
}


