using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerState
{

    // Start is called before the first frame update
    public void Enter(Player player)
    {
        //Debug.Log("Entering State: Standing");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        //Debug.Log("Executing State: Standing");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // transition to jump
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // transition to duck
            DuckingPlayerState duckingState = new DuckingPlayerState();
            duckingState.Enter(player);
        }
    }
}
