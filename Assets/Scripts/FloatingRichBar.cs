using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingRichBar : MonoBehaviour
{
  
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0.4f; // Set initial health value (full)
    }

    private void Update()
    {
      
    }

    public void UpdateScore(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth; // Update slider value based on health
    }
}
