using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissionTaxiSingleton 
{
    private static MissionTaxiSingleton instance;
    public float missionStartTime;
    public bool stopped = true;
    public float missionTime;
    public GameObject destination;

    private MissionTaxiSingleton()
    {
        missionStartTime = 0;
    }

    public static MissionTaxiSingleton Instance()
    {
        {
            if (instance == null)
            {
                instance = new MissionTaxiSingleton();
            }
            return instance;
        }
    }

    public void SetMissionStartTime()
    {
        missionStartTime = Time.deltaTime;
    }

    public void SetDestination(GameObject dest)
    {
        destination = dest;
    }

    public void ResetMission()
    {
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
