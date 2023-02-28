using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissionTaxiSingleton 
{
    private static MissionTaxiSingleton instance;
    public float missionStartTime;
    public int nbOfCheckpointsPassed;
    public bool stopped = true;
    public float missionTime;

    private MissionTaxiSingleton()
    {
        missionStartTime = 0;
        nbOfCheckpointsPassed = 0;
    }

    public static MissionTaxiSingleton Instance()
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
        missionTime = Time.deltaTime - missionStartTime;
    }

    public void DeleteInstance()
    {
        instance = null;
    }
}
