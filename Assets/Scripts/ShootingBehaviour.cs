using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject pancho;
    public float speed = 100f;
    public bool puedeDisparar = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && puedeDisparar == true)
        {
            SpawnPancho();
        }

    }

    private void SpawnPancho()
    {
        Quaternion randomRot = Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360));

        GameObject instPancho = Instantiate(pancho, shootPoint.position, randomRot);
        Rigidbody instPacnhoRigidbody = instPancho.GetComponent<Rigidbody>();
        instPacnhoRigidbody.velocity = shootPoint.forward * speed;
    }
}
