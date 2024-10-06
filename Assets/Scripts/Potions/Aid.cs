using System.Collections;
using UnityEngine;

public class Aid : Potion
{
    [SerializeField] private PlayerDamageSystem _playerDamage;
    [SerializeField] private PlayerSoundManager _soundManager;


    private string _heartVFXpath = "Aid";
    private GameObject _heartVFX;

    private void Awake()
    {
        _heartVFX = Resources.Load<GameObject>(_heartVFXpath);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_playerDamage.CurrentHealth < 100)
            {
                Destroy(gameObject);
                _playerDamage.ApplyHeal(100);
                _soundManager.PlayAidSound();
                Instantiate(_heartVFX, transform.position, Quaternion.identity);
            }
            else
            {
                StartCoroutine(ScaleEffect());
                _soundManager.PlayFullHealthSound();
            }
        }
    }

    private IEnumerator ScaleEffect()
    {
        float scaleAmount = 1.5f;
        float duration = 0.2f;
        float timer = 0f;

        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale + new Vector3(scaleAmount, scaleAmount, scaleAmount);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / duration);
            yield return null;
        }
        
        timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / duration);
            yield return null;
        }
    }
}
