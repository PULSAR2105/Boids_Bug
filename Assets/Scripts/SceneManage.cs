using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public string sceneName;

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
}
