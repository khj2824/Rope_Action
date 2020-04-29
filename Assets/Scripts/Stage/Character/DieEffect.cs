using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEffect : MonoBehaviour
{
    public Material[] Diemat;
    ParticleSystemRenderer DieParticle;
    void Start()
    {
        DieParticle = gameObject.GetComponent<ParticleSystemRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DieParticle.material = Diemat[Random.Range(0, 3)];
    }
}
