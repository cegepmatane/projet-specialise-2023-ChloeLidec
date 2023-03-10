using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeTPManager : MonoBehaviour
{
    public HomeSingleton home = HomeSingleton.Instance();
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !home.GetInHome())
        {
            home.SetInHome(true);
            home.SetHouse(this.gameObject);
            home.SetPlayerPos(GameObject.FindGameObjectWithTag("Player").transform.position);
            SceneManager.LoadScene("Home");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(-5.45f, -0.359f, -15.07f);
        }
        else
        {
            home.SetInHome(false);
            SceneManager.LoadScene("Fazem");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = home.GetPlayerPos();
        }
    }
}
