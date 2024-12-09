using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    protected int _health = 0;
    protected int _maxHealth = 50;

    private void Start()
    {
        _health = _maxHealth;
    }

    public int GetHealth()
    {
        return _maxHealth;
    }

    public void TakeDamageEnemy(int amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
