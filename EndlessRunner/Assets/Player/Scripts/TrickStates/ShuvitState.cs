using UnityEngine;

namespace Player
{
    public class ShuvitState : TrickState
    {
        public ShuvitState(float stateMinDuration) : base(stateMinDuration)
        {
            // You can add additional initialization code here
        }
        
        public override void Enter(PlayerController playerController)
        {
            base.Enter(playerController);
            playerController.AddToCurrentVelocity(Vector2.up * playerController.model.shuvitJumpForce);

        }
    }
}