using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    // Start is called before the first frame update
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Diving");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, -10000 * Time.deltaTime, 0, ForceMode.VelocityChange);
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f))
        {
            IPlayerState nextState;
            if (Input.GetKey(KeyCode.S))
            {
                nextState = new DuckingPlayerState();
            }
            else
            {
                nextState = new StandingPlayerState();
            }
            nextState.Enter(player);
        }
    }
}
