using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;
    protected Rigidbody2D rb;

    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemy.rb;
        enemy.anim.SetBool(animBoolName, true);

    }

    public virtual void Exit() {
        enemy.anim.SetBool(animBoolName, false);

    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
