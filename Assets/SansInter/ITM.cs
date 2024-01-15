using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class ITM : MonoBehaviour
{
        protected float lifetime = 10f;
        public abstract void ApplyEffect(SNC snake);
        void Start()
        {
                StartCoroutine(DestroyAfterTime(lifetime));
        }

        IEnumerator DestroyAfterTime(float time)
        {
                yield return new WaitForSeconds(time);
                Destroy(gameObject);
        }
}
