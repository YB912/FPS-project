using UnityEngine;

public class ZombieFollowingState : ZombieState
{
    private Transform _transform;
    private Transform _playerTransform;
    private Transform _playerFeet;

    public ZombieFollowingState(StateMachine stateMachine) : base(stateMachine)
    {
        _transform = stateMachine.transform;
        _playerTransform = zombieStateMachine.playerInfo.transform;
        _playerFeet = GameObject.FindGameObjectWithTag("PlayerFeet").GetComponent<Transform>();
    }

    public override void OnEnter()
    {
        zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Running", true);
    }

    public override void Update()
    {
        float distance = Vector3.Distance(_transform.position, _playerFeet.position);
        if (distance < zombieStateMachine.zombieInfo.attackDistance)
        {
            zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Attacking", true);
            stateMachine.ChangeState(new ZombieAttackState(stateMachine));
        }
    }

    public override void FixedUpdate()
    {
        Vector3 targetPosition = Vector3.MoveTowards(_transform.position, _playerTransform.position, zombieStateMachine.zombieInfo.zombieSpeed * Time.deltaTime);
        targetPosition.y = 0;

        zombieStateMachine.zombieInfo.transform.position = targetPosition;

        // Fixes zombie tilting when player jumps
        zombieStateMachine.zombieInfo.LookAt(new Vector3(_playerTransform.position.x, _transform.position.y, _playerTransform.position.z));
    }

    public override void OnExit()
    {
        zombieStateMachine.zombieInfo.GetComponent<Animator>().SetBool("Running", false);
    }
}
