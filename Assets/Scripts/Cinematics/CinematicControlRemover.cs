using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player;

namespace Cinematics
{
    public class CinematicControlRemover : MonoBehaviour
    {

        PlayerController player;
        PlayableDirector playableDirector;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            playableDirector = GetComponent<PlayableDirector>();
            playableDirector.played += DisablePlayerControl;
            playableDirector.stopped += EnablePlayerControl;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void DisablePlayerControl(PlayableDirector pd)
        {
            player.enabled = false;

        }

        void EnablePlayerControl(PlayableDirector pd)
        {
            player.enabled = true;
        }
    }

}