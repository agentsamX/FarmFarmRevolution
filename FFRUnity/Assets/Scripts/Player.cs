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

        switch (moveInput)
        {
            case Vector2 v when v.Equals(Vector2.down):
            transform.localEulerAngles = new Vector3(0,0,270);
            break;

            case Vector2 v when v.Equals(Vector2.up):
            transform.localEulerAngles = new Vector3(0,0,90);
            break;
            case Vector2 v when v.Equals(Vector2.left):
            transform.localEulerAngles = new Vector3(0,0,180);
            break;
             case Vector2 v when v.Equals(Vector2.right):
            transform.localEulerAngles = new Vector3(0,0,0);
            break;
        }

    }

    void OnDisable() 
    {
          _movementActions.Player_Actions.Disable();
    }

}
