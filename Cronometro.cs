using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Cronometro : MonoBehaviour
{
    public GameObject motorCallesGO;
	public MotorCalles motorCalleScript;

	public float tiempo;
	public float distancia;
	public Text txtTiempo;
	public Text txtDistancia;
	public Text DistanciaFinal;


	void Start () 
	{
		motorCallesGO = GameObject.Find("MotorCalles");
		motorCalleScript = motorCallesGO.GetComponent<MotorCalles>();

		txtTiempo.text = "60";
		txtDistancia.text = "0";

		tiempo = 30;
	}
	
	void Update () 
	{
		if (motorCalleScript.inicioJuego == true && motorCalleScript.juegoTerminado == false)
		{
		 	CalculoTiempoDistancia();
		}

		if (tiempo <= 0 && motorCalleScript.juegoTerminado == false)
		{
			motorCalleScript.juegoTerminado = true;
			motorCalleScript.JuegoTerminadoEstados();
			DistanciaFinal.text = ((int)distancia).ToString() + " mts";
			txtTiempo.text = " ";
		}
	}

	void CalculoTiempoDistancia()
	{
		distancia += Time.deltaTime * motorCalleScript.velocidad;

		txtDistancia.text = ((int)distancia).ToString() + " mts";

		tiempo -= Time.deltaTime;

		int gasolina = (int)tiempo;

	 	txtTiempo.text = "Gas "+gasolina.ToString();
	}
}
