using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject cajaElectrica;
    public int lugarDeSpawn;
    Transform lugarFinal;


    private void Awake()
    {
        lugarDeSpawn = Random.Range(0, spawnPoints.Length);
        lugarFinal = spawnPoints[lugarDeSpawn];
        Instantiate(cajaElectrica, lugarFinal.position, lugarFinal.rotation);
    }
}
