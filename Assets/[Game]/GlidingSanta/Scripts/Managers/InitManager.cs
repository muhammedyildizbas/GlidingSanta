using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InitManager : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("GlidingSantaUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("GlidingSantaGame", LoadSceneMode.Additive);
        Destroy(gameObject);
    }
}
