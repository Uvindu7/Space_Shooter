using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private float health = 100;
    public GameObject Player;
    public GameObject gameOverWindow;
    public AudioSource audioSource;
    public AudioClip gameOver;
    void Start()
    {   
        Time.timeScale = 1;
        healthBar = GetComponent<Image>();
        gameOverWindow.SetActive(false);
       
    }
    public void Damage()
    {
        health -= 20;
        healthBar.fillAmount = health/100;
    }

    private void Update()
    {
        if(health <= 0)
        {
            audioSource.clip = gameOver;
            audioSource.Play();
            
            Time.timeScale = 0;
            Destroy(Player);
            gameOverWindow.SetActive(true);
        }
    }

}
