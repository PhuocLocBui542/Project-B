using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1BattelState : EnemyState
{
    private Transform p;
    private E1 e1;
    private int moveDir;

    float minDistanceToFlip = 0.1f;
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

        if (e1.IsPlayerDetected() && e1.IsPlayerDetected().distance < e1.atkDistance)
        {
            stateTimer = e1.battleTime;

            if (CanAttack())
            {
                stateMachine.ChangeState(e1.attackState);
            }
            return;
        }
        else
        {
            if (stateTimer < 0 && !e1.IsPlayerDetected())
                stateMachine.ChangeState(e1.idleState);
        }

        flipController();

        e1.SetVelocity(e1.moveSpeed * moveDir, rb.velocity.y);
    }

    private bool CanAttack()
    {
        if (Time.time >= e1.lasttimeAtk + e1.atkCD)
        {
            e1.lasttimeAtk = Time.time;
            return true;
        }

        return false;
    }

    private void flipController()
    {
        if (Mathf.Abs(p.position.x - e1.transform.position.x) > minDistanceToFlip)
        {
            if (p.position.x > e1.transform.position.x)
                moveDir = 1;
            else
                moveDir = -1;
        }
        else
        {
            moveDir = 0;
            if (CanAttack())
                stateMachine.ChangeState(e1.attackState);
        }
    }
}