using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KartMovement
{
    State accelerate = new State();

    private void onAccelerateEnter()
    {
        rendererr.material.color = Color.cyan;
    }
    private void onAccelerateUpdate()
    {
        ChangeVelocity(movementType.ACCELERATE, maxSpdFront);
        StateChangerAccelerate();
        TryDrift();
    }
    private void onAccelerateFixedUpdate()
    {

    }

    private void onAccelerateExit()
    {
        
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StateChangerAccelerate()
    {
        if (!isAccelerate || isDecelerate)
            ChangeState(doNothing);
    }

}