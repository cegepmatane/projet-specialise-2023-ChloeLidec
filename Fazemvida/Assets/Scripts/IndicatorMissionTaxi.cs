using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class IndicatorMissionTaxi : MonoBehaviour
{
    [SerializeField]
    GameObject indicator;
    [SerializeField]
    GameObject taxi;
    MissionTaxiSingleton missionTaxi = MissionTaxiSingleton.Instance();
    private GameObject destination;

    void Start()
    {
        destination = missionTaxi.destination;
    }

    void Update()
    {
        if (destination != null)
        {
            Vector3 destinationPos = destination.transform.position;
            Vector3 taxiPos = taxi.transform.position;
            Vector3 direction = destinationPos - taxiPos;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            indicator.transform.rotation = Quaternion.Slerp(indicator.transform.rotation, rotation, 1);
        }

    }
}
