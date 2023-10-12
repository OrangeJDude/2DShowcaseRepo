using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] float levelLoadDelay = 0f;
	// Use this for initialization
	void Start()
	{
		GetComponent<Canvas>().enabled = true;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void LoadLevel()
	{
		Time.timeScale = 1;
		StartCoroutine(LoadNextLevel());
	}

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
