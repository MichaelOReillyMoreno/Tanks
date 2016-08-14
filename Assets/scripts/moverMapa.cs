using UnityEngine;
using System.Collections;
//Hace que la camara del minimapa siga al tanque objetivo desde el aire.
public class moverMapa : MonoBehaviour {

    public GameObject target;
    void Update()
    {

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y+50, target.transform.position.z);
    }
}