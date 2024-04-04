using UnityEngine;

public class FsmStateRun : FsmStateMovement
{
    public FsmStateRun(Fsm fsm, CharacterController controller, Transform transform, float speed) : base(fsm, controller, transform, speed) { }

    public override void Update()
    {
        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
        {
            Fsm.SetState<FsmStateIdle>();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Fsm.SetState<FsmStateWalk>();
        }

        Move(inputDirection);
    }
}
