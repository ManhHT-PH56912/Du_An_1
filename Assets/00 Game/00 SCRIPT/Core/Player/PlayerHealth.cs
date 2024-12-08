using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public partial class PlayerHealth : MonoBehaviour
    {
        protected int _health = 0;
        protected int _maxHealth = 100;

        public Slider hearlthBar;

        private void Start()
        {
            _health = _maxHealth;
            hearlthBar.maxValue = _maxHealth;
            hearlthBar.value = _health;
        }

        public int GetHealthPlayer()
        {
            return _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _health -= amount;
            hearlthBar.value = _health;

            if (_health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}