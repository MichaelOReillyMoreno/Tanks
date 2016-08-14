using UnityEngine;
using System.Collections;
//Hace que parpadeen las farolas.
public class luzScritpt : MonoBehaviour {

    public Light luzF;
   public  Light luzFoco;
    int i;
        void Start ()
    {
        i = 0;
        StartCoroutine(inter());
    }

    IEnumerator inter()
    {
        while (i != 4)
        {
            if (luzF.intensity == 0)
            {
                luzF.intensity = 8;
                luzFoco.intensity = 8;
            }
            else
            {
                luzF.intensity = 0;
                luzFoco.intensity = 0;
            }
            yield return new WaitForSeconds(Random.Range(0.05F, 0.8F));
        }
        yield break;
    }
}
