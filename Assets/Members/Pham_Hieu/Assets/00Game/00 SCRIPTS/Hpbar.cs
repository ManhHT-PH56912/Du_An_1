using UnityEngine;
using UnityEngine.UI;

public class Hpbar
{
    public Image healthBar;
    public float healthAmount = 100f;

    [System.Obsolete]

    private void Update()
    {
        if (healthAmount <= 0) 
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Heal(5);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal(float healAmount)
    {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}

