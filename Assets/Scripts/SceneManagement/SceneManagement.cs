using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneManagement : MonoBehaviour
    {

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoad;
        }


        void OnSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            print("New Scene loaded");
            UpdatePlayerPosition();

        }

        private static void UpdatePlayerPosition()
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject SpawnPoint = GameObject.FindWithTag("PlayerSpawn");
            player.transform.position = SpawnPoint.transform.position;
        }
    }

}