using UnityEngine;
using System.Collections;
//Desactiva ciertas luces del enemigo para no ser vistas por el contrario.
public class miniMapScript : MonoBehaviour
{

    public Light l1;
    public Light l2;
	public Light luzContrario;
	public bool isTnq;
    void OnPreCull()
    {
        
        l1.enabled = false;
        l2.enabled = false;
		if(isTnq)
			luzContrario.enabled = false;
    }

    void OnPreRender()
    {

        l1.enabled = false;
        l2.enabled = false;
		if(isTnq)
			luzContrario.enabled = false;
    }
    void OnPostRender()
    {

        l1.enabled = true;
        l2.enabled = true;
		if (isTnq)
			luzContrario.enabled = true;
    }
}