using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class LoadScene : MonoBehaviour
    {

        [SerializeField] string SceneToLoad;

        private void OnTriggerEnter(Collider other)
        {
            //SceneManager.LoadSceneAsync(SceneToLoad);
            StartCoroutine(StartLoadingScene());
        }

        private IEnumerator StartLoadingScene()
        {
            Fader fader = FindObjectOfType<Fader>();

            DontDestroyOnLoad(gameObject);

            yield return fader.FadeIn(0.5f);
            print("Faded In.");
            yield return SceneManager.LoadSceneAsync(SceneToLoad);
            print("Scene Loaded.");
            yield return fader.FadeOut();
            print("Faded Out.");
            Destroy(gameObject);

            //print("Loaded Scene.");
            //yield return fader.FadeOut();
            //print("Faded Out.");
            
        }
    }

}