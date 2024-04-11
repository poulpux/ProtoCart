using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class KmH : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private KartMovement playerMov;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int roundedValue = Mathf.RoundToInt(playerMov.velocity);
        text.text = Mathf.Abs(roundedValue).ToString() + " km/h";
    }
}
