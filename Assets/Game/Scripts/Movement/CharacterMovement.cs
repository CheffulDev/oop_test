using UnityEngine;


namespace Game.Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        private float moveSpeed;

        public void Construct(float moveSpeed)
        {
            this.moveSpeed = Mathf.Abs(moveSpeed);
        }

        public void Move(Vector2 direction)
        {
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }


    }
}
