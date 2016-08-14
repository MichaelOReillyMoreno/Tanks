using UnityEngine;
using System.Collections;
//Analiza si el tanque esta "a la vista" de la bomba y debe explotar.
public class explosivoscript : MonoBehaviour {
	public LayerMask q1;
	public LayerMask q2;
    GameObject objTanq;
	tanqueController moverTanque;
    public bool isuno;
    Transform tanqueTransform;
    public GameObject estado;
    public GameObject explosion;
    public Light estadoLuz;
    public LayerMask tanque;
    public LayerMask murete;
    Vector3 dir;
    public float radioExplosion;
    bool activado;
    bool carga;
    bool tank;
    Ray ray;
    Transform tr;
    void Start () {
        tank = false;
        activado = false;
        StartCoroutine(cargando());
        tr = transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (carga)
        {
            tank = Physics.CheckSphere(transform.position, radioExplosion, tanque);       
            if ((tank && !activado))
            {

                if (tank)
                  {
                    dir = tanqueTransform.position - transform.position;
					//Debug.Log("entra en la esfera el objeto tanque");
                  }
                Ray ray = new Ray(transform.position, dir);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, tanque) && !Physics.Raycast(ray, out hit, Mathf.Infinity, murete))
                {                 
                    activado = true;
                    StartCoroutine(retraso());
                }
            
            }

        }
}

    IEnumerator retraso()
    {
        estado.GetComponent<Renderer>().material.color = Color.red;
        estadoLuz.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        explosion.SetActive(true);
        tr.GetComponent<MeshRenderer>().enabled = false;
        tr.GetComponent <BoxCollider>().enabled = false;
        estado.transform.GetComponent<MeshRenderer>().enabled = false;

		moverTanque = objTanq.GetComponent<tanqueController>();
        moverTanque.Restarvida(2, 7000);
        yield break;
    }
    IEnumerator cargando()
    {
        yield return new WaitForSeconds(4);
        carga = true;
        estadoLuz.intensity = 8;
        estado.GetComponent<Renderer>().material.color = Color.green;
        estadoLuz.color = Color.green;
        yield break;
    }
    public void propietario(bool e)
    {
        isuno = e;
        if (isuno)
        {
            objTanq= GameObject.FindWithTag("tanque2");
            tanqueTransform = objTanq.transform;
			tanque = q2;
        }
        else
        {
            objTanq = GameObject.FindWithTag("tanque1");
            tanqueTransform = objTanq.transform;
			tanque = q1;
        }
    }
}
