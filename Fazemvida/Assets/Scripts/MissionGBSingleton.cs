using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissionGBSingleton 
{
    private static MissionGBSingleton instance;

    public float missionStartTime;
    public int nbOfCheckpointsPassed;

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
        missionStartTime = Time.time;
    }

    public void PassCheckpoint()
    {
        nbOfCheckpointsPassed++;
    }

    public void DeleteInstance()
    {
        instance = null;
    }
}
