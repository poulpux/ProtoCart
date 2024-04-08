using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class KartMovement
{
    State drift = new State();
    [Header("=====Drift=====")]
    [Space(10)]
    [SerializeField] private float neccessarySpd;
    [SerializeField] private float driftSensi = 0.1f;

    [HideInInspector] public UnityEvent<int> EnterDrifEvent = new UnityEvent<int>();
    [HideInInspector] public UnityEvent ExitDrifEvent = new UnityEvent();
    private int driftSide;
    private float offSet;
    private void onDriftEnter()
    {
        rendererr.material.color = Color.yellow;
        if (direction == 0)
            ChangeState(doNothing);
        else
            driftSide = direction < 0 ? 1 : direction > 0 ? 2 : 0;
        EnterDrifEvent.Invoke(driftSide);
    }
    private void onDriftUpdate()
    {
        SetOffSetDirection();
        StateChangerDrift();
        DriftSpd();
    }
    private void onDriftFixedUpdate()
    {
        
    }

    private void onDriftExit()
    {
        offSet = 0f;
        timerDrift = 0;
        driftSide = 0;
        ExitDrifEvent.Invoke();    
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void SetOffSetDirection()
    {
        //Pour le feeling du drift, diviser par deux la sensi quand il tourne du même côté que le drift
        offSet = (driftSide == 1 && direction < 0) ? -driftSensi / 2f :
                 (driftSide == 1 && direction >= 0) ? -driftSensi :
                 (driftSide == 2 && direction > 0) ? driftSensi / 2f :
                 (driftSide == 2 && direction <= 0) ? driftSensi : 0f;
    }

    private void DriftSpd()
    {
        if (isAccelerate)
            ChangeVelocity(accelerateSpd, maxDriftSpd, looseSpdDrift);
        else
            LooseSpd();
    }

    private void StateChangerDrift()
    {
        if (velocity < neccessarySpd || !isDrifting)
            ChangeState(doNothing);
    }
}