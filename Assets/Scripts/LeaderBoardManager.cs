using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{
      public EnemySpawner enemySpawner;
      public List<PointManager> pointManagers = new List<PointManager>();
      public void Update()
      {
            SetLeaderboardList();
      }
      public void SetLeaderboardList()
      {
            pointManagers.Clear();
            foreach (GameObject obj in enemySpawner.EnemyList)
                  pointManagers.Add(obj.GetComponent<PointManager>());

            pointManagers.Add(GameManager.instance.player.GetComponent<PointManager>());
            pointManagers.Sort((p2, p1) => p1.points.CompareTo(p2.points));
      }
}
