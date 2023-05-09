using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScaler : MonoBehaviour
{
      public Renderer rdrr;
      public Vector2 scale;
      void Start()
      {
            rdrr.material.mainTextureScale = scale;
      }


}
