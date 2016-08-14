using UnityEngine;
using System.Collections;

//Gestiona el lanzamiento de bombas

public class bombas : MonoBehaviour {
    public bool isuno;
    public GameObject pruebaBomba;
    public GameObject pruebaEmbellecedor;
    public GameObject bomba;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject bmbSpawn;
    bombatriger btr;
    int cont;
    void Start () {
        cont = 0;
        pruebaBomba.GetComponent<MeshRenderer>().enabled = false;
        pruebaEmbellecedor.GetComponent<MeshRenderer>().enabled = false;
        btr = pruebaBomba.GetComponent<bombatriger>();
    }
	
	// Update is called once per frame
	void Update () {
        if (cont < 3)
        {
            if (Input.GetKey(KeyCode.U) && isuno == true || Input.GetKey(KeyCode.Keypad9) && isuno == false)
            {
                pruebaBomba.GetComponent<MeshRenderer>().enabled = true;
                pruebaEmbellecedor.GetComponent<MeshRenderer>().enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.U) && isuno == true || Input.GetKeyUp(KeyCode.Keypad9) && isuno == false)
            {
                pruebaBomba.GetComponent<MeshRenderer>().enabled = false;
                pruebaEmbellecedor.GetComponent<MeshRenderer>().enabled = false;
                if (btr.puede)
                {
                    bmbSpawn=Instantiate(bomba, new Vector3(pruebaBomba.transform.position.x, pruebaBomba.transform.position.y, pruebaBomba.transform.position.z), Quaternion.identity) as GameObject;
                    bmbSpawn.GetComponent<explosivoscript>().propietario(isuno);
                    cont++;
                    if (cont == 1)
                    {
                        b1.SetActive(false);
                    }
                    if (cont == 2)
                    {
                        b2.SetActive(false);
                    }
                    if (cont == 3)
                    {
                        b3.SetActive(false);
                    }
                }
            }
        }
    }
}
