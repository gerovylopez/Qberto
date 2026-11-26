using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonCartel : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(Tambalear());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.08f, 0.85f, 1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

    private IEnumerator Tambalear()
    {
        float t = 0f;
        while (t < 0.7f)
        {
            t += Time.deltaTime;
            float angulo = 7f * Mathf.Exp(-6f * t) * Mathf.Sin(t * 20f);
            transform.localEulerAngles = new Vector3(0f, 0f, angulo);
            yield return null;
        }
        transform.localEulerAngles = Vector3.zero;
    }
}
