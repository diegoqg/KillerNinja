﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huesito : MonoBehaviour , Enemy{
    GameObject GoPlayer;
    Transform TfPlayer;
    public int Vida;
    float MinDistancia = 8.0f;
    int Daño;
    public float freq = 1.0f;
    public Object weapon;
    Vector3 posArrow;
    bool vacioLegal = false;
    public void RecibirDaño()
    {

    }

    public void Pegar()
    {
        
    }

    // Use this for initialization
    void Start () {
        Daño = 1;
        Vida = 1;
        // Buscamos el Objeto del Ninja
        GoPlayer = GameObject.FindWithTag("Ninja");
        TfPlayer = GoPlayer.transform;
        weapon = Resources.Load("Fletcha");
        posArrow = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x >= TfPlayer.position.x)
        {
            // Comprovamos si el ninja esta en la distancia minima para pegar
            if (Vector3.Distance(transform.position, TfPlayer.position) <= MinDistancia && !vacioLegal)
            {
                vacioLegal = true;
                Instantiate(weapon, posArrow, new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
