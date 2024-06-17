using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public int coin;
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        controller =  GetComponent<PlayerController>();
    }
}
