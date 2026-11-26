using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private CanvasGroup fundido;

    public void Salir()
    {
        StartCoroutine(FundirYSalir());
    }

    public void CargarEscena(string escena)
    {
        StartCoroutine(FundirYCargar(escena));
    }

    private IEnumerator FundirYCargar(string escena)
    {
        fundido.blocksRaycasts = true;
        yield return StartCoroutine(Animar.Fundir(fundido, 0f, 1f, 0.6f));
        SceneManager.LoadScene(escena);
    }

    private IEnumerator FundirYSalir()
    {
        fundido.blocksRaycasts = true;
        yield return StartCoroutine(Animar.Fundir(fundido, 0f, 1f, 0.6f));
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
