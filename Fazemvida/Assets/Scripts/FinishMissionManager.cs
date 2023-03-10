using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMissionManager : MonoBehaviour
{

    public MissionGBSingleton missionGBSingleton = MissionGBSingleton.Instance();
    public MissionTaxiSingleton missionTaxiSingleton = MissionTaxiSingleton.Instance();
    public Text checkpointUI;
    public StopWatch stopWatch;
    public PlayerSingleton playerSingleton = PlayerSingleton.Instance();
    public GameObject human = null;
    public GameObject mainUI = null;
    public GameObject taxi = null;
    private Vector3 taxiPosition = new Vector3(0, 0, 0);
    [Header("Coin UI")]
    public GameObject coinUI;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !missionGBSingleton.stopped )
        {
            stopWatch.Finish();
            checkpointUI.text = "";
            missionGBSingleton.FinishMission();
            //get mission time in seconds
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
            string recap = "Bravo! Vous avez termin?? la mission en " + missionTime + " secondes et vous avez pass?? " + nbOfCheckpointsPassed + " checkpoints. Vous avez gagn?? " + reward + " pi??ces!";
            menuUI.transform.Find("Recap").GetComponent<Text>().text = recap;
            menuUI.SetActive(true);
        }
        else if (other.gameObject.tag == "Player" && !missionTaxiSingleton.stopped)
        {
            stopWatch.Finish();
            missionTaxiSingleton.FinishMission();
            missionTaxiSingleton.destination.SetActive(false);
            taxiPosition = taxi.transform.position;
            taxi.SetActive(false);
            float missionTime = missionTaxiSingleton.missionTime;
            //calculate reward
            int reward = 0;
            float timeDiff = 360 - missionTime;
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
            GameObject menuUI = mainUI.transform.Find("EndMTUI").gameObject;
            string recap = "Bravo! Vous avez termin?? la mission en " + missionTime + " secondes. Vous avez gagn?? " + reward + " pi??ces!";
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
        //update coin ammount
        GameObject textCA = coinUI.transform.Find("CoinAmount").gameObject;
        textCA.GetComponent<UnityEngine.UI.Text>().text = playerSingleton.playerMoney.ToString();
        mainUI.transform.Find("EndMTUI").gameObject.SetActive(false);
        mainUI.transform.Find("EndMGBUI").gameObject.SetActive(false);
        mainUI.transform.Find("VehicleUI").gameObject.SetActive(false);
}
}


