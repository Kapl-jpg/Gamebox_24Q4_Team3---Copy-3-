using System;
using UnityEngine;

public class MouseSensitivity : Patterns.Singleton.Singleton<MouseSensitivity>
{
    [SerializeField] private Vector2 minMaxSens;
    
    private const string SensSaveName = "SensValue";

    private float _sensValue = 0.5f;

    private void Start()
    {
        LoadSensValue();
    }

    public void SetSensValue(float value)
    {
        _sensValue = value;
    }
    
    private void LoadSensValue()
    {
        if (ES3.KeyExists(SensSaveName))
            _sensValue = float.Parse(ES3.Load(SensSaveName).ToString());
    }
    
    public float GetSensValue()
    {
        return Mathf.Lerp(minMaxSens.x,minMaxSens.y,_sensValue);
    }

    public float GetSliderValue()
    {
        return _sensValue;
    }
    
    public void SaveSens()
    {
        ES3.Save(SensSaveName, _sensValue.ToString());
    }

    private void OnApplicationQuit()
    {
        SaveSens();
    }
}
