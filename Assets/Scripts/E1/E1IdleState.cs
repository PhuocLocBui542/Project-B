using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1IdleState : E1GroundState
{
    public E1IdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, E1 e1) : base(_enemy, _stateMachine, _animBoolName, e1)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            stateMachine.ChangeState(e1.moveState);
         
    }
}
