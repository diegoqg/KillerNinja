using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

    //GameObjects -> sera una lista de los terrenos que hay, para luego cogerlos.
    public Object[] terrains;
    public float freq = 2f;
    float crono;
    Vector3 newPos;
   
	// Use this for initialization
	void Start () {
        Debug.Log("HOLAA EXISTO DE VERDAD");
        terrains = Resources.LoadAll("Terrain/", typeof(GameObject));
        foreach(GameObject t in terrains){
            Debug.Log(t.name);
        }
        crono = freq;
        newPos = transform.position;
        //newPos += Vector3.right;
        //newPos.y += 0;
    }
	
	// Update is called once per frame
	void Update () {
        crono -= Time.deltaTime;
        if (crono <= 0) {
            crono = freq;
            
            GameObject terr = (GameObject) terrains[Mathf.RoundToInt(Random.Range(0f, terrains.Length - 1f))];
            Instantiate(terr, newPos ,terr.transform.rotation);
            Destroy(this);
        }

    }
}
