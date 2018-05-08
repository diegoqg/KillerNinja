using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huesito : MonoBehaviour , Enemy{
    GameObject GoPlayer;
    Transform TfPlayer;
    public int Vida;
    float MinDistancia = 2.0f;
    int Daño;

    public void RecibirDaño()
    {

    }

    public void Pegar()
    {
        
    }

    // Use this for initialization
    void Start () {
        Daño = 1;        
        // Buscamos el Objeto del Ninja
        GoPlayer = GameObject.FindWithTag("Ninja");
        TfPlayer = GoPlayer.transform;
    }
	
	// Update is called once per frame
	void Update () {
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
