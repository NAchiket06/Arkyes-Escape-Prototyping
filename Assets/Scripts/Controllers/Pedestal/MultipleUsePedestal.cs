using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers.Pedestal;

public class MultipleUsePedestal : PedestalControler
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            foreach(GameObject spike in Spikes)
            {
                spike.SetActive(!spike.activeInHierarchy);
            }
        }
    }
}
