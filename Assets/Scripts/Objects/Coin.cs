using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip coinClip;

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager.Instance.Player.coin++;
        Destroy(gameObject);
        if(coinClip) SoundManager.PlayClip(coinClip);
    }
}
