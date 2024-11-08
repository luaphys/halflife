using System.Collections; // Add this line
using UnityEngine;

public class QuitGameAfterTime : MonoBehaviour
{
    public float delay = 10f; // Time in seconds before quitting

    void Start()
    {
        StartCoroutine(QuitAfterDelay());
    }

    IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();

        // If running in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
