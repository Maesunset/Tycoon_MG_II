using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{

    // variables Publicas

    public Text resourceText;

    //variables Privadas

    private float currentResources;

    void Start()
    {
        //Inicialiar variables 
        currentResources = 0;
        Update_UI();


    }

    // funciones

    //Agregar recursos
    public void AddResources(float _valeu)
    {
        currentResources += _valeu;
        Update_UI();
    }

    //quitar recursos
    public void RemoveResources(float _valeu)
    {
        currentResources -= _valeu;
        Update_UI();
    }

    //devolver Los recursos actuales

    public float CurrentResources()
    {
        return currentResources; 
    }

    //actualizar el UI

    public void Update_UI()
    {
        resourceText.text = "Cryptos: $" + currentResources;
    }
}
