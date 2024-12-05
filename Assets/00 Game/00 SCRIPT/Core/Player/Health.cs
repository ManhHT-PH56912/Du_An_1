using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    protected int _health = 0;
    protected int _maxHealth = 100;
    public Slider slider;

    private void Start()
    {
        _health = _maxHealth;
        slider.maxValue = _maxHealth;
        slider.value = _health;
    }

    public void TakeDame(int amount)
    {
        _health -= amount;
        slider.value = _health;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
