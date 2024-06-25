using Game.HealthSystem;
using Game.Movement;
using Game.WeaponSystem;
using UnityEngine;

namespace Game
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;

        [SerializeField] private Transform bulletSpawnpoint;

        private Health health;
        private HealthView healthView;
        private Weapon weapon;
        private CharacterDataSO characterData;

        public void Construct(CharacterDataSO characterData, CharacterDataSO bulletData, Bullet bulletPrefab, HealthView healthView)
        {
            this.characterData = characterData;

            this.health = new Health();
            health.Construct(this.characterData.Health);

            this.healthView = healthView;
            this.healthView.Construct(health);

            characterMovement.Construct(this.characterData.MoveSpeed);

            this.weapon = new Weapon();

            weapon.Construct(bulletPrefab, bulletSpawnpoint, bulletData);
        }

        private void Update()
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            characterMovement.Move(input);

            weapon.HandleWeapon();
        }


        public IDamageable Damageable => health;
    }
}
