using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Firework : MonoBehaviour
{
    public float fireworkSize;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            ParticleSystem particleSystem = GameManager.instance.EffectParticle;
            particleSystem.transform.position = transform.position;
            ParticleSystem.EmissionModule em = particleSystem.emission;
            em.SetBurst(0, new ParticleSystem.Burst(0, fireworkSize));
            ParticleSystem.MainModule mm = particleSystem.main;
            mm.startSpeedMultiplier = fireworkSize;
            particleSystem.Play();
            Destroy(gameObject);
        }
    }
}
