using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public partial class KartMovement : StateManager
{
    [SerializeField] private float decelerateSpd, accelerateSpd, maxSpd, maniability;

    private Rigidbody rb;
    private float velocity;
    private float direction;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        InstantiateAll();
    }

    protected override void Update()
    {
        base.Update();
        SetVelocity();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void InstantiateAll()
    {
        drift.InitState(onDriftEnter, onDriftUpdate,onDriftFixedUpdate, onDriftExit); 
        accelerate.InitState(onAccelerateEnter, onAccelerateUpdate,onAccelerateFixedUpdate, onAccelerateExit); 
        goBack.InitState(onGoBackEnter, onGoBackUpdate,onGoBackFixedUpdate, onGoBackExit); 
        doNothing.InitState(onDoNothingEnter, onDoNothingUpdate,onDoNothingFixedUpdate, onDoNothingExit); 
        ForcedCurrentState(drift);

        rb = GetComponent<Rigidbody>();
    }

    private void Decelerate()
    {
        velocity -=  decelerateSpd * Time.deltaTime;
    }

    private void SetVelocity()
    {
        rb.velocity = transform.eulerAngles * velocity;
    }

    private void GetDirection()
    {

    }
}