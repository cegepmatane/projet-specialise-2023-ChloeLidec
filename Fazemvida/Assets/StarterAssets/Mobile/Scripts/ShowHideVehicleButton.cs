using UnityEngine;

public class ShowHideVehicleButton : MonoBehaviour
    {

        [Header("Button")]
        //the input button for entering car
        [SerializeField]
        private GameObject vehicleButton;

        [Header("Scripts")]
        [SerializeField]
        InOutVehicles inOutVehicles;
        [Header("Objects")]
        [SerializeField]
        private GameObject[] vehicles;
        [SerializeField]
        private GameObject player;

        public void Start(){
            //hide the button
            vehicleButton.SetActive(false);
        }
        
        public void Update(){
            //if the player is close to a vehicle
            if (IsPlayerCloseToVehicle()){
                //show the button
                vehicleButton.SetActive(true);
            }
            else{
                //hide the button
                vehicleButton.SetActive(false);
            }
        }

        //check if the player is close to a vehicle
        public bool IsPlayerCloseToVehicle(){
            //loop through all vehicles
            foreach (GameObject vehicle in vehicles){
            //if the player is close to the vehicle
            GameObject playerCapsule = player.transform.Find("PlayerCapsule").gameObject;
            if (Vector3.Distance(vehicle.transform.position, playerCapsule.transform.position) < 2){
                    //return true
                    return true;
                }
            //if the player is in a vehicle
            if (inOutVehicles.activeVehicle != null){
                    //return true
                    return true;
                }
            }
            //return false
            return false;
        }
}


