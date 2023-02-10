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
    // Start is called before the first frame update
    public void StartPlayer(){
        string playerName = playerNameInput.text;
        bool correct = CheckPlayerName(playerName);
        if (correct)
        {
            playerSingleton = PlayerSingleton.Instance();
            playerSingleton.SetName(playerName);
            Debug.Log("Player name: " + playerSingleton.playerName);
            HandleJSON();
            SceneManager.LoadScene("Fazem");
            SceneManager.UnloadSceneAsync("ConnexionScene");
        }
        else
        {
            Debug.Log("Player name is incorrect");
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
        string jsonPath = playerSingleton.playerName + ".json";
        if (Resources.Load<TextAsset>(jsonPath) != null)
        {
            // if it exists, load it
            JsonUtility.FromJson<PlayerSingleton>(jsonFile.text);
        }
        else
        {
            // if it doesn't exist, create it
            playerSingleton.SetMoney(0);
            string json = JsonUtility.ToJson(playerSingleton);
            File.WriteAllText(Application.dataPath + "/Resources/" + jsonPath, json);
        }

    }
}
        
     
        
