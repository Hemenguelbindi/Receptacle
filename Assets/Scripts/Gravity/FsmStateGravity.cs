public abstract class FsmStateGravity
{
    protected readonly FsmGravity FsmGravity;

    public FsmStateGravity(FsmGravity fsmGravity)
    {
        FsmGravity = fsmGravity;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
