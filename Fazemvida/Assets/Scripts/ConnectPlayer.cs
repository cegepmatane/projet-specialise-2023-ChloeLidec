using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ConnectPlayer : MonoBehaviour
{   
    private PlayerSingleton playerSingleton;
    private TextAsset jsonFile;
    [SerializeField]
    public InputField playerNameInput;
    public Text textInfo;
    // Start is called before the first frame update
    public void StartPlayer(){
        string playerName = playerNameInput.text;
        bool correct = CheckPlayerName(playerName);
        if (correct)
        {
            playerSingleton = PlayerSingleton.Instance();
            playerSingleton.SetName(playerName);
            HandleJSON();
            SceneManager.LoadScene("Fazem");
        }
        else
        {
            textInfo.text = "Invalid username, please try again. Only letters, numbers, underscores and dashes are allowed.";
            playerNameInput.text = "Enter username...";
        }
    }

    private bool CheckPlayerName(string playerName)
    {
        //check that the player name is not empty, that it doesn't contain any special characters, and that it doesn't contain any spaces
        string acceptedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
        if (playerName.Length == 0)
        {
            return false;
        }
        foreach (char c in playerName)
        {
            if (!acceptedCharacters.Contains(c.ToString()))
            {
                return false;
            }
        }
        return true;
    }
    private void HandleJSON()
    {
        // look for a file called "[playername].json" in the Resources folder
        bool fileExists = File.Exists(Application.dataPath + "/Resources/" + playerSingleton.playerName + ".json");
        if (fileExists)
        {
            jsonFile = Resources.Load<TextAsset>(playerSingleton.playerName);
            // if it exists, load it
            //get the money from the json file
            Player player = JsonUtility.FromJson<Player>(jsonFile.text);
            int money = player.GetMoney();
            playerSingleton.SetMoney(money);
            //if the player has no position, set it to the default position
            if (player.GetPosition() == Vector3.zero)
            {
                playerSingleton.SetPosition(new Vector3(566.11f, 60.114f, 7.25f));
            }
            else
            {
                playerSingleton.SetPosition(player.GetPosition());
            }
            Debug.Log(playerSingleton.playerPosition);
        }
        else
        {
            // if it doesn't exist, create it
            playerSingleton.SetMoney(0);
            playerSingleton.SetPosition(new Vector3(566.11f, 60.114f, 7.25f));
            string json = JsonUtility.ToJson(playerSingleton);
            File.WriteAllText(Application.dataPath + "/Resources/" + playerSingleton.playerName+ ".json", json);
        }

    }
}
        
     
        
