using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclinaisonKart : MonoBehaviour
{
    public float rotationSpeed = 5f; // Vitesse de rotation
    [SerializeField] private GameObject P1, P2, P3;

    void Update()
    {
        RaycastHit hit1, hit2, hit3;
        float dist1 = 0f, dist2 = 0f, dist3 = 0f;
        Physics.Raycast(P1.transform.position, Vector3.down, out hit1, 1f);
        Physics.Raycast(P2.transform.position, Vector3.down, out hit2, 1f);
        Physics.Raycast(P3.transform.position, Vector3.down, out hit3, 1f);

            if (hit1.collider != null)
                dist1 = hit1.distance-0.5f;
            else dist1 = 1f;
            if (hit2.collider != null)
                dist2 = hit2.distance - 0.5f;
            else
                dist2 = 1f;
            if (hit3.collider != null)
                dist3 = hit3.distance -0.5f ;
            else
                dist3 = 1f;

        print(hit2.distance);
        float eulerX =/* (dist2 + dist1 + dist3)*/ dist1 + dist3 ;

        //if (dist1 > dist2 && dist2 > dist3)
        //    eulerX = 25;

        //if (dist1 < dist2 && dist2 < dist3)
        //    eulerX = 25;

        if (dist2 == 1f)
            eulerX = 0f;
        //if(eulerX < 0f) 
        //    print(eulerX);
        Quaternion angle = Quaternion.Euler(new Vector3(eulerX * 20f , transform.eulerAngles.y, transform.eulerAngles.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, angle, rotationSpeed * Time.deltaTime);
    }
}
