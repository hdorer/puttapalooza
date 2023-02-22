using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerSliderScript : MonoBehaviour
{
    [SerializeField] private Slider powerSlider;
    [SerializeField] private GameObject SliderHolder;
    public void ChangeFill(float change)
    {
        powerSlider.value = change;
    }
    public void EneableSlider()
    {
        
        SliderHolder.SetActive(true);
    }
    public void DisableSlider()
    {
        SliderHolder.SetActive(false);
    }
}
