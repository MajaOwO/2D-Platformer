using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class kill_volume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
