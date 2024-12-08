using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    protected int _health = 0;
    protected int _maxHealth = 100;

    public Slider healthEnemy;

    private void Start()
    {
        _health = _maxHealth;
        healthEnemy.maxValue = _maxHealth;
        healthEnemy.value = _health;
    }

    public int GetHealth()
    {
        return _maxHealth;
    }

    public void TakeDamageEnemy(int amount)
    {
        _health -= amount;
        healthEnemy.value = _health;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
