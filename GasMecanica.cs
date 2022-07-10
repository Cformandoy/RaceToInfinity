using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMecanica : MonoBehaviour
{
    public GameObject cronometroGO;
	public Cronometro cronometroScript;
    // Start is called before the first frame update
    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
		cronometroScript = cronometroGO.GetComponent<Cronometro>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Vehiculo>()!= null)
		{
            Destroy(this.gameObject);
            cronometroScript.tiempo = cronometroScript.tiempo + 8;
		}
			
	}
}
