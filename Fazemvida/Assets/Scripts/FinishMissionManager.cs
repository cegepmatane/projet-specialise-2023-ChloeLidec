using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMissionManager : MonoBehaviour
{

    public MissionGBSingleton missionGBSingleton = MissionGBSingleton.Instance();
    public Text checkpointUI;
    public StopWatch stopWatch;
    public PlayerSingleton playerSingleton = PlayerSingleton.Instance();
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !missionGBSingleton.stopped )
        {
            stopWatch.Finish();
            checkpointUI.text = "";
            missionGBSingleton.FinishMission();
            float missionTime = missionGBSingleton.missionTime;
            int nbOfCheckpointsPassed = missionGBSingleton.nbOfCheckpointsPassed;

            //calculate reward
            int reward = 0;
            if (nbOfCheckpointsPassed == 7)
            {
                reward = 700;
            }
            else
            {
                reward = 700 - (100 * (7 - nbOfCheckpointsPassed));
            }
            float timeDiff = 180 - missionTime;
            if (timeDiff > 0)
            {
                reward += (int)(timeDiff);
            }
            playerSingleton.AddMoney(reward);
        }
    }
}

