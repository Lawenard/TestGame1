using System.Collections;
using UnityEngine;

public class EffectKiller : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(Kill(GetComponent<ParticleSystem>().main.duration));
    }

    IEnumerator Kill(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
