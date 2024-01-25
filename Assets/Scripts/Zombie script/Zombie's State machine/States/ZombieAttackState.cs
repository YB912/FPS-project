
using UnityEngine;

public class ZombieAttackState : ZombieState
{
    private Transform _transform;
    private Transform _playerTransform;
    private Transform _playerFeet;
    public ZombieAttackState(StateMachine stateMachine) : base(stateMachine)
    {
        _transform = stateMachine.transform;
        _playerTransform = zombieStateMachine.playerInfo.transform;
        _playerFeet = GameObject.FindGameObjectWithTag("PlayerFeet").GetComponent<Transform>();
    }

    public override void OnEnter()
    {
        zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Attacking", true);
    }

    public override void Update()
    {
        float distance = Vector3.Distance(_transform.position, _playerFeet.position);
        if ( distance >= zombieStateMachine.zombieInfo.attackDistance)
        {
            stateMachine.ChangeState(new ZombieFollowingState(stateMachine));
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