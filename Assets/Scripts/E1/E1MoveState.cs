using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1MoveState : EnemyState
{
    private E1 e1;

    public E1MoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, E1 e1) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.e1 = e1;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 2f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        e1.SetVelocity(2 * e1.facingDir, e1.rb.velocity.y);

        if (e1.IsWallDetected() || !e1.IsGroundDetected())
        {
            e1.Flip();
            stateMachine.ChangeState(e1.idleState);
        }
    }
}
