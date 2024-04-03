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
        GainSpeed();
        StateChangerAccelerate();
    }
    private void onAccelerateFixedUpdate()
    {

    }

    private void onAccelerateExit()
    {
        
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void GainSpeed()
    {
        velocity = velocity + accelerateSpd * Time.deltaTime < maxSpdFront ? velocity + accelerateSpd * Time.deltaTime : maxSpdFront;
    }
    private void StateChangerAccelerate()
    {
        if (!isAccelerate || isDecelerate)
            ChangeState(doNothing);
    }

}