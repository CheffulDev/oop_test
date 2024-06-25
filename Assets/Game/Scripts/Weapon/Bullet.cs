using Game.Movement;
using UnityEngine;

namespace Game.WeaponSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private CharacterMovement movement;
        private CharacterDataSO bulletData;

        public void Construct(CharacterDataSO bulletData)
        {
            this.bulletData = bulletData;
            movement.Construct(this.bulletData.MoveSpeed);
        }

        private void Start()
        {
            Destroy(this.gameObject, 5f);
        }

        private void Update()
        {
            movement.Move(Vector2.up);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.GetDamageable().TakeDamage(bulletData.Damage);
                Destroy(this.gameObject);
            }
        }

    }
}