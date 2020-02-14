using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    // Start is called before the first frame update
    public void Enter(Player player)
    {
        //Debug.Log("Entering State: Jumping");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, 400 * Time.deltaTime, 0, ForceMode.VelocityChange);
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        //Debug.Log("Executing State: Jumping");
        //if (rbPlayer.velocity.y == 0)
        //{
        //    // transition to standing
        //    StandingPlayerState standingState = new StandingPlayerState();
        //    standingState.Enter(player);
        //}

        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DivingPlayerState divingState = new DivingPlayerState();
            divingState.Enter(player);
        }
    }
}
