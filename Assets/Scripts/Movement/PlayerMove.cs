using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private Fsm _fsm;

    private CharacterController _controller;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private void Start()
    {
        _fsm = new Fsm();
        _controller = GetComponent<CharacterController>();

        _fsm.AddState(new FsmStateIdle(_fsm));
        _fsm.AddState(new FsmStateWalk(_fsm, _controller, transform, _walkSpeed));
        _fsm.AddState(new FsmStateRun(_fsm, _controller, transform, _runSpeed));

        _fsm.SetState<FsmStateIdle>();
    }

    private void Update()
    {
        _fsm.Update();
    }
}
