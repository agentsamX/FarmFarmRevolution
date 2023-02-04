using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Playerrigidbody;
    public float PlayerSpeed;
    private PlayerInputActions _playerInputActions;
    private Vector2 moveInput;
[SerializeField]
    public Seed currentSeed;
    
    private void Awake() 
    {
        _playerInputActions = new PlayerInputActions();
        Playerrigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        _playerInputActions.Player_Actions.Enable();
        _playerInputActions.Player_Actions.PickupSeed.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void FixedUpdate() 
    {
        moveInput = _playerInputActions.Player_Actions.MovementAxis.ReadValue<Vector2>();
        Playerrigidbody.velocity = moveInput;

        switch (moveInput) //rotates the player to face the right way
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
        Debug.Log(currentSeed);
    }
    public void PickupSeed(InputAction.CallbackContext context)
    {
        RaycastHit2D pickupHit;
        pickupHit = Physics2D.Raycast(transform.position, transform.right, 1.5f); //.right gets rotated to front of character
        if (pickupHit.collider.GetComponent<Interactable>() != null)
        {
            SeedPickupStation station = pickupHit.collider.GetComponent<SeedPickupStation>();
            //has interactible component
            if (station != null)
            {
                station.GivePlayerSeed(gameObject);
            }
        }
    }

    public Seed GetCurrentSeed()
    {
        return currentSeed;
    }

    public void SetCurrentSeed(Seed newSeed)
    {
        currentSeed = newSeed;
    }


    void OnDisable() 
    {
          _playerInputActions.Player_Actions.Disable();
    }

}
