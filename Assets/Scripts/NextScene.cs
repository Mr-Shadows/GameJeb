
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    private string nextSceneName; // Имя следующей сцены

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        nextSceneName = "SampleScene";
    }

    public void OnAnimationFinish()
    {
        // Загрузить следующую сцену
        SceneManager.LoadScene(nextSceneName);
    }
}