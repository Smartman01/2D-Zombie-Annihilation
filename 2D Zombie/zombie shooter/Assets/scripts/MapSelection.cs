using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour {
    public string[] names;

    public void RandomMap ()
    {
        string map = names[Random.Range(0, names.Length)];
        SceneManager.LoadScene(map);
    }

    public void LoadScene (string level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
}
