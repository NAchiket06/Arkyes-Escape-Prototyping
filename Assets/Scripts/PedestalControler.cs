using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PedestalControler : MonoBehaviour
{
    // Parent gameobject that will be looped through to get all the list of spikes
    [SerializeField] protected GameObject SpikesParent;

    [SerializeField] protected List<GameObject> Spikes;

    [SerializeField] protected PlayableDirector CameraSequence;
    

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
