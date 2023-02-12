using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noCarController : MonoBehaviour
{
    public GameObject[] vehicles;
    public InOutVehicles inOutVehicles;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vehicle")
        {
            inOutVehicles.EnterExitVehicle();
        }
    }
}
