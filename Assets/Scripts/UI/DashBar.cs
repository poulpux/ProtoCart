using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBar : MonoBehaviour
{
    [SerializeField] private KartMovement kartMov;
    [SerializeField] private Transform fillBar;
    private float startScaleX;
    void Start()
    {
        startScaleX = fillBar.localScale.x;
    }

    void Update()
    {
        float fill = kartMov.dashTimer > kartMov.dashCldwn ? 1f : kartMov.dashTimer / kartMov.dashCldwn == 0f ? 0.1f : kartMov.dashTimer / kartMov.dashCldwn;
        fillBar.localScale = new Vector3(startScaleX * fill, fillBar.localScale.y, fillBar.localScale.z);
    }
}
