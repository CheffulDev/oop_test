using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(EnemySpawnerConfigSO), menuName = "Game/Config/" + nameof(EnemySpawnerConfigSO), order = 0)]
    public class EnemySpawnerConfigSO : ScriptableObject
    {
        [SerializeField] private float spawnCooldown = 3f;

        [SerializeField] private SpawnPositionData spawnPositionData;



        public float SpawnCooldown => spawnCooldown;

        public SpawnPositionData SpawnPosition => spawnPositionData;

    }

    [Serializable]
    public struct SpawnPositionData
    {
        public float minX, maxX;
        public float y;
    }
}
