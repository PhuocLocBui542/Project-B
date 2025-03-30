using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1AttackState : EnemyState
{
    protected E1 e1;
    public E1AttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, E1 e1) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.e1 = e1;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        e1.lasttimeAtk = Time.time;
    }

    public override void Update()
    {
        base.Update();
        e1.ZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(e1.battelState);
    }
}
