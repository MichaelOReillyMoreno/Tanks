using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Gestiona los disparos y sus distintos efectos.

public class partscrip : MonoBehaviour {
    private Animator shoot;
    public Light destello;
    ParticleSystem particula;
	public bool isuno;
	int i;
	bool carga;
	tanqueController moverTanque;
    public GameObject enemyDetector;
    public GameObject color;
    void Start () {
        shoot = this.transform.parent.parent.GetComponent<Animator>();
		carga=true;
		particula = GetComponent<ParticleSystem> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Y) && isuno==true && carga==true || Input.GetKeyDown(KeyCode.Keypad8) && isuno == false && carga == true)
        {

            carga = false;
            color.SetActive(false);
            StartCoroutine (diparar());
            shoot.SetTrigger("disparando");
           enemyDetector.GetComponent<MapDetection>().disparando = true;

        }
	}
	IEnumerator Para()
	{
		yield return new WaitForSeconds(3);
		carga = true;
        color.SetActive(true);
        yield break;
	}
    IEnumerator fogonazo()
    {
        destello.enabled = true;
        destello.intensity = 6;
        while (destello.intensity > 0)
        {
            yield return new WaitForSeconds(0.1f);
            destello.intensity--;
        }
        yield break;
    }
    IEnumerator diparar()
	{
		particula.Emit (1);
        StartCoroutine(fogonazo());
        StartCoroutine(Para());
		transform.parent.parent.parent.GetComponent<tanqueController> ().retroceso = true;
        yield break;
	}
	void OnParticleCollision(GameObject go)
	{
        if (go.tag != "terreno" && go.tag == "tanque1" && go.tag == "tanque2")
        {
            go.GetComponent<Rigidbody>().AddExplosionForce(2000, go.transform.position + new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10)), 20);

        }
        if (go.tag == "tanque1" || go.tag == "tanque2")
        {
			moverTanque = go.GetComponent<tanqueController>();
            moverTanque.Restarvida(1, 3000);
        }

    }

}
