using UnityEngine;
using System.Collections;
//Establece si hay espacio para soltar una bomba.
public class bombatriger : MonoBehaviour {
    private int collisionCount;
    public bool puede;
    void Start () {
        collisionCount = 0;
        puede = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name!="bordes" && other.tag!="ladrillo")
        collisionCount++;
    }


    void OnTriggerExit(Collider other)
    {
        if (other.name != "bordes" && other.tag != "ladrillo")
            collisionCount--;
    }


    void Update()
    {
        if (collisionCount == 0)
        {
            puede = true;
        }
        else
        {
            puede = false;
        }
    }
}
