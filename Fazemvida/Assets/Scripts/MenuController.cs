using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuController : MonoBehaviour
{   
    [Header("UI")]
    [SerializeField] private GameObject mainUI = null;
    
    
    [Header("Player")]
    [SerializeField] private GameObject human = null;
    [SerializeField] private PlayerSingleton playerSingleton = PlayerSingleton.Instance();
    private Vector3 playerPosition;

    [Header("Vehicles")]
    [SerializeField] private InOutVehicles inOutVehicles = null;
    private GameObject vehicle = null;



    public void ShowMenu(){
        //save player position and rotation
        playerPosition = human.transform.Find("PlayerCapsule").gameObject.transform.position;
        //deactive the active vehicle if there is one and hide its UI
        
        if (inOutVehicles != null)
        {
            vehicle = inOutVehicles.activeVehicle;
        }
        else
        {
            vehicle = null;
        }
        
        if (vehicle != null)
        {
            //save player positon as next to the vehicle
            playerPosition = vehicle.transform.position + vehicle.transform.TransformDirection(Vector3.left * 2);
            mainUI.transform.Find("VehicleUI").gameObject.SetActive(false);
            vehicle.SetActive(false);
            vehicle.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = false;
            vehicle.GetComponent<PrometeoCarController>().enabled = false;
        }
        //deactive all human UIs and components
        else{
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
        }
        GameObject inGameUI = mainUI.transform.Find("InGameUI").gameObject;
        inGameUI.SetActive(false);
        GameObject menuUI = mainUI.transform.Find("MenuUI").gameObject;
        menuUI.SetActive(true);
    }

    public void HideMenu(){
        if (vehicle != null)
        {
            mainUI.transform.Find("VehicleUI").gameObject.SetActive(true);
            vehicle.SetActive(true);
            vehicle.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = true;
            vehicle.GetComponent<PrometeoCarController>().enabled = true;
        }
        //active all human UIs and components
        else{
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
        }
        GameObject inGameUI = mainUI.transform.Find("InGameUI").gameObject;
        inGameUI.SetActive(true);
        GameObject menuUI = mainUI.transform.Find("MenuUI").gameObject;
        menuUI.SetActive(false);
    }

    public void Save(){
        //save player position and rotation
        playerSingleton.SetPosition(playerPosition);
        string json = JsonUtility.ToJson(playerSingleton);
        //overwrite the file with the new data
        File.WriteAllText(Application.persistentDataPath + "" + playerSingleton.playerName + ".json", json);
    }

}