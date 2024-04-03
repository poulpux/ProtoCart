using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KartMovement
{
    State drift = new State();
    [Header("=====SpeedAndControl=====")]
    [Space(10)]
    [SerializeField] private float neccessarySpd;

    private bool driftLeft;
    private void onDriftEnter()
    {
        rendererr.material.color = Color.yellow;
        if (direction == 0)
            ChangeState(doNothing);
        else
            driftLeft = direction < 0 ? true : false;
    }
    private void onDriftUpdate()
    {
        StateChangerDrift();
    }
    private void onDriftFixedUpdate()
    {

    }

    private void onDriftExit()
    {
        timerDrift = 0;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StateChangerDrift()
    {
        if (velocity < neccessarySpd || !isDrifting)
            ChangeState(doNothing);
    }
}