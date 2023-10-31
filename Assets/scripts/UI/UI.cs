using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image blackBG;
    private void Start()
    {
        StartCoroutine(fadeIn());
    }
    public void loadScene(int scene)
    {
        StartCoroutine(fadeout(scene));
       // SceneManager.LoadScene(scene);
    }
   public void salir()
    {
        Application.Quit();
    }
    IEnumerator fadeIn()
    {
        Color c = blackBG.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 2f * Time.deltaTime)
        {
            c.a = alpha;
            blackBG.color = c;
            yield return null;
        }
    }
    IEnumerator fadeout(int scene)
    {
        Color c = blackBG.color;
        for (float alpha = 0f; alpha <= 1; alpha += 2f * Time.deltaTime)
        {
            c.a = alpha;
            blackBG.color = c;
            yield return null;
        }
        SceneManager.LoadScene(scene);
    }
}
