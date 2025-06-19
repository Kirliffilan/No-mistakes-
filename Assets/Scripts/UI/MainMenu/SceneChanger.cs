using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string _sceneName; //название сцены

    public void ChangeScene() //смена сцены
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void CloseScene() //выход из игры
    {
        Application.Quit();
    }
}
