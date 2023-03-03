using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissionGBSingleton 
{
    private static MissionGBSingleton instance;
    public float missionStartTime;
    public int nbOfCheckpointsPassed;
    public bool stopped = true;
    public float missionTime;

    private MissionGBSingleton()
    {
        missionStartTime = 0;
        nbOfCheckpointsPassed = 0;
    }

    public static MissionGBSingleton Instance()
    {
        {
            if (instance == null)
            {
                instance = new MissionGBSingleton();
            }
            return instance;
        }
    }

    public void SetMissionStartTime()
    {
        missionStartTime = Time.deltaTime;
    }

    public void PassCheckpoint()
    {
        nbOfCheckpointsPassed++;
    }

    public void ResetMission()
    {
        nbOfCheckpointsPassed = 0;
        missionStartTime = 0;
        stopped = false;
    }

    public void FinishMission()
    {
        stopped = true;
        missionTime = Time.time - missionStartTime;
        string minutes = ((int)missionTime / 60).ToString();
        string seconds = (missionTime % 60).ToString("f2");
        missionTime = 60 * float.Parse(minutes) + float.Parse(seconds);
    }

    public void DeleteInstance()
    {
        instance = null;
    }
}
