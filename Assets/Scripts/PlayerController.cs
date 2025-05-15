using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private float _moveInput;
    
    [Header("Mobile Controls")]
    public GameObject mobileControls;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        #if UNITY_ANDROID
                mobileControls.SetActive(true);
        #else
                mobileControls.SetActive(false);
        #endif
        
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveInput * moveSpeed, _rb.linearVelocity.y);
        
    }
    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        _moveInput = inputVector.x;
    }
}
