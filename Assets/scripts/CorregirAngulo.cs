using UnityEngine;
using System.Collections;
/// <summary>
/// Clase que corrige el angulo para que nunca este boca abajo un objeto
/// </summary>
public class CorregirAngulo : MonoBehaviour {

    public float rotCorrect = 5;
    public float correctAt = 30;
	bool x;
	bool z;
    bool pos;
	tanqueController tqContr;
	void Start () {
		tqContr = GetComponent<tanqueController>();
	}
	void Update () {
        AnguloCorregido();
	}

    void AnguloCorregido()
    {
		if (!z || !x || transform.position.y > 10f)
		{
			tqContr.speed = 0;
		}
        else
        {
            tqContr.speed = tqContr.speedAUX;
        }

		if ((transform.eulerAngles.x >= correctAt) && (transform.eulerAngles.x < 180)) {
			transform.Rotate (-rotCorrect, 0, 0);
			x = false;
		}
		else
		{
			x = true;
		}
        if ((transform.eulerAngles.x <= (360 - correctAt)) && (transform.eulerAngles.x >= 180))
        {
            transform.Rotate(rotCorrect, 0, 0);
			x = false;
        }
		else
		{
			x = true;
		}
        if ((transform.eulerAngles.z >= correctAt) && (transform.eulerAngles.z < 180))
        {
            transform.Rotate(0, 0, -rotCorrect);
			z = false;
        }
		else
		{
			z = true;
		}
        if ((transform.eulerAngles.z <= (360 - correctAt)) && (transform.eulerAngles.z >= 180))
        {
            transform.Rotate(0, 0, rotCorrect);
			z = false;
        }
		else
		{
			z = true;
		}
    }
}
