using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private void Update()
    {
        transform.position = PlayerManager.Instance.Player.transform.position;
    }
}
