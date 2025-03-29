using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1BattelState : EnemyState
{
    private Transform p;
    private E1 e1;
    private int moveDir;
    public E1BattelState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, E1 _e1) : base(_enemy, _stateMachine, _animBoolName)
    {
        e1 = _e1;
    }

    public override void Enter()
    {
        base.Enter();
        p = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (e1.IsPlayerDetected())
        {
            if (e1.IsPlayerDetected().distance < e1.atkDistance)
            {
                Debug.Log("check");
                e1.ZeroVelocity();
                return;
            }
        }

        if (p.position.x > e1.transform.position.x)
            moveDir = 1;
        else if (p.position.x < e1.transform.position.x)
            moveDir = -1;

        e1.SetVelocity(e1.moveSpeed * moveDir, rb.velocity.y);
    }
}
