using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclinaisonKart : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f, multiplyAngle = 20f, distOnAir = 1.8f; 
    [SerializeField] private GameObject P1, P2, P3, P4, P5; //P1 = front, P2 = middle, P3 = foreward, P4 = left, P5 = right
    private bool onAir;
    private float timerOnGround;

    void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, CalculateAngleFrontForeward(), rotationSpeed*(timerOnGround < 0.1f ? 2.5f : 1f) * Time.deltaTime);
    }

    private Quaternion CalculateAngleFrontForeward()
    {
        return Quaternion.Euler(new Vector3(EulerFloat(1,3, true) , 0f, EulerFloat(4, 5, false)));
    }

    private float EulerFloat(int firstP, int secondP, bool x)
    {
        float dist1, dist2, dist3;

        dist1 = RaycastDist(firstP);
        dist2 = RaycastDist(2);
        dist3 = -RaycastDist(secondP);

        float eulerF = dist1 + dist3;

        if (dist2 == 1f)
        {
            timerOnGround = 0f;
            return x ? transform.localEulerAngles.x : transform.localEulerAngles.z;
        }
        timerOnGround += Time.deltaTime;
        return eulerF * multiplyAngle * (x ? 1f : 2f);
    }

    private float RaycastDist(int nb)
    {
        RaycastHit hit;
        GameObject P = nb == 1 ? P1 : nb == 2 ? P2 : nb == 3 ? P3 : nb == 4 ? P4 : P5;
        Physics.Raycast(P.transform.position, Vector3.down, out hit, nb != 2 ? 1f : distOnAir);

        return hit.collider != null ? hit.distance - 0.5f : 1f;
    }
}
