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
    [SerializeField]
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
            if (home.IsHouseOfPlayer(this.gameObject))
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
        playerCapsule.transform.position = playerCapsule.transform.position - playerCapsule.transform.forward * 3;
        
        GameObject inGameUI = mainUI.transform.Find("InGameUI").gameObject;
        inGameUI.SetActive(true);
    }

    public void TpToHome(){
            home.SetInHome(true);
            home.SetHouse(this.gameObject);
            home.SetPlayerPos(human.transform.Find("PlayerCapsule").gameObject.transform.position - human.transform.Find("PlayerCapsule").gameObject.transform.forward * 3);
            SceneManager.LoadScene("Home");
            GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
            playerCapsule.transform.position = new Vector3(-5.45f, -0.359f, -15.07f);
    }

    public void TpToTown(){
        home.SetInHome(false);
        SceneManager.LoadScene("Fazem");
        GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
        playerCapsule.transform.position = home.GetPlayerPos();
        starterAssetsInputs.StopInput();
    }

    public void BuyHouse(){
        Debug.Log(player.playerMoney);
        if (player.playerMoney >= 80){
            player.RemoveMoney(80);
            player.SetHousePosition(human.transform.Find("PlayerCapsule").gameObject.transform.position);
            this.CloseMenu();
            TpToHome();
        }
        else
        {
            houseUI.transform.Find("MenuHouseNotBought").gameObject.transform.Find("Description").gameObject.SetActive(false);
            houseUI.transform.Find("MenuHouseNotBought").gameObject.transform.Find("NotEnoughMoney").gameObject.SetActive(true);
        }
        
    }

}
