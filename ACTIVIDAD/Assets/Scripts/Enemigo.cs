using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public Transform transformJugador;
    Transform transformEnemigo;
    public GameObject advertencia;
    float contador = 2;
    float vision = 7;
    public Text resetTime;

    public void Awake()
    {
        transformEnemigo = transform;
    }
    void Update()
    {
        
        transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime);       
        advertencia.SetActive(jugadorVisto());
        tepillaron();


    }

    public bool jugadorVisto()
    {
        Vector3 desplazaJugador = transformJugador.position - transformEnemigo.position;
        float distaciajugador = desplazaJugador.magnitude;

        if (distaciajugador < vision)
        {
            float dotProdut = Vector3.Dot(transformEnemigo.forward, desplazaJugador.normalized);
            if (dotProdut >= 0.2)
            {
                RaycastHit hit;
                if (Physics.Raycast(transformEnemigo.position + desplazaJugador.normalized * 1, desplazaJugador.normalized, out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transformEnemigo.position + desplazaJugador.normalized * 1, desplazaJugador.normalized * hit.distance, Color.red);
                    if (hit.collider.gameObject.name == "Jugador")
                        return true;
                }
            }
        }
        return false;
    }
    public void tepillaron()
    {
        
        if (jugadorVisto() == true)
        {
             
            if (contador < 0 )
            {
                
                transformJugador.position = new Vector3(-1.494707f, 0.5898083f, 63.20552f);
            }
            contador -= Time.deltaTime;
            resetTime.text = "resetTime: " + (int)contador;
        }
        else
        {
            contador = 2;
        }

    }
}

