using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherController : MonoBehaviour
{
    public float RotationSpeed { get; set; }
    public float Temperature { get; set; }

    [Header("Input Settings")]
    [SerializeField] private KeyCode rotateAction = KeyCode.W;
    [SerializeField] private KeyCode temperatureUpAction = KeyCode.D;
    [SerializeField] private KeyCode temperatureDownAction = KeyCode.A;

    [Header("Rotation Settings")]
    [SerializeField] private float minRotationSpeed = 300f;
    [SerializeField] private float maxRotationSpeed = 1600f;
    [SerializeField] private float deltaSpeedUp = 10f;
    [SerializeField] private float deltaSpeedDown = 2f;

    [Header("Temperature Settings")]
    [SerializeField] private float minTemperature = 15f;
    [SerializeField] private float maxTemperature = 60f;
    [SerializeField] private float deltaTemperature = 2f;

    private bool moveToMax = false;

    private float currentTimeRotation = 0;
    private float timeUpdateRotation = 0.2f;

    private void Start()
    {
        RotationSpeed = minRotationSpeed;
        Temperature = minTemperature;
    }

    private void Update()
    {
        InputHandler();
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        currentTimeRotation += Time.deltaTime;
        if (currentTimeRotation >= timeUpdateRotation)
        {
            currentTimeRotation = 0f;
            Rotation();
        }
    }

    private void InputHandler()
    {
        moveToMax = Input.GetKey(rotateAction);

        if (Input.GetKeyDown(temperatureUpAction))
        {
            UpdateTemperature(deltaTemperature);
        }
        else if (Input.GetKeyDown(temperatureDownAction))
        {
            UpdateTemperature(-deltaTemperature);
        }
    }

    private void UpdateTemperature(float delta)
    {
        var newTemperature = Temperature + delta;
        Temperature = Mathf.Clamp(newTemperature, minTemperature, maxTemperature);
    }

    private void Rotation()
    {
        var targetRotation = moveToMax ? maxRotationSpeed : minRotationSpeed;
        var deltaSpeed = moveToMax ? deltaSpeedUp : deltaSpeedDown;
        RotationTo(targetRotation, deltaSpeed);
    }

    private void RotationTo(float targetRotation, float deltaRotation)
    {
        var newRotation = Mathf.Lerp(RotationSpeed, targetRotation, deltaRotation * Time.deltaTime);
        RotationSpeed = Mathf.Clamp(newRotation, minRotationSpeed, maxRotationSpeed);
    }
}
