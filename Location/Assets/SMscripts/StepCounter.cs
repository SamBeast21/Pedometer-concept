using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StepCounter : MonoBehaviour
{
    public Text StepsText;
    public Text DistanceText;
    // Singleton setup
    private static StepCounter _instance;
    public static StepCounter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StepCounter>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("StepCounter");
                    _instance = container.AddComponent<StepCounter>();
                }
            }
            return _instance;
        }
    }

    [Header("Configuration")]
    public StepCounterConfig config;
    [Header("Runtime Variables")]
    [SerializeField] private float distanceWalked = 0f;
    [SerializeField] private int stepCount = 0;
    private Vector3 acceleration;
    private Vector3 prevAcceleration;
    private void Start()
    {
        if (config == null)
        {
            Debug.LogError("wUH Oh oh no: StepCounterConfig is missing!");
            return;
        }
        prevAcceleration = Input.acceleration;
        StepDataHandler.Instance.CheckForNewDay();
    }
    private void Update()
    {
        if (config == null) return;
        DetectSteps();
        CalculateDistance();
        StepDataHandler.Instance.SaveDailySteps(stepCount);
        try
        {
            StepsText.text = stepCount.ToString();
            DistanceText.text = distanceWalked.ToString();
        }
        catch
        {

        }
    }
    private void DetectSteps()
    {
        acceleration = Input.acceleration;
        float delta = (acceleration - prevAcceleration).magnitude;
        if (delta > config.threshold)
        {
            stepCount++;
            Debug.Log($"Step detected! Count: {stepCount}");
        }
        prevAcceleration = acceleration;
    }
    private void CalculateDistance()
    {
        distanceWalked = stepCount * config.stepLength;
    }
    public void CalibrateStepLength(float newStepLength)
    {
        if (newStepLength > 0)
        {
            config.stepLength = newStepLength;
            Debug.Log($"Step Length calibrated to: {config.stepLength} meters");
        }
        else
        {
            Debug.LogWarning("Whoops! That's not a VALID STEP LENGTH.");
        }
    }
    // Getter methods and data management
    public float GetDistanceWalked() => distanceWalked;
    public int GetStepCount() => stepCount;
    public void ResetStepData()
    {
        stepCount = 0;
        distanceWalked = 0f;
    }
    public void LoadStepData(int loadedStepCount)
    {
        stepCount = loadedStepCount;
        CalculateDistance();
    }
}