using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMecanica : MonoBehaviour
{
    public GameObject cronometroGO;
	public Cronometro cronometroScript;
    // Start is called before the first frame update
    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
		cronometroScript = cronometroGO.GetComponent<Cronometro>();
        
    }


    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Vehiculo>()!= null)
		{
			cronometroScript.tiempo = cronometroScript.tiempo = 0;

		}
			
	}
}
