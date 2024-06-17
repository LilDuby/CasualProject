using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [Range(0f, 1f)] public float moveSpeed;

    [SerializeField] AudioClip dieClip;

    private void FixedUpdate()
    {
        transform.position += Vector3.right * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            Animator animator = other.GetComponentInChildren<Animator>();
            animator.SetTrigger("Die");
            if(dieClip) SoundManager.PlayClip(dieClip);
            GameManager.instance.gameOver = true;
        }
    }
}
