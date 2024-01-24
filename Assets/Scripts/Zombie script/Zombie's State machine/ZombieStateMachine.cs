using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : StateMachine
{
    public ZombieInfo zombieInfo { get; private set; }
    //public PlayerMovementHandler playerMovement { get; private set; }
    //public PlayerLookHandler playerLook { get; private set; }
    private void Start()
    {
        currentState = new ZombieFollowingState(this);
        zombieInfo = GetComponent<ZombieInfo>();
       //playerMovement = new PlayerMovementHandler(this);
        //playerLook = new PlayerLookHandler(this);
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

}
