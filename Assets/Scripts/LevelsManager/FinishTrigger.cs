using System.Collections;
using UnityEngine;


public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private LevelsManager _levelsManager;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private Animator _playerAnimator;

    private string _tornadoPrefabPath = "Tornado";
    private GameObject _tornado;

    private void Awake()
    {
        _tornado = Resources.Load<GameObject>(_tornadoPrefabPath);
    }

    private float _finishDelay = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FinishEffects();

            StartCoroutine(LevelFinish());
        }
    }

    private void FinishEffects()
    {
        _soundManager.PlayFinishSound();
        _playerAnimator.SetTrigger("IsFinish");
        Instantiate(_tornado, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        _soundManager.PlayWindSound();
    }

    private IEnumerator LevelFinish()
    {
        yield return new WaitForSeconds(_finishDelay);
        _levelsManager.LevelFinishSequence();
    }
}
