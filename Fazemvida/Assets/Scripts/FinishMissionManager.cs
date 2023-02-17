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
    public GameObject human = null;
    public GameObject mainUI = null;
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

            //manage UI
            GameObject move = mainUI.transform.Find("UI_Virtual_Joystick_Move").gameObject;
            GameObject look = mainUI.transform.Find("UI_Virtual_Joystick_Look").gameObject;
            GameObject sprint = mainUI.transform.Find("UI_Virtual_Button_Sprint").gameObject;
            GameObject jump = mainUI.transform.Find("UI_Virtual_Button_Jump").gameObject;
            move.SetActive(false);
            look.SetActive(false);
            sprint.SetActive(false);
            jump.SetActive(false);


            GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
            GameObject MainCamera = human.transform.Find("MainCamera").gameObject;
            GameObject playerFollow = human.transform.Find("PlayerFollowCamera").gameObject;
            MainCamera.SetActive(false);
            playerFollow.SetActive(false);
            playerCapsule.SetActive(false);
            
            GameObject inGameUI = mainUI.transform.Find("InGameUI").gameObject;
            inGameUI.SetActive(false);
            GameObject menuUI = mainUI.transform.Find("EndMGBUI").gameObject;
            string recap = "Bravo! Vous avez terminé la mission en " + missionTime + " secondes et vous avez passé " + nbOfCheckpointsPassed + " checkpoints. Vous avez gagné " + reward + " pièces!";
            menuUI.transform.Find("Recap").GetComponent<Text>().text = recap;
            menuUI.SetActive(true);
        }
    }
    public void HideMenu(){
        GameObject move = mainUI.transform.Find("UI_Virtual_Joystick_Move").gameObject;
        GameObject look = mainUI.transform.Find("UI_Virtual_Joystick_Look").gameObject;
        GameObject sprint = mainUI.transform.Find("UI_Virtual_Button_Sprint").gameObject;
        GameObject jump = mainUI.transform.Find("UI_Virtual_Button_Jump").gameObject;
        move.SetActive(true);
        look.SetActive(true);
        sprint.SetActive(true);
        jump.SetActive(true);

        GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
        GameObject MainCamera = human.transform.Find("MainCamera").gameObject;
        GameObject playerFollow = human.transform.Find("PlayerFollowCamera").gameObject;
        MainCamera.SetActive(true);
        playerFollow.SetActive(true);
        playerCapsule.SetActive(true);

        GameObject inGameUI = mainUI.transform.Find("InGameUI").gameObject;
        inGameUI.SetActive(true);
        GameObject menuUI = mainUI.transform.Find("EndMGBUI").gameObject;
        menuUI.SetActive(false);
}
}


