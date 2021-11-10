using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Pedestal
{
    public class SingleUsePedestal : PedestalControler
    {
        int spikesParentChildCount;
        private void Start()
        {

            if (SpikesParent != null)
            {
                spikesParentChildCount = SpikesParent.transform.childCount;

                for (int i = 0; i < spikesParentChildCount; i++)
                {
                    Spikes.Add(SpikesParent.transform.GetChild(i).gameObject);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // Activate/Deactivate Spikes
                UpdateSpikes(false);

                // Play camera sequence if assigned
                PlayCameraSequence();

                // Disable the trigger
                gameObject.GetComponent<BoxCollider>().enabled = false;

            }
        }

        private void PlayCameraSequence()
        {
            if (CameraSequence != null)
                CameraSequence.Play();
            else
                Debug.LogError($"No playable Director component on  {gameObject.name}.");
        }

    }
}
