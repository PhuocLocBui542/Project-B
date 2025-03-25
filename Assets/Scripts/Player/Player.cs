using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    #region States
    public PlayerStateMachine stateMachine {get ; private set;}
    public PlayerIdleState idleState {get ; private set;}
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }    
    #endregion
    #region Info
    [Header("Move")]
    public float moveSpeed = 12f;
    public float jumpForce = 12f;
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
}
