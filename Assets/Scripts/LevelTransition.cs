using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
   public bool hasFadeInOut = true;
   public string levelName = "PleaseChangeMe";
   public Image fadeInOutImage;

   private bool loadingScene = false;
   private string menuSceneName = "MainMenu";

   private void Awake()
   {
      if (hasFadeInOut)
         fadeInOutImage.color = Color.black;
   }

   private void Start()
   {
      if (hasFadeInOut)
         StartCoroutine(fadeImage(fadeOut: false));
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (!loadingScene && collision.gameObject.CompareTag("Player"))
      {
         StartCoroutine(fadeImage(fadeOut: true));
         StartCoroutine(loadSceneAsync());
         loadingScene = true;
      }
   }

   public void loadMainMenuScene()
   {
      SceneManager.LoadScene(menuSceneName);
   }

   public void manualLevelTransition()
   {
      SceneManager.LoadScene(levelName);
   }

   public void quitGame()
   {
      Application.Quit();
   }

   IEnumerator fadeImage(bool fadeOut)
   {
      float fadeInOutTime = 1.0f;
      float elapsedTime = 0.0f;
      Color c = fadeInOutImage.color;

      while (elapsedTime <= fadeInOutTime)
      {
         yield return null;
         elapsedTime += Time.deltaTime;
         if (fadeOut)
            c.a = Mathf.Clamp01(elapsedTime / fadeInOutTime);
         else
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeInOutTime);
         fadeInOutImage.color = c;
      }
   }

   IEnumerator loadSceneAsync()
   {
      AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);
      asyncLoad.allowSceneActivation = false;

      while (!asyncLoad.isDone)
      {
         yield return null;
         if (asyncLoad.progress >= 0.9f && fadeInOutImage.color.a >= 1.0f)
            asyncLoad.allowSceneActivation = true;
      }
      loadingScene = false;

   }
}
