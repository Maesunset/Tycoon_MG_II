using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    // variables publicas
    public GameObject[] resources;
    public float spawnTime;
    public int dropperTier;

    //variable privadas


    void Start()
    {
        dropperTier = 1;
        InvokeRepeating("DropResource", spawnTime, 1f);
    }
    // dropResources
    void DropResource()
    {
        if (resources[dropperTier-1]!=null || dropperTier >= resources.Length)
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
    }
    //upgradeDropper
    public void UpgradeDropper()
    {
        dropperTier++;
    }
}
