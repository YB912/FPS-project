using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UIElements;
using System;


public class ZombieAttackState : ZombieState
{
    private Vector3 _playerInfo;
    private Vector3 _thisZombie;
    public ZombieAttackState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {

    }

    public override void Update()
    {
        float distance = Vector3.Distance(zombieStateMachine.zombieInfo.transform.position, zombieStateMachine.zombieInfo.player.transform.position);
        if ( distance >= zombieStateMachine.zombieInfo.attackDestance)
        {
            stateMachine.ChangeState(new ZombieFollowingState(stateMachine));
            zombieStateMachine.zombieInfo.zombieAnim.SetBool("Running", true);
            zombieStateMachine.zombieInfo.zombieAnim.SetBool("Attaking", false);


        }
    }

    public override void FixedUpdate()
    {
        //zombieStateMachine.zombieInfo.zombieAnim.SetBool("Running", false);

    }

    public override void OnExit()
    {

    }
}