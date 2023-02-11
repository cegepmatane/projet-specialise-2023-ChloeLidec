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

    public void EnterExitVehicle()
    {
        if (activeVehicle == null)
        {
            EnterVehicle();
        }
        else
        {
            ExitVehicle();
        }
    }

    private void ExitVehicle()
    {
        Debug.Log("ExitVehicle");
        GameObject MainCamera = human.transform.Find("MainCamera").gameObject;
        GameObject playerFollow = human.transform.Find("PlayerFollowCamera").gameObject;
        GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
        MainCamera.SetActive(true);
        playerFollow.SetActive(true);
        playerCapsule.SetActive(true);
        playerCapsule.transform.position = activeVehicle.transform.position + activeVehicle.transform.TransformDirection(Vector3.left * 2);
        
        activeVehicle.GetComponent<PrometeoCarController>().StopCar();
        activeVehicle.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = false;
        activeVehicle.GetComponent<PrometeoCarController>().enabled = false;
        prometeoCarController = null;
        activeVehicle = null;
    }

    private void EnterVehicle()
    {
        Debug.Log("EnterVehicle");
        foreach (GameObject vehicle in vehicles)
        {
            //get the PlayerCapsule of the human
            GameObject playerCapsule = human.transform.Find("PlayerCapsule").gameObject;
            if (Vector3.Distance(vehicle.transform.position, playerCapsule.transform.position) < 2)
            {
                Debug.Log("EnterVehicle: " + vehicle.name);
                activeVehicle = vehicle;
                prometeoCarController = activeVehicle.GetComponent<PrometeoCarController>();
                prometeoCarController.enabled = true;
                activeVehicle.transform.Find("Vehicle Camera").gameObject.GetComponent<Camera>().enabled = true;
                GameObject MainCamera = human.transform.Find("MainCamera").gameObject;
                GameObject playerFollow = human.transform.Find("PlayerFollowCamera").gameObject;
                MainCamera.SetActive(false);
                playerFollow.SetActive(false);
                playerCapsule.SetActive(false);
                Debug.Log("EnterVehicle: " + activeVehicle.name);
                break;
            }
        }
    }

}
