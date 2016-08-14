using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Genera cierta marea en el agua, desactivado hasta a veriguar porque sube descontroladamente en ciertos momentos.

public class AguaScript : MonoBehaviour {
    Transform aguaTR;
    float speed;
    float dir;
    void Start () {
        aguaTR = gameObject.transform;
        speed = 0.0004f;
        dir = 100;
        StartCoroutine(cambio());
    }
	
	// Update is called once per frame
	void Update () {
        aguaTR.position = Vector3.MoveTowards(transform.position, new Vector3(0, dir, 0), speed);
    }
    IEnumerator cambio()
    {
        while (SceneManager.GetActiveScene().name == "esneca")
        {
            dir = -dir;
            yield return new WaitForSeconds(Random.Range(4, 6));
        }        
        yield break;
    }
}
