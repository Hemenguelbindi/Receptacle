using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class HeroMove : MonoBehaviour
{
    private Fsm _fsm;
    private FsmGravity _fsmGravity;

    private CharacterController _controller;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _gravity;

    private void Start()
    {
        InitializedMovement();
        InitializedGravity();
    }

    private void InitializedMovement()
    {
        _fsm = new Fsm();

        _controller = GetComponent<CharacterController>();

        _fsm.AddState(new FsmStateIdle(_fsm));
        _fsm.AddState(new FsmStateWalk(_fsm, _controller, transform, _walkSpeed));
        _fsm.AddState(new FsmStateRun(_fsm, _controller, transform, _runSpeed));

        _fsm.SetState<FsmStateIdle>();
    }

    private void InitializedGravity()
    {
        _fsmGravity = new FsmGravity();

        _fsmGravity.AddState(new FsmStateGravityIdle(_fsmGravity));
        _fsmGravity.AddState(new FsmStateGravityMove(_fsmGravity, _controller, _gravity));
        _fsmGravity.SetState<FsmStateGravityIdle>();
    }
    private void Update()
    {
        _fsm.Update();
        _fsmGravity.Update();
    }

}
