using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public Material repairedMaterial;
    public GameObject particles;

    public event Action meHanActivado;  // Evento que se invoca cuando un pancho colisiona con la palanca
    private bool yaEstaActivado = false; // bandera que evita que activemos la palanca una y otra vez

    private void OnCollisionEnter(Collision col)
    {
        if(!yaEstaActivado) // --> Si la palanca no esta activada...
        {
            if (col.gameObject.tag == "Pancho") // --> y el tag es pancho
            {
                Debug.Log("MeChocaron");
                yaEstaActivado = true; // --> setea la bandera asi no podemos volver a activar la palanca
                meHanActivado?.Invoke(); // --> invoca la funcion en ElectricityController
                GetComponent<Animator>().Play("PalancaHaciaAbajo"); // --> Ejecuta la animacion
                particles.SetActive(true);

                if(repairedMaterial != null)
                {
                    gameObject.GetComponentInChildren<MeshRenderer>().material = repairedMaterial;
                }
            }
        }
    }

    private void OnDisable()
    {
        meHanActivado = null; //Limpia a los subscriptores por las dudas
    }
}
