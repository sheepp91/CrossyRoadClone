using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public IEnumerator ReloadScene()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadScene("CrossyRoadsLevel");
    }
}
