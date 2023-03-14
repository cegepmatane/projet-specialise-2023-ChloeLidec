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

    [Header("Animals")]
    public GameObject animalsContainer;

    // Start is called before the first frame update
    void Start()
    {
        playerSingleton = PlayerSingleton.Instance();
        homeSingleton = HomeSingleton.Instance();
        GameObject capsule = human.transform.Find("PlayerCapsule").gameObject;
        capsule.transform.position = new Vector3(4.83f, -0.74f, 15.26f);

        List<string> animals = playerSingleton.GetAnimals();
        foreach (Transform child in animalsContainer.transform)
        {
            
                if (animals.Contains(child.gameObject.name))
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
