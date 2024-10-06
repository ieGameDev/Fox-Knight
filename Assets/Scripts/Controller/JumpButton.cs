using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private JumpHandler _jumpHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        _jumpHandler.HandleJump();        
    }
}
