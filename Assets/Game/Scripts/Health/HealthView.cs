using System;
using System.Collections;
using UnityEngine;

namespace Game.HealthSystem
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Transform healthFill;

        [SerializeField] private float scaleLerpDuration = 3f;

        private Health health;

        private Coroutine changeFillScale;

        public void Construct(Health health)
        {
            this.health = health;

            health.OnHealthChanged += UpdateVisuals;
        }

        private void UpdateVisuals()
        {
            if (changeFillScale != null)
                StopCoroutine(changeFillScale);

            changeFillScale = StartCoroutine(ChangeFillScale());

        }

        private IEnumerator ChangeFillScale()
        {
            Vector3 newFillScale = new Vector3(health.CurrentHealth / health.MaxHealth, healthFill.localScale.y, healthFill.localScale.z);

            float elapsedTime = 0f;

            while (elapsedTime < scaleLerpDuration)
            {
                elapsedTime += Time.deltaTime;

                healthFill.localScale = Vector3.Lerp(healthFill.localScale, newFillScale, elapsedTime / scaleLerpDuration);

                yield return null;
            }
        }

        private void OnDisable()
        {
            if (health != null)
            {
                health.OnHealthChanged -= UpdateVisuals;
            }
        }
    }
}
