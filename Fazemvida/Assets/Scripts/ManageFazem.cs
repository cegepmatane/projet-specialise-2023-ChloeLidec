using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageFazem : MonoBehaviour
{
    PlayerSingleton playerSingleton;
    MissionGBSingleton missionGBSingleton;
    

    [Header("Coin UI")]
    public GameObject coinUI;

    [Header("Stopwatch")]
    public StopWatch stopWatch;
    // Start is called before the first frame update
    void Start()
    {
        playerSingleton = PlayerSingleton.Instance();
        GameObject textCA = coinUI.transform.Find("CoinAmount").gameObject;
        textCA.GetComponent<UnityEngine.UI.Text>().text = playerSingleton.playerMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //update coin ammount
        GameObject textCA = coinUI.transform.Find("CoinAmount").gameObject;
        textCA.GetComponent<UnityEngine.UI.Text>().text = playerSingleton.playerMoney.ToString();
    }

    public void StartMissionGB()
    {
        missionGBSingleton = MissionGBSingleton.Instance();
        missionGBSingleton.SetMissionStartTime();
        stopWatch.StartSW();
    }

}
