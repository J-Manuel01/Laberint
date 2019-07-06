using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveEnemi : MonoBehaviour
{
    public Transform transformJugador;
    Transform transformEnemigo;
    public GameObject advertencia;
    float contador = 0.05f;
    float vision = 7;
    public List<Transform> desplaPointTransf;
    private int actualPoint;
    public float desplaSpeed;
    NavMeshAgent enemiDespla;
    public Transform playerPosition;
    public float speed;
    public Text resetTime;

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
                    {
                        if (advertencia == true)
                        {
                            FollowPlayer();
                            return true;
                        }
                    }

                }
            }
        }
        return false;
    }
    public void tepillaron()
    {

        if (jugadorVisto() == true)
        {

            if (contador < 0)
            {

                transformJugador.position = new Vector3(-1.494707f, 0.5898083f, 63.20552f);
            }
            contador -= Time.deltaTime;
            resetTime.text = "resetmap: " + contador;
            resetTime.text = "resetmap: 0";
            
        }
        else
        {
            contador = 0.5f;
        }
    }

    public void MoveEnemigo()
    {
        Vector3 distanNavMesg = enemiDespla.destination;
        distanNavMesg = desplaPointTransf[actualPoint].transform.position - transform.position;

        if (distanNavMesg.magnitude > 1)
        {
            Vector3 directVector = distanNavMesg.normalized;
            transform.LookAt(directVector + transform.position);
            transform.position += directVector * desplaSpeed * Time.deltaTime;
        }
        else
        {
            actualPoint++;
            if (actualPoint >= desplaPointTransf.Count)
            {
                actualPoint = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        Vector3 directionNavMesg = enemiDespla.destination;
        directionNavMesg = playerPosition.position - transform.position;

        Vector3 directionVector = directionNavMesg.normalized;
        transform.LookAt(transform.position + directionVector);

        transform.position += directionNavMesg * speed;
    }

    private void Awake()
    {
        transformEnemigo = transform;
        enemiDespla = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime);
        advertencia.SetActive(jugadorVisto());
        tepillaron();
        MoveEnemigo();

    }
}
