using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InOutVehicles : MonoBehaviour
{   
    [Header("Human")]
    [SerializeField] private GameObject human = null;

    [Header("Vehicles")]
    [SerializeField] private GameObject[] vehicles = null;

    [Header("Active Vehicle")]
    [SerializeField] private GameObject activeVehicle = null;
    [SerializeField] private PrometeoCarController prometeoCarController = null;

    [Header("Input Key")]
    [SerializeField] private KeyCode enterExitKey = KeyCode.E;
    // Start is called before the first frame update
    void Start()
    {
        human.transform.Find("First Person Camera").gameObject.GetComponent<Camera>().enabled = true;
        //for each vehicle, disable the car controller
        foreach (GameObject vehicle in vehicles)
        {
            vehicle.GetComponent<PrometeoCarController>().enabled = false;
            vehicle.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(enterExitKey))
        {
            if (activeVehicle == null)
            {
                foreach (GameObject vehicle in vehicles)
                {
                    if (Vector3.Distance(human.transform.position, vehicle.transform.position) < 2)
                    {
                        activeVehicle = vehicle;
                        prometeoCarController = activeVehicle.GetComponent<PrometeoCarController>();
                        prometeoCarController.enabled = true;
                        activeVehicle.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = true;
                        human.SetActive(false);
                        break;
                    }
                }
            }
            else
            {
                GetOutofVehicle();
                activeVehicle = null;
            }
        }
    }

    void GetOutofVehicle()
    {
        human.SetActive(true);
        human.transform.position = activeVehicle.transform.position + activeVehicle.transform.TransformDirection(Vector3.left);
        
        activeVehicle.GetComponent<PrometeoCarController>().StopCar();
        activeVehicle.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = false;
        activeVehicle.GetComponent<PrometeoCarController>().enabled = false;
        prometeoCarController = null;
        }
}
