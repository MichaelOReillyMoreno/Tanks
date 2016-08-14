using UnityEngine;
using System.Collections;
//Rota la torreta del tanque.
public class rotate : MonoBehaviour {
	public bool isuno;
	float speed;
    float speedd;
    public GameObject torre;
    void Start () {
		speed = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Input.GetKey(KeyCode.J) && isuno==true || Input.GetKey(KeyCode.Keypad6) && isuno == false)
        {
           transform.Rotate(Vector3.up * speed * Time.deltaTime);
            torre.transform.Rotate(Vector3.up * speed * Time.deltaTime);
            if (speed < 50)
                speed += 0.5f;
        }
            else
            {
                speed = 20;
            }

        if (Input.GetKey(KeyCode.G) && isuno==true || Input.GetKey(KeyCode.Keypad4) && isuno == false)
        {
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);
            torre.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
           if(speed<50)
             speed += 0.5f;
        }
            else
            {
                speed = 20;
            }

        

    }

}