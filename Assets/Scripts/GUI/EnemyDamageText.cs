using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyDamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    private Coroutine _fadeOutCoroutine;

    private void Start()
    {
        _textMesh.text = string.Empty;
    }

    public void DisplayDamage(int damageAmount)
    {
        if (_fadeOutCoroutine != null)
        {
            StopCoroutine(_fadeOutCoroutine);
        }

        _textMesh.text = "-" + damageAmount.ToString();
        Color textColor = _textMesh.color;
        textColor.a = 1f;
        _textMesh.color = textColor;

        _fadeOutCoroutine = StartCoroutine(FadeOutText(0.3f));
    }

    private IEnumerator FadeOutText(float fadeDuration)
    {
        yield return new WaitForSeconds(fadeDuration);

        float timer = 0f;
        float fadeSpeed = 1f / fadeDuration;

        while (timer < 1f)
        {
            timer += Time.deltaTime * fadeSpeed;
            Color textColor = _textMesh.color;
            textColor.a = 1f - timer;
            _textMesh.color = textColor;
            yield return null;
        }

        _textMesh.text = string.Empty;
    }
}
