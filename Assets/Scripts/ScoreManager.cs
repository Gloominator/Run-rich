using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; 
    public int currentScore = 20;
    public TextMeshProUGUI textAllScoreUGUI;
    FloatingRichBar floatingRichBar;
   

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

        textAllScoreUGUI.text = currentScore.ToString();
    }

    public void UpdateScore(int amount)
    {
        currentScore += amount;
        if (currentScore < 0)
            //lose
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Debug.Log("Current Score: " + currentScore);
        textAllScoreUGUI.text = currentScore.ToString();
        // Here you can also trigger any UI updates or events related to scoring.
       // FindObjectOfType<FloatingRichBar>().UpdateScore(currentScore, 100f);
    }

   
    
}
