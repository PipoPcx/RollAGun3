using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int startingLives = 4;
    [SerializeField] private int currentLives;
    public BloodEffects bloodEffects; 

    void Start()
    {
        currentLives = startingLives;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            bloodEffects.IncreaseAlpha(0.25f);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentLives -= damageAmount;
        currentLives = Mathf.Clamp(currentLives, 0, startingLives);

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public int GetLives()
    {
        return currentLives;
    }
}



