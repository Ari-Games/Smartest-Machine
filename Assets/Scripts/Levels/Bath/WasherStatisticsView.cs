using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WasherStatisticsView : MonoBehaviour
{
    [SerializeField] private WasherController washer;
    [SerializeField] private Text rotationView;
    [SerializeField] private Text temperatureView;

    private void Update()
    {
        rotationView.text = string.Format("{0:0}", washer.RotationSpeed);
        temperatureView.text = string.Format("{0:0}", washer.Temperature);
    }
}
