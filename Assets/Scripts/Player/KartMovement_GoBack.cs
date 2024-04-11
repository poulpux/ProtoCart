using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class KartMovement
{
    State goBack = new State();

    private void onGoBackEnter()
    {
        rendererr.material.color = Color.red;
    }
    private void onGoBackUpdate()
    {
        StateChangerGoBack();
        ChangeVelocity(movementType.DECELERATE, maxSpdBack);
    }
    private void onGoBackFixedUpdate()
    {

    }

    private void onGoBackExit()
    {
        
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StateChangerGoBack()
    {
        if (!isDecelerate)
            ChangeState(doNothing);
    }
}