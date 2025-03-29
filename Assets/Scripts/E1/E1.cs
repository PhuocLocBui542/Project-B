using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1 : Enemy
{
    #region States
    public E1IdleState idleState { get; private set; }
    public E1MoveState moveState { get; private set; }
    public E1BattelState battelState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new E1IdleState(this, stateMachine, "Idle", this);
        moveState = new E1MoveState(this, stateMachine, "Move", this);
        battelState = new E1BattelState(this, stateMachine, "Move", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
