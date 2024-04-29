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
        ChangeVelocity(movementType.DONOTHING, 0f);
        StateChangerDoNothing();
        TryDrift();
    }
    private void onDoNothingFixedUpdate()
    {

    }

    private void onDoNothingExit()
    {
        
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StateChangerDoNothing()
    {
        if (isDecelerate)
            ChangeState(goBack);
        else if (isAccelerate)
            ChangeState(accelerate);
    }
}