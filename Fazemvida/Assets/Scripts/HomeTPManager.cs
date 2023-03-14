using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StarterAssets;

public class HomeTPManager : MonoBehaviour
{
    public HomeSingleton home = HomeSingleton.Instance();
    public PlayerSingleton player = PlayerSingleton.Instance();
    public GameObject houseUI;
    public GameObject mainUI;
    public GameObject human;
    public StarterAssetsInputs starterAssetsInputs;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !home.GetInHome())
        {
            ShowMenu();
        }
        else if (other.gameObject.tag == "Player" && home.GetInHome())
        {
            TpToTown();
        }
    }

    public void ShowMenu()
    {
        starterAssetsInputs.StopInput();
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
        bool hasHome = player.GetHousePosition() != new Vector3(0, 0, 0);
        if (hasHome)
        {
            if (home.IsHouseOfPlayer(playerCapsule.transform.position))
            {
                houseUI.SetActive(true);
                houseUI.transform.Find("MenuHouseBought").gameObject.SetActive(true);
                string title = this.gameObject.name.Replace("_", " ") + " (Your Home)";
                houseUI.transform.Find("MenuHouseBought").gameObject.transform.Find("Title").gameObject.GetComponent<UnityEngine.UI.Text>().text = title;
            }
            else
            {
                houseUI.SetActive(true);
                houseUI.transform.Find("MenuOtherHouseBought").gameObject.SetActive(true);
                string title = this.gameObject.name.Replace("_", " ");
                houseUI.transform.Find("MenuOtherHouseBought").gameObject.transform.Find("Title").gameObject.GetComponent<UnityEngine.UI.Text>().text = title;
            }
        }
        else
        {
            houseUI.SetActive(true);
            houseUI.transform.Find("MenuHouseNotBought").gameObject.SetActive(true);
            string title = this.gameObject.name.Replace("_", " ");
            houseUI.transform.Find("MenuHouseNotBought").gameObject.transform.Find("Title").gameObject.GetComponent<UnityEngine.UI.Text>().text = title;
        }
    }

    public void CloseMenu()
    {
        starterAssetsInputs.StopInput();
        houseUI.transform.Find("MenuHouseNotBought").gameObject.transform.Find("Description").gameObject.SetActive(true);
        houseUI.transform.Find("MenuHouseNotBought").gameObject.transform.Find("NotEnoughMoney").gameObject.SetActive(false);
        houseUI.SetActive(false);
        houseUI.transform.Find("MenuHouseBought").gameObject.SetActive(false);
        houseUI.transform.Find("MenuOtherHouseBought").gameObject.SetActive(false);
        houseUI.transform.Find("MenuHouseNotBought").gameObject.SetActive(false);
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
        playerCapsule.transform.position = playerCapsule.transform.position - playerCapsule.transform.forward * 2;
        
        GameObject inGameUI = mainUI.transform.Find("InGameUI").gameObject;
        inGameUI.SetActive(true);
    }

    public void TpToHome(){
            home.SetInHome(true);
            GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
            home.SetHouse(playerCapsule.transform.position);
            home.SetPlayerPos(playerCapsule.transform.position);
            SceneManager.LoadScene("Home");
    }

    public void TpToTown(){
        home.SetInHome(false);
        SceneManager.LoadScene("Fazem");
        GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
        playerCapsule.transform.position = home.GetPlayerPos();
        starterAssetsInputs.StopInput();
    }

    public void BuyHouse(){
        bool hasHome = player.GetHousePosition() != new Vector3(0, 0, 0);
        if (!hasHome && player.playerMoney >= 1000){
            player.RemoveMoney(1000);
            GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
            player.SetHousePosition(playerCapsule.transform.position);
            TpToHome();
        }
        else if(hasHome)
        {
            GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
            player.SetHousePosition(playerCapsule.transform.position);
            TpToHome();
        }
        else
        {
            houseUI.transform.Find("MenuHouseNotBought").gameObject.transform.Find("Description").gameObject.SetActive(false);
            houseUI.transform.Find("MenuHouseNotBought").gameObject.transform.Find("NotEnoughMoney").gameObject.SetActive(true);
        }
       
        
    }

}
