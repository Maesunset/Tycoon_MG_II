using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    //variables publicas
    public ResourceManager ResourceManager;
    public float Costo;
    public string text;
   // public bool isDropper;
    public UnityEvent onActivated;

    //variables privadas
    private TextMesh textMesh;
    private int upgadeTier = 1;

    void Start()
    {
        // inicializar variables
        textMesh = GetComponentInChildren<TextMesh>();
    }
    private void Update()
    {
        // el texto y el costo
        textMesh.text = text + " $" + Costo;
    }
    // ver si coliciona con algo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // si tenemos suficientes recursos
            if (ResourceManager.CurrentResources() >= Costo)
            {
                // le cobra el costo
                ResourceManager.RemoveResources(Costo);
                onActivated.Invoke();
            }
        }
    }

    public void AddCost()
    {
        
    }
}
