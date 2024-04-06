using UnityEngine;

public class FsmStateGravityIdle : FsmStateGravity 
{
    public FsmStateGravityIdle(FsmGravity fsmGravity) : base(fsmGravity) { }

    public override void Enter() { }
    public override void Exit() { }
    public override void Update()
    {
       if(!GroundChecker.instance.isGrounded)
        {

            FsmGravity.SetState<FsmStateGravityMove>();
        }
    }

}
