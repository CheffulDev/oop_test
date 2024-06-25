using UnityEngine;

namespace Game.WeaponSystem
{
    public class Weapon
    {
        private Transform bulletSpawnpoint;
        private Bullet bulletPrefab;
        private CharacterDataSO bulletData;

        public void Construct(Bullet bulletPrefab, Transform bulletSpawnpoint, CharacterDataSO bulletData)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSpawnpoint = bulletSpawnpoint;

            this.bulletData = bulletData;

        }

        private void Shoot()
        {
            Bullet newBullet = Object.Instantiate(bulletPrefab, bulletSpawnpoint.position, Quaternion.identity);

            newBullet.Construct(bulletData);

        }
        
        public void HandleWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }
}
