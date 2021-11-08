using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Controllers.Pedestal
{

    public class PedestalControler : MonoBehaviour
    { 
        // Parent gameobject that will be looped through to get all the list of spikes
        [SerializeField] protected GameObject SpikesParent;

        [SerializeField] protected List<GameObject> Spikes;

        [SerializeField] protected PlayableDirector CameraSequence;


        protected void UpdateSpikes(bool SpikeState)
        {
            foreach (GameObject spike in Spikes)
            {
                spike.gameObject.SetActive(false);
            }
        }
    }
}
