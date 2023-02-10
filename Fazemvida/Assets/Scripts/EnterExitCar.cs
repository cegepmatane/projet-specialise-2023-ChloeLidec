using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitCar : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    public GameObject playerCamera;
    public bool inCar = false;

    void Start()
    {
        player = GameObject.Find("Player");
        car = GameObject.Find("Car");
        playerCamera = GameObject.Find("PlayerCamera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inCar == false)
            {
                player.transform.position = car.transform.position;
                player.transform.rotation = car.transform.rotation;
                playerCamera.transform.parent = car.transform;
                playerCamera.transform.localPosition = new Vector3(0, 1.5f, -3);
                playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                inCar = true;
                
            }
            else
            {
                player.transform.position = car.transform.position;
                player.transform.rotation = car.transform.rotation;
                playerCamera.transform.parent = player.transform;
                playerCamera.transform.localPosition = new Vector3(0, 1.5f, 0);
                playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                inCar = false;
            }
        }
    }

}
