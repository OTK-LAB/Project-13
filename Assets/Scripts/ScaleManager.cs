using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScaleManager : MonoBehaviour
{
      public PointManager pointManager;
      public BodyPartType bodyPartType;
      public Vector3 initialScale;

      private void Awake()
      {
            initialScale = this.gameObject.transform.localScale;
      }
      void Update()
      {
            HandleHeadScaling();
            HandleBodyScaling();
            HandleYAxis();

      }
      public void HandleHeadScaling()
      {
            if (bodyPartType != BodyPartType.Head) return;
            this.gameObject.transform.localScale = (initialScale + initialScale * ((float)pointManager.points / 50f));
            if (this.gameObject.transform.localScale.x > initialScale.x * 3f)
                  this.gameObject.transform.localScale = initialScale * 3f;
      }
      public void HandleBodyScaling()
      {
            if (bodyPartType != BodyPartType.Body) return;
            this.gameObject.transform.localScale = (initialScale + initialScale * ((float)pointManager.points / 50f)) * 0.75f;
            if (this.gameObject.transform.localScale.x > initialScale.x * 3f * 0.75f)
                  this.gameObject.transform.localScale = initialScale * 3f * 0.75f;
      }
      public void HandleYAxis()
      {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.localScale.x / 100, this.gameObject.transform.position.z);
      }
}
public enum BodyPartType
{
      Head, Body
}