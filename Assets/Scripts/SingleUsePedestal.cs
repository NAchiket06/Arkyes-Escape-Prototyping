using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUsePedestal : PedestalControler
{
    int spikesParentChildCount;
    private void Start()
    {
        spikesParentChildCount = SpikesParent.transform.childCount;

        for(int i=0;i<spikesParentChildCount;i++)
        {
            Spikes.Add(SpikesParent.transform.GetChild(i).gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //print("Activate spikes");

            /*
             * Activate/Deactivate Spikes
             * */

            foreach (GameObject spike in Spikes)
            {
                spike.gameObject.SetActive(false);
            }
        }
    }
}
