using UnityEngine;
using System.Collections;
//Destruye los ladrillos para evitar que estorben una vez que son derribados.
public class colliderladrillos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="ladrillo")
        Destroy(other.gameObject);
    }
}
