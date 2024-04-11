using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPos, player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.position = spawnPos.position;
            player.eulerAngles = Vector3.up * 180f;
        }
    }
}
