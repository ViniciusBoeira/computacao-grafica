using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public Healthbar healthbar;
    public GameObject gameOverPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
        if (gameOverPanel != null) 
            gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            if (gameOverPanel != null) {
                gameOverPanel.SetActive(true);
            }
            Time.timeScale = 0f;
        }
    }
}
