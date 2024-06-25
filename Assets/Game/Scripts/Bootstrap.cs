using Game.HealthSystem;
using Game.WeaponSystem;
using UnityEngine;

namespace Game
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Player Character")]
        [SerializeField] private Transform playerCharacterSpawnpoint;
        [SerializeField] private PlayerCharacterController playerCharacterPrefab;
        [SerializeField] private HealthView healthView;
        [SerializeField] private CharacterDataSO playerCharacterData, bulletData;
        [SerializeField] private Bullet bulletPrefab;


        [Space(10)]

        [Header("Enemy")]
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private CharacterDataSO enemyCharacterData;

        [SerializeField] private EnemySpawnerConfigSO enemySpawnerConfig;


        private PlayerCharacterController playerCharacterInstance;

        private EnemySpawner enemySpawner;


        private void Start()
        {
            playerCharacterInstance = Instantiate(playerCharacterPrefab, new Vector3(
            playerCharacterSpawnpoint.position.x,
            playerCharacterSpawnpoint.position.y,
            playerCharacterSpawnpoint.position.z),
            Quaternion.identity);

            playerCharacterInstance.Construct(playerCharacterData, bulletData, bulletPrefab, healthView);


            enemySpawner = new EnemySpawner();
            enemySpawner.Construct(enemySpawnerConfig, enemyPrefab, enemyCharacterData, playerCharacterInstance.Damageable);

        }

        private void Update()
        {
            enemySpawner.HandleSpawn();
        }

    }
}
