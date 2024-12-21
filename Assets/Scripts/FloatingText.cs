using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float floatSpeed = 1f;
    public float fadeDuration = 1f;

    private void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
        
    }

    public IEnumerator FloatingAndFading()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            transform.position = startPosition + new Vector3(0, floatSpeed * Time.deltaTime, 0);
            Color color = textMeshPro.color;
            color.a = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            textMeshPro.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject); 
    }

    public void ShowText(int amount)
    {
        textMeshPro.text = amount.ToString();
        gameObject.SetActive(true);
    }
}
