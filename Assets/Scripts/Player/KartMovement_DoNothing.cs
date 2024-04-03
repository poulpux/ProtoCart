using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KartMovement
{
    State doNothing = new State();

    private void onDoNothingEnter()
    {
       rendererr.material.color = Color.white;
    }
    private void onDoNothingUpdate()
    {
        LooseSpd();
        StateChangerDoNothing();
    }
    private void onDoNothingFixedUpdate()
    {

    }

    private void onDoNothingExit()
    {
        
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void LooseSpd()
    {
        if (velocity > 0)
            velocity = velocity - looseSpd * Time.deltaTime < 0 ? 0 : velocity - looseSpd * Time.deltaTime;
        else
            velocity = velocity + looseSpd * Time.deltaTime > 0 ? 0 : velocity + looseSpd * Time.deltaTime;
    }
    private void StateChangerDoNothing()
    {
        if (isDecelerate)
            ChangeState(goBack);
        else if (isAccelerate)
            ChangeState(accelerate);
    }
}