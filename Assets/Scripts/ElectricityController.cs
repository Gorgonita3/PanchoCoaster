using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class ElectricityController : MonoBehaviour
{
    public GameObject[] cajas;  // --> Array con todas las cajas del nivel
    int cajasActivadas = 0;     // --> nuemro de cajas activadas
    public Text cantidadDeCajas;// --> Texto para la cantidad de cajas
    public float tiempo;           // --> Cantidad de tiempo para completar el juego 
    public Text textoTiempo;    // --> Texto de la cantidad de tiempo 
    public Text cartelVictoria; // --> Cartel para cuando se finalice el juego 
    public Canvas canvasBotones;// --> El canvas donde van a estar los botones al final junto al cartel de victoria 
    public GameObject bazooka;
    public GameObject camara;

    void Start()
    {
        Time.timeScale = 1f;
        cajas = GameObject.FindGameObjectsWithTag("Electricidad"); // --> Buscamos todas las cajas del nivel

        foreach (GameObject c in cajas)
        {
            c.GetComponent<Electricity>().meHanActivado += ActualizarCajasActivadas; // --> Nos Suscribimos a todas las cajas para registrar sus cambios. Si un pancho golpea una caja --> se ejecuta ActualizarCajasActivadas
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    /// <summary>
    /// Esta funcion añade una caja activada al contador y despues compara con el total de cajas para ver si estan todas activadas
    /// </summary>
    public void ActualizarCajasActivadas()
    {
        Debug.Log("Actualizando el numero de cajas activadas");
        cajasActivadas++;
        if(cajasActivadas == cajas.Length)
        {
            Debug.Log("Juego Completo!");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            bazooka.GetComponent<ShootingBehaviour>().puedeDisparar = false;
            canvasBotones.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0.1f;
            cartelVictoria.text = "Ganaste!! llegas tranqui al turno con el odontologo c: , ahi llego el uber";
            //MostrarMenu(); <--Ejemplo      Aca va una funcion que muestra el menu de juego completo
        }
        else
        {
            int cajasFaltantes = cajas.Length - cajasActivadas;
            Debug.Log("Faltan " + cajasFaltantes + " cajas de electricidad");
        }
    }

    private void OnDisable()
    {
        Debug.Log("Limpiando referencias");
        foreach (GameObject c in cajas)
        {
            if(c != null)
            {
                c.GetComponent<Electricity>().meHanActivado -= ActualizarCajasActivadas; // --> Cuando el juego termina hay que limpiar las referencias siempre...
            }
        }
    }

    private void Update()
    {
        cantidadDeCajas.text = cajasActivadas + "/" + cajas.Length;
        if(tiempo > 0) 
        {
            Tiempo();
        }

        if(tiempo <= 0) 
        {
            LoseCondition();
        }
    }

    void Tiempo() 
    {
        tiempo = tiempo - Time.deltaTime;
        textoTiempo.text = tiempo.ToString();
        Debug.Log(tiempo);
    }

    void LoseCondition() 
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        bazooka.GetComponent<ShootingBehaviour>().puedeDisparar = false;
        canvasBotones.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0.1f;
        if(cajasActivadas != cajas.Length) 
        {
            cartelVictoria.text = "Perdiste :c, ahora vas a tener que sacar un turno nuevo y eso va a tardar alrededor de 6 meses :ccccccc";
        }

        
        camara.GetComponent<CameraController>().lookSpeed = 0.5f;
    }
}
