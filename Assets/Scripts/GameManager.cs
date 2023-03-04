using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
      public static GameManager instance;
      public FruitSpawner fruitSpawner;
      public EnemySpawner enemySpawner;
      private void Awake()
      {
            if (instance != this && instance != null) Destroy(this);
            else instance = this;
      }
}
