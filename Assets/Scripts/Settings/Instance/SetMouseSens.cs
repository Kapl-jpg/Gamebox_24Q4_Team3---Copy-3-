using UnityEngine;
using UnityEngine.UI;

public class SetMouseSens : MonoBehaviour
{
    [SerializeField] private Slider mouse;

    private void Start()
    {
        mouse.value = MouseSensitivity.Instance.GetSliderValue();
    }

    public void SaveValue()
    {
        MouseSensitivity.Instance.SaveSens();    
    }

    public void SetSensValue()
    {
        MouseSensitivity.Instance.SetSensValue(mouse.value);
    }
}
