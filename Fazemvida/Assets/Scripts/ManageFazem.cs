using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageFazem : MonoBehaviour
{
    PlayerSingleton playerSingleton;
    MissionGBSingleton missionGBSingleton;
    MissionTaxiSingleton missionTaxiSingleton;

    
    [Header("Human")]
    public GameObject human;

    [Header("UI")]
    public GameObject coinUI;
    public GameObject mainUI;
    public GameObject vehicleUI;

    [Header("Missions")]
    public StopWatch stopWatch;

    [Header("MissionGB")]
    public Text checkpointText;
    public GameObject[] checkpoints;

    [Header("MissionTaxi")]
    public GameObject taxi;
    public GameObject[] possibleDestinations;

    [Header("Houses")]
    public GameObject housesHaloContainer;
    public Material buildingsToBuyHalo;
    public Material buildingsHalo;
    // Start is called before the first frame update
    void Start()
    {
        playerSingleton = PlayerSingleton.Instance();
        GameObject textCA = coinUI.transform.Find("CoinAmount").gameObject;
        textCA.GetComponent<UnityEngine.UI.Text>().text = playerSingleton.playerMoney.ToString();
        GameObject capsule = human.transform.Find("PlayerCapsule").gameObject;
        capsule.transform.position = new Vector3(playerSingleton.playerPosition[0], playerSingleton.playerPosition[1], playerSingleton.playerPosition[2]);

        foreach (Transform child in housesHaloContainer.transform)
        {
            if (playerSingleton.GetHouseName() == child.gameObject.name){
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                meshRenderer.material = buildingsToBuyHalo;
            }
            else
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                meshRenderer.material = buildingsHalo;
            }
        }
        if (playerSingleton.leftHouse){
        GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
        string houseName = playerSingleton.GetHouseName();
        foreach (Transform child in housesHaloContainer.transform)
        {
            if (child.name == houseName)
            {
                playerCapsule.transform.position = child.transform.position;
                playerCapsule.transform.position = new Vector3(playerCapsule.transform.position.x, 60, playerCapsule.transform.position.z + 2);
            }
        }
        playerSingleton.leftHouse = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject textCA = coinUI.transform.Find("CoinAmount").gameObject;
        textCA.GetComponent<UnityEngine.UI.Text>().text = playerSingleton.playerMoney.ToString();
    }

    public string missionStarted(){
        if (missionGBSingleton!=null && !missionGBSingleton.stopped){
            return "GB";
        }
        else if (missionTaxiSingleton!=null && !missionTaxiSingleton.stopped){
            return "Taxi";
        }
        else{
            return "none";
        }
    }

    public void StartMissionGB()
    {
        //reset mission
        missionGBSingleton = MissionGBSingleton.Instance();
        missionGBSingleton.ResetMission();
        missionGBSingleton.SetMissionStartTime();
        foreach (GameObject checkpoint in checkpoints)
        {
            checkpoint.SetActive(true);
        }
        stopWatch.StartSW();
        checkpointText.text = "Checkpoints 0/7";
    }

    public void StartMissionTaxi(){
        missionTaxiSingleton = MissionTaxiSingleton.Instance();
        missionTaxiSingleton.ResetMission();
        //get random destination from possibleDestinations
        int randomIndex = Random.Range(0, possibleDestinations.Length);
        GameObject destination = possibleDestinations[randomIndex];
        missionTaxiSingleton.SetDestination(destination);
        destination.SetActive(true);
        //deactivate the player
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
        taxi.SetActive(true);
        vehicleUI.SetActive(true);
        vehicleUI.transform.Find("MenuBtn").gameObject.SetActive(false);
        PrometeoCarController  prometeoCarController = taxi.GetComponent<PrometeoCarController>();
        prometeoCarController.enabled = true;
        taxi.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = true;
        taxi.transform.position = new Vector3(playerSingleton.playerPosition[0] + 10, playerSingleton.playerPosition[1], playerSingleton.playerPosition[2]);
        missionTaxiSingleton.SetMissionStartTime();
        stopWatch.StartSW();
        
    }

}
