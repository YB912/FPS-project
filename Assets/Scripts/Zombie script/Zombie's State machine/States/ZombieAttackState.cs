using UnityEngine;

public class ZombieAttackState : ZombieState
{
    private float _attackTimer;

    private Transform _transform;
    private Transform _playerFeet;

    public ZombieAttackState(StateMachine stateMachine) : base(stateMachine)
    {
        _transform = stateMachine.transform;
        _playerFeet = GameObject.FindGameObjectWithTag("PlayerFeet").GetComponent<Transform>();
    }

    public override void OnEnter()
    {
        zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Attacking", true);
        AudioManager.instance.PlaySound(AudioManager.Type.ZOMBIE_ATTACK, zombieStateMachine.GetComponent<AudioSource>(), 1);
        _attackTimer = 0;
    }

    public override void Update()
    {
        float distance = Vector3.Distance(_transform.position, _playerFeet.position);
        if ( distance >= zombieStateMachine.zombieInfo.attackDistance)
        {
            stateMachine.ChangeState(new ZombieFollowingState(stateMachine));
        }

        // Dealing damage once every [attackSpeed] seconds
        _attackTimer += Time.deltaTime;
        if (_attackTimer >= zombieStateMachine.zombieInfo.attackSpeed)
        {
            zombieStateMachine.playerInfo.TakeDamage(zombieStateMachine.zombieInfo.damage);
            _attackTimer = 0;
        }
    }

    public override void FixedUpdate()
    {

    }

    public override void OnExit()
    {
        zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Attacking", false);
    }
}