using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateText : MonoBehaviour
{
    public static AnimateText Instance;
    public GameObject greenText;
    public GameObject redText;
    public Transform greenTextPos;
    public Transform redTextPos;
    public GameObject currentGreenTextFloating;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    public void Animate(int amount)
    {
        if (amount > 0)
        //animate green
        {
            ShowFloatingTextGreen(amount);
        }
        else
        //animate red
        {
            ShowFloatingTextRed(amount);
        }
    }

    private void ShowFloatingTextGreen( int amount)
    {
        GameObject green = Instantiate(greenText, greenTextPos.position, Quaternion.identity);

        FloatingText floatingText = green.GetComponentInChildren<FloatingText>();
        floatingText.StartCoroutine(floatingText.FloatingAndFading());
        floatingText.ShowText(amount);
    }

    void ShowFloatingTextRed(int amount)
    {
        GameObject red = Instantiate(redText, redTextPos.position, Quaternion.identity);
        FloatingText floatingText = red.GetComponentInChildren<FloatingText>();
        floatingText.StartCoroutine(floatingText.FloatingAndFading());
        floatingText.ShowText(amount);
    }
}
