using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour {
    public Slider volSlider;

    public void OnValueChanged()
    {
        AudioListener.volume = volSlider.value;
    }
}
