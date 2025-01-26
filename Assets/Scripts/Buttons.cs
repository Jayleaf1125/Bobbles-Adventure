using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}