using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCalles : MonoBehaviour
{

    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;
	public GameObject contenedorCallesGO;
	public GameObject[] ArrayCalles;

    int contadorCalles = 0;
	int numeroSelectorCalles;
    public GameObject calleAnterior;
	public GameObject calleNueva;
    public float tamañoCalle;
    public bool salioDePantalla;
    public Vector3 medidaLimitePantalla;
    public GameObject mCamGo;
	public Camera mCamComp;
	public GameObject fordGO;
	public GameObject bgInicio;
	public GameObject bgFinalGO;
	public GameObject bgFinalGO2;

    // Start is called before the first frame update
    void Start()
    {
        InicioJuego();

    }

	
    void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContendorCalles");

        mCamGo = GameObject.Find("MainCamera");
		mCamComp = mCamGo.GetComponent<Camera>();

		bgFinalGO2 = GameObject.Find("PanelGame");
		bgFinalGO2.SetActive(true);

		bgFinalGO = GameObject.Find("PanelGameOver");
		bgFinalGO.SetActive(false);

		fordGO = GameObject.FindObjectOfType<Vehiculo>().gameObject;
        
        VelocidadMotorCalle();
        MedirPantalla();
        BuscoCalles();
    }

	public void JuegoTerminadoEstados()
	{
		bgFinalGO2.SetActive(false);
		bgFinalGO.SetActive(true);
	}

    void VelocidadMotorCalle()
    {
        velocidad = 15;
    }

    void BuscoCalles()
    {        
        ArrayCalles = GameObject.FindGameObjectsWithTag("calle");
		for(int i = 0; i <ArrayCalles.Length ; i++)
		{
			ArrayCalles[i].gameObject.transform.parent = contenedorCallesGO.transform;
			ArrayCalles[i].gameObject.SetActive(false);
			ArrayCalles[i].gameObject.name = "CalleOFF_"+i;
		}
        CrearCalles();

    } 

    void CrearCalles()
	{
		contadorCalles ++;
		numeroSelectorCalles = Random.Range(0,ArrayCalles.Length);
		GameObject Calle = Instantiate(ArrayCalles[numeroSelectorCalles]);
		Calle.SetActive(true);
		Calle.name = "Calle"+contadorCalles;
		Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
	}

    void PosicionoCalles()
	{
		calleAnterior = GameObject.Find("Calle"+(contadorCalles-1));
		calleNueva = GameObject.Find("Calle"+contadorCalles);
		MidoCalle();
		calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x + tamañoCalle,
			calleAnterior.transform.position.y , 10);

		salioDePantalla = false;
	}

    void MidoCalle()
	{
		for(int i = 0; i < calleAnterior.transform.childCount; i++)
		{
			if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
			{
				float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
				tamañoCalle = tamañoCalle + tamañoPieza;
			}
		}
	}

    void MedirPantalla()
	{
		medidaLimitePantalla = new Vector3(mCamComp.ScreenToWorldPoint(new Vector3(0,0,-10)).x - 0.5f,0,0);
	}


    // Update is called once per frame
    void Update()
    {
        if ((inicioJuego == true) && (juegoTerminado == false)){
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);

            if (calleAnterior.transform.position.x + tamañoCalle < medidaLimitePantalla.x && salioDePantalla == false)
			{
				salioDePantalla = true;
				DestruyoCalles();
			}
        }
    }

    void DestruyoCalles()
	{
		Destroy(calleAnterior);
		tamañoCalle = 0;
		calleAnterior = null;
		CrearCalles();
	}
}
