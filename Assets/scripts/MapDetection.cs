using UnityEngine;
using System.Collections;

//Gestiona que se renderiza y cuando en cada minimapa.

public class MapDetection : MonoBehaviour {

    public GameObject target;
    tanqueController tanqueScript;
    public bool isUno;
    public Camera map;
    private bool estaDentro;
    public bool disparando;
    void Start()
    {
        tanqueScript = target.GetComponent<tanqueController>();
        estaDentro = false;
    }
    void Update()
    {

        if (disparando && !estaDentro)
        {
            StartCoroutine(disparoDetection());
        }
    }
        void OnTriggerEnter(Collider other)
    {
        if (tanqueScript.estaOculto == false)
        {
            if ((other.tag == "tanque1" && !isUno) || (other.tag == "tanque2" && isUno))
            {
                estaDentro = true;
                map.cullingMask = LayerMask.GetMask("Water", "tq1", "muros", "tq2", "terreno");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
         if ((other.tag == "tanque1" && !isUno) || (other.tag == "tanque2" && isUno))
            {
                estaDentro = false;
                if (!isUno)//tq2
                    map.cullingMask = LayerMask.GetMask("Water","muros", "tq2", "terreno");
                if (isUno)//tq1
                    map.cullingMask = LayerMask.GetMask("Water", "tq1", "muros",  "terreno");
            }
    }
   public IEnumerator disparoDetection()
    {
        disparando = false;
        map.cullingMask = LayerMask.GetMask("Water", "tq1", "muros", "tq2", "terreno");
        yield return new WaitForSeconds(2);
        if (!isUno)//tq2
        map.cullingMask = LayerMask.GetMask("Water", "muros", "tq2", "terreno");
        if (isUno)//tq1
        map.cullingMask = LayerMask.GetMask("Water", "tq1", "muros", "terreno");
        yield break;
    }
}
