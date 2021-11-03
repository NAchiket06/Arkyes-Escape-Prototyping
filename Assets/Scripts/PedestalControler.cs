using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalControler : MonoBehaviour
{
    // Parent gameobject that will be looped through to get all the list of spikes
    [SerializeField] public GameObject SpikesParent;


    [SerializeField] public List<GameObject> Spikes;
    
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
            //print("Activate spikes");

            /*
             * Activate/Deactivate Spikes
             * */

            foreach(GameObject spike in Spikes)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void PanOutCamera()
    {
        //FindObjectOfType<PlayerController>().gameObject.GetComponent()
    }
}
