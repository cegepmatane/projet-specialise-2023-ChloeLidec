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

    [Header("Coin UI")]
    public GameObject coinUI;

    [Header("Missions")]
    public StopWatch stopWatch;

    [Header("MissionGB")]
    public Text checkpointText;
    public GameObject[] checkpoints;

    [Header("MissionTaxi")]
    public GameObject taxi;
    public GameObject[] possibleDestinations;
    // Start is called before the first frame update
    void Start()
    {
        playerSingleton = PlayerSingleton.Instance();
        GameObject textCA = coinUI.transform.Find("CoinAmount").gameObject;
        textCA.GetComponent<UnityEngine.UI.Text>().text = playerSingleton.playerMoney.ToString();
        GameObject capsule = human.transform.Find("PlayerCapsule").gameObject;
        capsule.transform.position = new Vector3(playerSingleton.playerPosition[0], playerSingleton.playerPosition[1], playerSingleton.playerPosition[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string missionStarted(){
        if (! missionGBSingleton.stopped){
            return "GB";
        }
        else if (! missionTaxiSingleton.stopped){
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
        taxi.SetActive(true);
        taxi.transform.position = new Vector3(playerSingleton.playerPosition[0] + 10, playerSingleton.playerPosition[1], playerSingleton.playerPosition[2]);
        missionTaxiSingleton.SetMissionStartTime();
        stopWatch.StartSW();
        
    }

}
