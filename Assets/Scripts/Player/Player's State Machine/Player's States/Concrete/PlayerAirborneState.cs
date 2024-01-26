
using UnityEngine;

public class PlayerAirborneState : PlayerState
{
    public PlayerAirborneState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {

    }

    public override void Update()
    {
        //PlayerInfo player = new PlayerInfo();

        if (stateMachine.GetComponent<CharacterController>().isGrounded)
        {
            stateMachine.ChangeState(new PlayerLocomotionState(stateMachine));
        }
        else if (PlayerInfo.instance.currentHealth == 0)
        {
            stateMachine.ChangeState(new PlayerDeathState(stateMachine));

        }
        playerStateMachine.playerMovement.Update();
        playerStateMachine.playerLook.Update();
        playerStateMachine.playerShooting.Update();
    }

    public override void FixedUpdate()
    {
        playerStateMachine.playerMovement.Apply();
        playerStateMachine.playerLook.Apply();
    }

    public override void OnExit()
    {

    }

    public void OnControllerCollisionHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<ZombieInfo>() != null)
        {
            hit.gameObject.GetComponent<ZombieInfo>().TakeDamage(PlayerInfo.instance.jumpDamage);
            AudioManager.instance.PlaySound(AudioManager.Type.PLAYER_KICK, playerStateMachine.GetComponent<AudioSource>(), 1);
        }
    }
}
