using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSliderScript : MonoBehaviour {
    [SerializeField] private Slider powerSlider;
    
    public void ChangeFill(float change) {
        powerSlider.value = change;
    }
}
