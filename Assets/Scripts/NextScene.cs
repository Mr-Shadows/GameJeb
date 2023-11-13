
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    private string nextSceneName; // ��� ��������� �����

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        nextSceneName = "SampleScene";
    }

    public void OnAnimationFinish()
    {
        // ��������� ��������� �����
        SceneManager.LoadScene(nextSceneName);
    }
}