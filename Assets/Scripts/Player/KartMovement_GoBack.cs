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
        Decelerate();
        StateChangerGoBack();
    }
    private void onGoBackFixedUpdate()
    {

    }

    private void onGoBackExit()
    {
        
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void Decelerate()
    {
        velocity = velocity - decelerateSpd * Time.deltaTime > maxSpdBack ? velocity - decelerateSpd * Time.deltaTime : maxSpdBack;
    }

    private void StateChangerGoBack()
    {
        if (!isDecelerate)
            ChangeState(doNothing);
    }
}