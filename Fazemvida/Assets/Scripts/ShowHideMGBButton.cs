using UnityEngine;

public class ShowHideMGBButton : MonoBehaviour
    {

        [Header("Button")]
        public GameObject missionButton;

        [Header("Objects")]
        public GameObject staringMissionPole;
        public GameObject player;

        public void Start(){
            //hide the button
            missionButton.SetActive(false);
        }
        
        public void Update(){
            //if the player is close to a vehicle
            if (IsPlayerCloseToPole()){
                //show the button
                missionButton.SetActive(true);
            }
            else{
                //hide the button
                missionButton.SetActive(false);
            }
        }

        //check if the player is close to a vehicle
        public bool IsPlayerCloseToPole(){
            GameObject playerCapsule = player.transform.Find("PlayerCapsule").gameObject;
            if (Vector3.Distance(staringMissionPole.transform.position, playerCapsule.transform.position) < 2){
                    //return true
                    return true;
                }
            //return false
            return false;
        }
}


