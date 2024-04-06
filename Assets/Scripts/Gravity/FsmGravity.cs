using System;
using System.Collections.Generic;

public class FsmGravity
{
    private FsmStateGravity StateCurrent { get; set; }

    private Dictionary<Type, FsmStateGravity> _states = new Dictionary<Type, FsmStateGravity>();

    public void AddState(FsmStateGravity state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FsmStateGravity
    {
        var type = typeof(T);

        if (StateCurrent != null && StateCurrent.GetType() == type)
        {
            return;
        }

        if (_states.TryGetValue(type, out var newState))
        {
            StateCurrent?.Exit();

            StateCurrent = newState;

            StateCurrent.Enter();
        }
    }
    public void Update()
    {
        StateCurrent?.Update();
    }
}
