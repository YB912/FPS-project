

using UnityEngine;

public class ZombieStateMachine : StateMachine
{
    private float _randomNoiseTimer;

    public ZombieInfo zombieInfo { get; private set; }
    public PlayerInfo playerInfo { get; private set; }

    private void Start()
    {
        _randomNoiseTimer = Random.Range(10, 30);

        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        currentState = new ZombieFollowingState(this);
        zombieInfo = GetComponent<ZombieInfo>();
    }

    private void Update()
    {
        currentState.Update();

        _randomNoiseTimer -= Time.deltaTime;
        if ( _randomNoiseTimer < 0 )
        {
            AudioManager.instance.PlaySound(AudioManager.Type.ZOMBIE_RANDOM, GetComponent<AudioSource>(), 1);
            _randomNoiseTimer = Random.Range(10, 30);
        }
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

}
