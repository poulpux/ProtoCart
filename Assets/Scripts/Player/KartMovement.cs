using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody))]
public partial class KartMovement : PlayerInputSystem
{
    [Header("=====SpeedAndControl=====")]
    [Space(10)]
    [SerializeField] private float decelerateSpd;
    [SerializeField] private float accelerateSpd, looseSpdDoNothing, looseSpdDrift,  maxSpdFront, onContactMaxSpd,onPanadeMaxSpd, maxSpdBack, maxDriftSpd, maniability, limitVeloY, deathZone;

    [Header("=====Visu=====")]
    [Space(10)]
    [SerializeField] private MeshRenderer rendererr;

    private Rigidbody rb;
    private float velocity, timerDrift;
    private bool isMuded;

    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        AllTimer();
        SetVelocity();
        Rotate();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void ThrowDash()
    {
        StopCoroutine(Dash());
        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        yield break;
    }

    private void InstantiateAll()
    {
        drift.InitState(onDriftEnter, onDriftUpdate,onDriftFixedUpdate, onDriftExit); 
        accelerate.InitState(onAccelerateEnter, onAccelerateUpdate,onAccelerateFixedUpdate, onAccelerateExit); 
        goBack.InitState(onGoBackEnter, onGoBackUpdate,onGoBackFixedUpdate, onGoBackExit); 
        doNothing.InitState(onDoNothingEnter, onDoNothingUpdate,onDoNothingFixedUpdate, onDoNothingExit); 
        ForcedCurrentState(doNothing);

        rb = GetComponent<Rigidbody>();
    }

    private void ChangeVelocity(float veloModifier, float maxSpd, float looseSpdTemp = 0f)
    {
        looseSpdTemp = looseSpdTemp == 0f ? looseSpdDoNothing : looseSpdTemp;
        if (isMuded)
        {
            maxSpd = onPanadeMaxSpd;
            looseSpdTemp = looseSpdDoNothing;
        }

        if (veloModifier < 0f)
            velocity = velocity + veloModifier * Time.deltaTime > maxSpd ? velocity + veloModifier * Time.deltaTime : velocity + looseSpdTemp * Time.deltaTime;
        else
            velocity = velocity + veloModifier * Time.deltaTime < maxSpd ? velocity + veloModifier * Time.deltaTime : velocity - looseSpdTemp * Time.deltaTime;
    }

    private void SetVelocity()
    {
       //Pour empecher qu'il s'envole
        rb.velocity = new Vector3(0f,rb.velocity.y > limitVeloY ? rb.velocity.y /2f : rb.velocity.y, 0f )+ transform.forward * velocity;
    }

    private void Rotate()
    {
         transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + maniability * Time.deltaTime * direction + offSet * Time.deltaTime, 0f);
    }

    private void AllTimer()
    {
        timerDrift += Time.deltaTime;
    }

    private void TryDrift()
    {
        if (timerDrift > 0.4f  && isDrifting)
            ChangeState(drift);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            velocity = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Default") && velocity > onContactMaxSpd )
            velocity = onContactMaxSpd;
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Out") && velocity > onPanadeMaxSpd)
        {
            rendererr.material.color = new Color(80f / 255f, 33f / 255f, 0f); //brown
            isMuded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Out"))
        {
            ChangeState(doNothing);
            isMuded = false;
        }
    }
}