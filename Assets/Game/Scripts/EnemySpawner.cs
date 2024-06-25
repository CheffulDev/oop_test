using Game.HealthSystem;
using UnityEngine;

namespace Game
{
    public class EnemySpawner
    {
        private EnemySpawnerConfigSO config;
        private CharacterDataSO enemyData;

        private float elapsedTime;

        private Enemy enemyPrefab;

        private IDamageable damagableTarget;

        public void Construct(EnemySpawnerConfigSO config, Enemy enemyPrefab, CharacterDataSO enemyData, IDamageable damagableTarget)
        {
            this.config = config;
            this.enemyPrefab = enemyPrefab;
            this.enemyData = enemyData;
            this.damagableTarget = damagableTarget;

            elapsedTime = 0;
        }

        private void SpawnNewEnemy()
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(config.SpawnPosition.minX, config.SpawnPosition.maxX),
                config.SpawnPosition.y,
                0
            );

            var newEnemy = Object.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            newEnemy.Construct(enemyData, damagableTarget);
        }
        public void HandleSpawn()
        {
            if (elapsedTime < config.SpawnCooldown)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0;
                SpawnNewEnemy();
            }
        }

    }
}
