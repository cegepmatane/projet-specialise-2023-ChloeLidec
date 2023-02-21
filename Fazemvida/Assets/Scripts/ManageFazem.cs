using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageFazem : MonoBehaviour
{
    PlayerSingleton playerSingleton;
    MissionGBSingleton missionGBSingleton;
    
    [Header("Human")]
    public GameObject human;

    [Header("Coin UI")]
    public GameObject coinUI;

    [Header("MissionGB")]
    public StopWatch stopWatch;
    public Text checkpointText;
    public GameObject[] checkpoints;
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

}
