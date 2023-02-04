using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private Rigidbody2D Playerrigidbody;
    public float PlayerSpeed;
    private Move _movementActions;
    private Vector2 moveInput;
    
    private void Awake() 
    {
        _movementActions = new Move();
        Playerrigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        _movementActions.Player_Actions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void FixedUpdate() 
    {
        moveInput = _movementActions.Player_Actions.MovementAxis.ReadValue<Vector2>();
        Playerrigidbody.velocity = moveInput;
    }

    void OnDisable() 
    {
          _movementActions.Player_Actions.Disable();
    }

}
