using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement
{
    public class Fader : MonoBehaviour
    {

        CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public IEnumerator FadeInOut()
        {
            FadeIn(0.5f);
            yield return new WaitForSeconds(1f);
            FadeOut();
            yield return null;
        }
        public IEnumerator FadeIn(float time)
        {
            while(canvasGroup.alpha <1)
            {
                canvasGroup.alpha += Time.deltaTime /  time;
                yield return null;
            }

        }

        public IEnumerator FadeOut()
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / 0.5f;
                yield return null;
            }
        }
    }

}