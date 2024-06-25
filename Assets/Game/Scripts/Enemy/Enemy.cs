using Game.HealthSystem;
using Game.Movement;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CharacterMovement movement;
        private IDamageable health, target;

        private CharacterDataSO enemyData;

        public void Construct(CharacterDataSO enemyData, IDamageable target)
        {
            this.enemyData = enemyData;

            health = new Health();
            health.Construct(this.enemyData.Health);

            this.target = target;

            movement.Construct(enemyData.MoveSpeed);

            (health as Health).OnHealthIsZero += Death;

        }

        private void Death()
        {
            (health as Health).OnHealthIsZero -= Death;

            Destroy(this.gameObject);
        }

        private void Update()
        {
            movement.Move(Vector2.down);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerCharacterController player))
            {
                target.TakeDamage(50);
            }
        }

        private void OnDisable()
        {
            (health as Health).OnHealthIsZero -= Death;
        }

        public IDamageable GetDamageable() => health;
    }
}
