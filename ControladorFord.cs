using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFord : MonoBehaviour
{
    public GameObject fordGO;
	public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 9;
        fordGO = GameObject.FindObjectOfType<Vehiculo>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector2.up * Input.GetAxis("Vertical") * velocidad * Time.deltaTime);
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);

    }
}
