using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageFazem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("ConnexionScene");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
