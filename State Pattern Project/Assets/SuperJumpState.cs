using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;
    float launchTime;

    public void Enter(Player player)
    {
        Debug.Log("Entering State: Super Jump");
        rbPlayer = player.GetComponent<Rigidbody>();
        //rbPlayer.AddForce(0, 5000 * Time.deltaTime, 0, ForceMode.VelocityChange);
        rbPlayer.velocity = new Vector3(0, 50, 0);
        launchTime = Time.time;
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f) && (Time.time - launchTime > 0.5f))
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
