using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene("Fire");
    }

}