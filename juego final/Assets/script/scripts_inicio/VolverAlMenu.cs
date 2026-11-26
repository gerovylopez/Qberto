using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            SceneManager.LoadScene("MenuPrincipal");
    }
}
