using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject motorCalleGO;
	public MotorCalles motorCalleScript;
	public Sprite[] numeros;
    public GameObject contadorNumerosGO;
	public SpriteRenderer contadorNumerosComp;

    public GameObject controladorFordGO;
	public GameObject FordGO;

    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes();
    }

    void InicioComponentes()
	{
        motorCalleGO = GameObject.Find("MotorCalles");
		motorCalleScript = motorCalleGO.GetComponent<MotorCalles>();

		contadorNumerosGO = GameObject.Find("ContadorNumeros");
		contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

		FordGO = GameObject.Find("Ford");
		controladorFordGO = GameObject.Find("ControladorFord");
        InicioCuentaAtras();
    }

    void InicioCuentaAtras()
	{
		StartCoroutine(Contando());
	}

    IEnumerator Contando()
	{

		contadorNumerosComp.sprite = numeros[1];

		yield return new WaitForSeconds(1);

		contadorNumerosComp.sprite = numeros[2];

		yield return new WaitForSeconds(1);

		contadorNumerosComp.sprite = numeros[3];

		yield return new WaitForSeconds(1);

		contadorNumerosComp.sprite = numeros[4];
		motorCalleScript.inicioJuego = true;

		yield return new WaitForSeconds(1);

		contadorNumerosGO.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
