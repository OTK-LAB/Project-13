using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPresenter : MonoBehaviour
{
      public TMPro.TMP_Text leaderboardText;
      public int place;
      public LeaderBoardManager leaderBoardManager;
      private void Update()
      {
            if (leaderBoardManager.pointManagers.Contains(leaderBoardManager.pointManagers[place - 1]))
                  leaderboardText.text = place + ". " + leaderBoardManager.pointManagers[place - 1].userName + "(" + leaderBoardManager.pointManagers[place - 1].points + ")";
            else
                  return;
      }
}
