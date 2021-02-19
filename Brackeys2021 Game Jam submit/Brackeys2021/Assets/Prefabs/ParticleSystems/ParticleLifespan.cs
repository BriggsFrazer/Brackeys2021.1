using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifespan : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
