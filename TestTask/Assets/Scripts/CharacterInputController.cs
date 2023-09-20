using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 20;
    [SerializeField] private float speed = 20;
    private bool IsGround;
    public static GameInput _gameInput;
    private Rigidbody _rigidBody;
    public static bool alive = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _gameInput = new GameInput();
    }

    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.Player.Jump.performed += OnJumpPerformed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            IsGround = true;
    }

    public void OnJumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (obj.performed && IsGround)
        {
            _rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsGround = false;
        }
    }

    private void OnDisable()
    {
        _gameInput.Disable();
        _gameInput.Player.Jump.performed -= OnJumpPerformed;
    }

    private void FixedUpdate()
    {
        Vector2 direction = _gameInput.Player.Movement.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0f, direction.y) * speed * Time.deltaTime;
    }
}
