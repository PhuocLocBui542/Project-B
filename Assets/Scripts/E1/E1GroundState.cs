using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1GroundState : EnemyState
{
    protected E1 e1;

    public E1GroundState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, E1 _e1) : base(_enemy, _stateMachine, _animBoolName)
    {
        e1 = _e1;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (e1.IsPlayerDetected())
            stateMachine.ChangeState(e1.battelState);
    }
}
