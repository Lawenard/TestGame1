using System.Collections;
using UnityEngine;

public class EffectKiller : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
        //StartCoroutine(Kill(GetComponent<ParticleSystem>().main.duration));
    }

    //IEnumerator Kill(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    // some code
    //    Destroy(gameObject);
    //}
}
