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
    public UnityEvent onActivated;
    public bool isDropper;
    public int dropperTier;

    //variables privadas
    private TextMesh textMesh;

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
                if (isDropper)
                {
                    upgradeOrDelete();
                    Debug.Log("acabas de mejorar un droper");
                }
            }
        }
    }

    public void AddCost()
    {
        if(Costo <= 0)
        {
            Costo = 10;
        }
        else
        {
            Costo *=2;
        }
    }
    public void upgradeOrDelete()
    {
        if (dropperTier == 5)
        {
            gameObject.SetActive(false);
        }
        else
        {
            AddCost();
            dropperTier++;
        }
    }
}
