using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    [SerializeField] float waitingTime = 3f;


    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayEffect());
    }

    IEnumerator DelayEffect()
    {
        yield return new WaitForSeconds(waitingTime);
        SceneManager.LoadScene("GameOver");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
