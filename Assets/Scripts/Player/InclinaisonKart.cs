using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclinaisonKart : MonoBehaviour
{
    public float rotationSpeed = 5f; // Vitesse de rotation
    [SerializeField] private GameObject P1, P2, P3;

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, CalculateAngle(), rotationSpeed * Time.deltaTime);
    }

    private Quaternion CalculateAngle()
    {
        float dist1 = 0f, dist2 = 0f, dist3 = 0f;

        dist1 = RaycastDist(1);
        dist2 = RaycastDist(2);
        dist3 = -RaycastDist(3);

        float eulerX = dist1 + dist3;
        if (dist2 == 1f)
            eulerX = 0f;

        return Quaternion.Euler(new Vector3(eulerX * 20f, transform.eulerAngles.y, transform.eulerAngles.z));
    }

    private float RaycastDist(int nb)
    {
        RaycastHit hit;
        GameObject P = nb == 1 ? P1 : nb == 2 ? P2 : P3;
        Physics.Raycast(P.transform.position, Vector3.down, out hit, 1f);

        return hit.collider != null ? hit.distance - 0.5f : 1f;
    }
}
