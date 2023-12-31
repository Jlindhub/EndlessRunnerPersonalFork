using UnityEngine.InputSystem;

namespace Player
{
    public class GroundedTransition : Transition
    {
        public GroundedTransition(TrickState from, TrickState to) : base(from, to)
        {
        }
        

        protected override bool CanTransition(PlayerController playerController)
        {
            return playerController.grounded;
        }
    }
}