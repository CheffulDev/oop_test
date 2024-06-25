using System;
using UnityEngine;

namespace Game.HealthSystem
{
    public class Health : IDamageable
    {
        private float health;
        private bool isInvincible = false;

        private bool isHealthZero;

        private float currentHealth;

        public float CurrentHealth
        {
            get { return currentHealth; }

            protected set
            {
                if (isHealthZero | isInvincible) return;

                currentHealth = Mathf.Abs(value);

                if (currentHealth > health)
                {
                    currentHealth = health;
                }

                OnHealthChanged?.Invoke();

                CheckForDeath();

            }
        }

        public event Action OnHealthIsZero;
        public event Action OnDamageReceived;
        public event Action OnHealthChanged;
        public event Action OnInvicibleChanged;

        public float MaxHealth
        {
            get { return health; }
            private set { health = Mathf.Abs(value); }
        }

        public bool IsHealthZero() => isHealthZero;

        public bool IsInvicible() => isInvincible;

        public void Construct(float startingHealth)
        {
            health = Mathf.Abs(startingHealth);
            CurrentHealth = health;
        }

        private void Death()
        {
            if (isHealthZero) return;

            isHealthZero = true;
            OnHealthIsZero?.Invoke();
        }

        private void CheckForDeath()
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Death();
            }
        }
        public void SetHealth(float amount)
        {
            CurrentHealth = amount;
        }

        public void AddHealth(float amount)
        {
            CurrentHealth += amount;
        }

        public void SetInvincible(bool isInvincible)
        {
            this.isInvincible = isInvincible;
            OnInvicibleChanged?.Invoke();
        }
        public void Kill()
        {
            TakeDamage(MaxHealth);
        }

        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;

            OnDamageReceived?.Invoke();
        }

    }
}
