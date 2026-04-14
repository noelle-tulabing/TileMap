using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = GameParameters.MaxHealth;
    private int currentHealth = GameParameters.MaxHealth;
    
    public TMP_Text HealthText;
    void Start()
    {
        updateHealth();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        updateHealth();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void updateHealth()
    {
        HealthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
}
