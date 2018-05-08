using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinxillo : MonoBehaviour , Enemy{
    public int Vida;
    int Daño;    
    Transform TfPlayer;
    bool HePegado;
    public float MinDistancia = 2.0f;
    GameObject GoPlayer;
    public float freq = 0.2f;    
    private Animator anim;
    private CharacterController controller;
    private bool battle_state;

    public void RecibirDaño()
    {
        Vida = Vida - 1;
        if (Vida == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Pegar()
    {
        HePegado = true;
        Debug.Log("PEGAR A NINJA");
        anim.SetInteger("battle", 1);
		battle_state = true;
        anim.SetInteger("moving", 3);
        GoPlayer.GetComponent<NinjaMove>().RecibirDaño();
        // IdleAtack();
    }

    public void IdleAtack()
    {
        anim.SetInteger("battle", 0);
        battle_state = false;
    }

	// Use this for initializations
	void Start () {
        Daño = 1;
        Vida = 1;
        HePegado = false;
        // Buscamos el Objeto del Ninja
        GoPlayer = GameObject.FindWithTag("Ninja");
        TfPlayer = GoPlayer.transform;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
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
                if (!HePegado)
                {
                    Pegar();
                }
                if (HePegado)
                {
                    freq -= Time.deltaTime;
                    if (freq <= 0)
                    {
                        IdleAtack();
                    }                    
                }
            }
        }                
	}
}
