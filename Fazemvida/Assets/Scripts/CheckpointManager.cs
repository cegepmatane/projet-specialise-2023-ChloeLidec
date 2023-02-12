using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public MissionGBSingleton missionGBSingleton = MissionGBSingleton.Instance();
    public Text checkpointUI;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checkpoint");
        Debug.Log(other.gameObject.tag);
        Debug.Log(missionGBSingleton.missionStartTime);
        Debug.Log(missionGBSingleton.missionStartTime != 0 );
        if (other.gameObject.tag == "Player" && missionGBSingleton.missionStartTime != 0 )
        {
            Debug.Log("Checkpoint passed");
            missionGBSingleton.PassCheckpoint();
            checkpointUI.text = "Checkpoints " + missionGBSingleton.nbOfCheckpointsPassed + "/7";
            //deactivate checkpoint
            gameObject.SetActive(false);
        }
    }
}
