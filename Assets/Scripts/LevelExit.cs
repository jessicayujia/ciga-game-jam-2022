using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    public SpriteRenderer sp;
    public Sprite newSprite;
    public static bool isKeyPickedUp = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isKeyPickedUp) 
        {
            StartCoroutine(LoadNextLevel());
            isKeyPickedUp = false;
        }
    }

    IEnumerator LoadNextLevel()
    {
        sp.sprite = newSprite;
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
