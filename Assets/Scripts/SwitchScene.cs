using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private int Timer = 60;
    [SerializeField] private float SpendedTime = 0.0f;


    void Update()
    {
        SpendedTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.N) || Timer <= SpendedTime)
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            return;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
