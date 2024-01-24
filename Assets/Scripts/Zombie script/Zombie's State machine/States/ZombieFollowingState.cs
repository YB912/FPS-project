using UnityEngine;

public class ZombieFollowingState : ZombieState
{
    private Vector3 _playerInfo;
    private Vector3 _thisZombie;
    public ZombieFollowingState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {

    }

    public override void Update()
    {
        float distance = Vector3.Distance(zombieStateMachine.zombieInfo.transform.position, zombieStateMachine.zombieInfo.player.transform.position);
        if (distance < zombieStateMachine.zombieInfo.attackDestance)
        {
            stateMachine.ChangeState(new ZombieAttackState(stateMachine));
            zombieStateMachine.zombieInfo.zombieAnim.SetBool("Attaking", true);

        }
        _playerInfo = zombieStateMachine.zombieInfo.player.transform.position;
        _thisZombie = zombieStateMachine.zombieInfo.transform.position;

    }

    public override void FixedUpdate()
    {
        Vector3 targetPosition = Vector3.MoveTowards(_thisZombie, _playerInfo, zombieStateMachine.zombieInfo.zombieSpeed * Time.deltaTime);
        targetPosition.y = 0;

        zombieStateMachine.zombieInfo.transform.position = targetPosition;

        zombieStateMachine.zombieInfo.LookAt(zombieStateMachine.zombieInfo.player.transform.position);



    }

    public override void OnExit()
    {

    }
}
