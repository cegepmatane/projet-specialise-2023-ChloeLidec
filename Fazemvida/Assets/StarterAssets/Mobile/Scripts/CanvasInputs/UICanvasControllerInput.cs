using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;
        public InOutVehicles inOutVehicles;
        public MenuController menuController;
        public PrometeoCarController prometeoCarController;
        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }
        public void VirtualEnterExitVehicleInput()
        {
            starterAssetsInputs.StopInput();
            inOutVehicles.EnterExitVehicle();
        }

        public void VirtualShowMenuInput()
        {
            starterAssetsInputs.StopInput();
            prometeoCarController.StopCar();
            menuController.ShowMenu();
        }

        public void VirtualHideMenuInput()
        {
            menuController.HideMenu();
        }

        public void VirtualSaveInput()
        {
            menuController.Save();
        }
    }

}
