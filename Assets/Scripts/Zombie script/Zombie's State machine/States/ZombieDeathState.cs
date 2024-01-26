

using UnityEngine;

public class ZombieDeathState : ZombieState
{
    private float _despawnTimer;

    public ZombieDeathState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {
        Spawner.instance.zombiesAlive--;
        zombieStateMachine.zombieInfo.GetComponent<CapsuleCollider>().enabled = false;
        AudioManager.instance.PlaySound(AudioManager.Type.ZOMBIE_DEATH, GetComponent<AudioSource>(), 1);
        zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Dying", true);
    }

    public override void Update()
    {
        _despawnTimer += Time.deltaTime;
        if (_despawnTimer > zombieStateMachine.zombieInfo.despawnTime)
        {
            stateMachine.ChangeState(new ZombieFollowingState(stateMachine));
            ObjectPoolManager.instance.ReturnToPool(zombieStateMachine.gameObject);
        }
    }

    public override void FixedUpdate()
    {
        
    }

    public override void OnExit()
    {
        zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Dying", false);
        zombieStateMachine.zombieInfo.currentHealth = zombieStateMachine.zombieInfo.maximumHealth;
        zombieStateMachine.zombieInfo.GetComponent<CapsuleCollider>().enabled = true;
        _despawnTimer = 0;
    }
}
