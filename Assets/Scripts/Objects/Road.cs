using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Transform carSpawnPosition;
    [Range(0, 100)] public int par;

    private void Awake()
    {
        StartCoroutine("SpawnCar");
    }

    IEnumerator SpawnCar()
    {
        yield return null;
        while (true)
        {
            int random = Random.Range(0, 101);
            if(random < par)
            {
                GameObject obj = GameManager.instance.objectPool.SpawnFromPool("Car");
                obj.transform.position = carSpawnPosition.position;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
