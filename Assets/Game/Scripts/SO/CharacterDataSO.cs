using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(CharacterDataSO), menuName = "Game/Config/" + nameof(CharacterDataSO), order = 0)]
    public class CharacterDataSO : ScriptableObject
    {
        [SerializeField] private float startingHealth, moveSpeed, damage;

        public float Health => startingHealth;
        public float MoveSpeed => moveSpeed;
        public float Damage => damage;

    }
}
