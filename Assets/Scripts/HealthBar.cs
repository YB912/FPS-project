using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider _slider;

    public void SetHealth(float health)
    {
        _slider.value = health;
    }
}
