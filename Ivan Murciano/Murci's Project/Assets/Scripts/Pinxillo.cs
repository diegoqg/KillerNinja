using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinxillo : MonoBehaviour , Enemy{
    public int Vida;
    int Daño;    
    Transform TfPlayer;
    bool HePegado;
    float MinDistancia = 1.0f;
    GameObject GoPlayer;

    public void RecibirDaño()
    {
       
    }

    public void Pegar()
    {
        Debug.Log("PEGAR A NINJA");
        GoPlayer.GetComponent<NinjaMove>().RecibirDaño();
    }

	// Use this for initializations
	void Start () {
        Daño = 1;     
        HePegado = false;
        // Buscamos el Objeto del Ninja
        GoPlayer = GameObject.FindWithTag("Ninja");
        TfPlayer = GoPlayer.transform;
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.Log("ESTAMOS A :" + Vector3.Distance(transform.position, Ninja.position));
        //Primero miramos que el duende esta delante del ninja para pegar
        if (this.transform.position.x >= TfPlayer.position.x)
        {   
            // Comprovamos si el ninja esta en la distancia minima para pegar
            if (Vector3.Distance(transform.position, TfPlayer.position) <= MinDistancia)
            {
                Pegar();
            }
        }                
	}
}
