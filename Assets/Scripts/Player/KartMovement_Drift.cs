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

    [HideInInspector] public UnityEvent<int, bool> EnterDrifEvent = new UnityEvent<int, bool>();
    [HideInInspector] public UnityEvent ExitDrifEvent = new UnityEvent();
    private int driftSide;
    private float offSet, timerDriftDuration;
    private void onDriftEnter()
    {
        rendererr.material.color = Color.yellow;
        timerDriftDuration = 0f;
        EnterDrifEvent.Invoke(driftSide, true);
    }
    private void onDriftUpdate()
    {
        HelpToSlide();
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
        else if(timerDriftDuration > 0.1f && driftSide == 0)
            ChangeState(doNothing);
    }

    private void HelpToSlide()
    {
        timerDriftDuration += Time.deltaTime;
        if (driftSide == 0 && timerDriftDuration < 0.1f)
        {
            driftSide = direction < 0 ? 1 : direction > 0 ? 2 : 0;
            EnterDrifEvent.Invoke(driftSide, false);
        }
    }
}