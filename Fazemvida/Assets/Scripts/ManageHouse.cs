using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageHouse : MonoBehaviour
{
    PlayerSingleton playerSingleton;
    HomeSingleton homeSingleton;
    
    [Header("Human")]
    public GameObject human;

    [Header("UI")]
    public GameObject mainUI;

    // Start is called before the first frame update
    void Start()
    {
        playerSingleton = PlayerSingleton.Instance();
        homeSingleton = HomeSingleton.Instance();
        GameObject capsule = human.transform.Find("PlayerCapsule").gameObject;
        capsule.transform.position = new Vector3(4.83f, -0.74f, 15.26f);
    
    }

    // Update is called once per frame
    void Update()
    {
    }

}
