using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Máu tối đa
    private int currentHealth; // Máu hiện tại

    void Start()
    {
        currentHealth = maxHealth; // Đặt máu ban đầu
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UnityEngine.Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        UnityEngine.Debug.Log("Player has died!");
        // Xử lý khi player chết (có thể load lại cảnh hoặc hiển thị màn hình thua)
    }
}
