using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    //variables publicas

    public ResourceManager resourceManager;

    //cuando entra algo en el triger

    private void OnTriggerEnter(Collider other)
    {
            // so el objeto es un recurso
            if(other.gameObject.GetComponent<resource>())
        {
            resourceManager.AddResources(other.gameObject.GetComponent<resource>().value);
            Destroy(other.gameObject);
        }
    }
}
