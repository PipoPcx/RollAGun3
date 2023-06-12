using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffects : MonoBehaviour
{
    public Image bloodEffectImage;

    private float r;
    private float g;
    private float b;
    private float a;

    public float alphaDecreaseInterval = 3f;
    public float alphaDecreaseAmount = 0.25f;

    private float timer;

    void Start()
    {
        r = bloodEffectImage.color.r;
        g = bloodEffectImage.color.g;
        b = bloodEffectImage.color.b;
        a = bloodEffectImage.color.a;

        timer = alphaDecreaseInterval;
    }

    void Update()
    {
       
        timer -= Time.deltaTime;

      
        if (timer <= 0f)
        {
            DecreaseAlpha();
            timer = alphaDecreaseInterval;
        }
    }

    public void IncreaseAlpha(float amount)
    {
        a += amount;
        a = Mathf.Clamp01(a);

        ChangeColor();
    }

    private void DecreaseAlpha()
    {
        a -= alphaDecreaseAmount;
        a = Mathf.Clamp01(a);

        ChangeColor();
    }

    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        bloodEffectImage.color = c;
    }
}
