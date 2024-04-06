using UnityEngine;

public class FsmStateGravityMove : FsmStateGravity
{
    protected readonly CharacterController Controller;
    protected readonly float Gravity;

    public FsmStateGravityMove(FsmGravity fsmGravity, CharacterController controller, float gravity) : base(fsmGravity) =>
        (Controller, Gravity) = (controller, gravity);

    public override void Enter()
    {

    }
    public override void Update()
    {
        Vector3 velocity = Vector3.zero; ;

        velocity.y = Gravity * Time.deltaTime;

        if (GroundChecker.instance.isGrounded)
        {
            velocity.y = 0f;
            FsmGravity.SetState<FsmStateGravityIdle>();
        }
        Debug.Log("GravityState");
        Controller.Move(velocity * Time.deltaTime);
    }

    public override void Exit()
    {

    }

}
