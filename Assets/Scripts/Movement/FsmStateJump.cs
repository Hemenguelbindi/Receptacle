using UnityEngine;

public class FsmStateJump : FsmStateMovement
{
    public FsmStateJump(Fsm fsm, CharacterController controller, Transform transform, float speed) : base(fsm, controller, transform, speed) { }
}
