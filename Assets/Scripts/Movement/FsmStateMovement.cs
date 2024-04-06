using UnityEngine;

public class FsmStateMovement : FsmState
{
    protected readonly CharacterController Controller;
    protected readonly Transform Transform;
    protected readonly float Speed;

    public FsmStateMovement(Fsm fsm, CharacterController controller, Transform transform, float speed) : base(fsm)
    {
        Controller = controller;
        Transform = transform;
        Speed = speed;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
        {
            Fsm.SetState<FsmStateIdle>();
        }

        Move(inputDirection);
    }

    protected Vector2 ReadInput()
    {
        var inputHorizontal = Input.GetAxis("Horizontal");
        var inputVertical = Input.GetAxis("Vertical");
        var inputDirection = new Vector2(inputHorizontal, inputVertical).normalized;

        return inputDirection;
    }

    protected virtual void Move(Vector2 inputDirection)
    {
        Controller.Move((inputDirection.y * Transform.forward + inputDirection.x * Transform.right) * Speed * Time.deltaTime);
    }

}
