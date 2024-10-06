using UnityEngine;

public class Blades : MonoBehaviour
{
    [SerializeField] private int _bladeSpeed = 100;

    private void Update()
    {
        transform.Rotate(0, 0, _bladeSpeed * Time.deltaTime);
    }
}
