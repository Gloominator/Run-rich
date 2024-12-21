using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int scoreValue = -20;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
           
            ScoreManager.Instance.UpdateScore(scoreValue);

            // Optionally play a sound or animation here

         // AnimateText.Instance.Animate(scoreValue);
            
            Destroy(gameObject);
        }
    }
}
