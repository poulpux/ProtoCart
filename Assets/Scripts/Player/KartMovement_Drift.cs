using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class KartMovement
{
    State drift = new State();
    [Header("=====SpeedAndControl=====")]
    [Space(10)]
    [SerializeField] private float neccessarySpd;

    [HideInInspector] private UnityEvent EnterDrifEvent = new UnityEvent();
    [HideInInspector] private UnityEvent ExitDrifEvent = new UnityEvent();
    private int driftSide;
    private void onDriftEnter()
    {
        EnterDrifEvent.Invoke();
        rendererr.material.color = Color.yellow;
        if (direction == 0)
            ChangeState(doNothing);
        else
            driftSide = direction < 0 ? 1 : direction > 0 ? 2 : 0;
    }
    private void onDriftUpdate()
    {
        //if (driftSide == 1)
        //    direction -= 0.4f;
        //else if(driftSide == 2)
        //    direction += 0.4f;

        print(direction);

        StateChangerDrift();
        DriftSpd();
    }
    private void onDriftFixedUpdate()
    {

    }

    private void onDriftExit()
    {
        timerDrift = 0;
        ExitDrifEvent.Invoke();    
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void DriftSpd()
    {
        if (isAccelerate)
            ChangeVelocity(accelerateSpd, maxSpdFront);
        else
            LooseSpd();
    }

    private void StateChangerDrift()
    {
        if (velocity < neccessarySpd || !isDrifting || velocity < neccessarySpd)
            ChangeState(doNothing);
    }

    private void ChangeRotation()
    {

    }
}