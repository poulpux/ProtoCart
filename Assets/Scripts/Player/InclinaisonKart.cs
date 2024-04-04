using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclinaisonKart : MonoBehaviour
{
    public float rotationSpeed = 5f, multiplyAngle = 20f; 
    [SerializeField] private GameObject P1, P2, P3, P4, P5; //P1 = front, P2 = middle, P3 = foreward, P4 = left, P5 = right

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, CalculateAngleFrontForeward(), rotationSpeed * Time.deltaTime);
    }

    private Quaternion CalculateAngleFrontForeward()
    {
        return Quaternion.Euler(new Vector3(EulerFloat(1,3) * multiplyAngle, transform.eulerAngles.y, EulerFloat(4, 5) * multiplyAngle));
    }

    private float EulerFloat(int firstP, int secondP)
    {
        float dist1, dist2, dist3;

        dist1 = RaycastDist(firstP);
        dist2 = RaycastDist(2);
        dist3 = -RaycastDist(secondP);

        float eulerF = dist1 + dist3;
        if (dist2 == 1f)
            eulerF = 0f;
        return eulerF;
    }

    private float RaycastDist(int nb)
    {
        RaycastHit hit;
        GameObject P = nb == 1 ? P1 : nb == 2 ? P2 : nb == 3 ? P3 : nb == 4 ? P4 : P5;
        Physics.Raycast(P.transform.position, Vector3.down, out hit, 1f);

        return hit.collider != null ? hit.distance - 0.5f : 1f;
    }
}
