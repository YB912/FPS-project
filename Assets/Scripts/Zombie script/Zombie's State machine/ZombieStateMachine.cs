

using UnityEngine;

public class ZombieStateMachine : StateMachine
{
    public ZombieInfo zombieInfo { get; private set; }
    public PlayerInfo playerInfo { get; private set; }

    private void Start()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        currentState = new ZombieFollowingState(this);
        zombieInfo = GetComponent<ZombieInfo>();
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
