using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Controla los tanques y su HUD

public class tanqueController : MonoBehaviour {
    bool invulnerable;
    bool descanso;
    bool startCort;
	[HideInInspector]
    public float speed;
	[HideInInspector]
	public float speedAUX;
    float rotationSpeed;
    public ParticleSystem cortina;
    private ParticleSystem.EmissionModule emission;
    public GameObject celda1;
    public GameObject celda2;
    public GameObject celda3;
    public GameObject torreta;
    public GameObject particulas;
    public GameObject life;
    public GameObject bombas;
    public GameObject carga;
    public GameObject fuego;
    public GameObject fondoResultado;
    public GameObject perder;
    public GameObject ganar;
    public GameObject rival;
    public GameObject humoCont;
    public Light luz;
    tanqueController tanque;
    private Rigidbody rb; 
    bool partidaFinalizada;
    public bool isuno;
    public bool estaOculto;
	public bool retroceso;
    int vida;
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 10;
		speedAUX = speed;
        rotationSpeed = 60;
        vida = 3;
        invulnerable = false;
		tanque = rival.GetComponent<tanqueController>();
        emission = cortina.emission;
        emission.enabled = false;
        partidaFinalizada = false;
    }

    void FixedUpdate()
    {
		if (retroceso)
		{			
			rb.AddRelativeForce (0,0,-1500);
			retroceso = false;
		}

        if (Input.GetKey(KeyCode.D) && isuno == true || Input.GetKey(KeyCode.RightArrow) && isuno == false)
        {
           // transform.Rotate(Vector3.up * rotationSpeed );
			Quaternion deltaRotation = Quaternion.Euler(new Vector3 (0f,rotationSpeed,0f) * Time.deltaTime);
			rb.MoveRotation(rb.rotation * deltaRotation);

        }
        if (Input.GetKey(KeyCode.A) && isuno == true || Input.GetKey(KeyCode.LeftArrow) && isuno == false)
        {
           //transform.Rotate(-Vector3.up * rotationSpeed );    
			Quaternion deltaRotation = Quaternion.Euler(new Vector3 (0f,-rotationSpeed,0f) * Time.deltaTime);
			rb.MoveRotation(rb.rotation * deltaRotation);		   
        }

        if (Input.GetKey(KeyCode.W) && isuno == true || Input.GetKey(KeyCode.UpArrow) && isuno == false)
        {
           // rb.velocity = this.transform.forward * speed;
            //transform.position += this.transform.forward * speed * Time.deltaTime;
            // Vector3 dir = new Vector3(speed, 0, 0);
            //rb.velocity = transform.forward.normalized * rb.velocity.magnitude;
            // rb.AddRelativeForce(dir);
			rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S) && isuno == true || Input.GetKey(KeyCode.DownArrow) && isuno == false)
        {
          // rb.velocity = this.transform.forward * -speed ;
            // rb.velocity.Normalize();
            //  transform.GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
            // Vector3 dir = new Vector3(-speed, 0, 0);
            //rb.velocity = transform.forward.normalized * rb.velocity.magnitude;
            //  rb.AddRelativeForce(dir);
			rb.MovePosition(transform.position + transform.forward * -speed * Time.deltaTime);

        }

    }


    void Update()
    {

         if (Input.GetKey(KeyCode.T) && isuno == true || Input.GetKey(KeyCode.Keypad7) && isuno == false)
         {
             StartCoroutine(humo());
             humoCont.SetActive(false);
         }
        if (Input.GetKeyDown(KeyCode.Z) && isuno == true || Input.GetKeyDown(KeyCode.Keypad1) && isuno == false)
        {
            //apagar LUZ
            if (luz.intensity == 0)
            {
                luz.intensity = 8;
            }
            else
            {
                luz.intensity = 0;
            }
        }
        if (vida >= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && isuno == true || Input.GetKeyDown(KeyCode.RightControl) && isuno == false )
            {
                if(descanso==false)
                StartCoroutine(descansar(2,8));
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && isuno == true || Input.GetKeyUp(KeyCode.RightControl) && isuno == false)
            {
                speed = 7;
            }         
            if (Input.GetKey(KeyCode.F1))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (rb.transform.position.y < 1.35f)
            {
                estaOculto = true;
            }
            else
            {
                estaOculto = false;
            }
        }

        

    }
   public void Restarvida(int i,int f)
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(f, gameObject.transform.position + new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2)), 40);

        if (!invulnerable && !partidaFinalizada)
        {
            vida=vida-i;
            if (vida <= 2)
            {
                celda1.SetActive(false);
            }
            if (vida <= 1)
            {
                celda2.SetActive(false);
            }
            if (vida <= 0)
            {
                celda3.SetActive(false);
                Morir();
            }
            invulnerable = true;
            StartCoroutine(inv());
        }
    }
    void Morir()
    {
        partidaFinalizada = true;
        torreta.GetComponent<rotate>().enabled = false;
        particulas.SetActive(false);
        life.SetActive(false);
        bombas.SetActive(false);
        carga.SetActive(false);
        fuego.SetActive(true);
        fondoResultado.SetActive(true);
        ganar.SetActive(false);
        tanque.win();
    }
    public void win()
    {
        fondoResultado.SetActive(true);
        perder.SetActive(false);
    }
    IEnumerator inv()
    {

        yield return new WaitForSeconds(3f);
        invulnerable = false;
        yield break;
    }
    IEnumerator descansar(int ii, int jj)
    {
        speed = 20;
        yield return new WaitForSeconds(ii);
        speed = 10;
        descanso = true;
        yield return new WaitForSeconds(jj);
        descanso = false;
        yield break;
    }
    IEnumerator humo()
    {
        emission.enabled = true;
        yield return new WaitForSeconds(8);
        emission.enabled = false;
        yield break;
    }

}
