using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private Image sr;
    public float startValue;
    public float endValue;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<Image>();

        SetFade(1, 0);
    }

    public void SetFade(float start, float end){

        startValue = start;
        endValue = end;
        StartCoroutine("SpriteFade");
    }

    public IEnumerator SpriteFade()
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }
}
