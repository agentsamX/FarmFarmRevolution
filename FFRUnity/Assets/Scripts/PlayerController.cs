using System;
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
    public ParticleSystem walkParticle;

    public Seed currentSeed;
    public Tasks currentTool;

    FarmPlot[] onPlot;
    public LayerMask plotLayer;

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

    private void Update()
    {
    }

    private void FixedUpdate() 
    {
        moveInput = _playerInputActions.Player_Actions.MovementAxis.ReadValue<Vector2>();

        if(moveInput != new Vector2(0,0) && !walkParticle.isPlaying)
        {
            Debug.Log("Start");
            walkParticle.Play();
        }
        else if (moveInput == new Vector2(0,0))
        {
            walkParticle.Stop();
        }

        if (_playerInputActions.Player_Actions.Sprint.IsPressed())
        {
            Playerrigidbody.velocity = moveInput * (PlayerSpeed * 2);
        }
        else
        Playerrigidbody.velocity = moveInput * PlayerSpeed;

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

    }
    public void PickupSeed(InputAction.CallbackContext context)
    {
        if (!context.started)   return;

        RaycastHit2D pickupHit = Physics2D.Raycast(transform.position, transform.right, 5f, ~(1 << 2) ); //.right gets rotated to front of character
        
        if (pickupHit.collider != null && pickupHit.collider.GetComponent<Interactable>() != null)
        {
            SeedPickupStation station = pickupHit.collider.GetComponent<SeedPickupStation>();
            //has interactible component
            if (station != null)
            {
                station.GivePlayerSeed(gameObject);
            }
            else
            {
                ToolPickupStation station1 = pickupHit.collider.GetComponent<ToolPickupStation>();
                if (station1 != null)
                {
                station1.GiveTool(this);
                }
            }
        }
        
        
        if (Physics2D.OverlapCircle(this.transform.position, 1, plotLayer) && currentSeed != null)
        {
            Physics2D.OverlapCircle(this.transform.position, 0.25f, plotLayer).GetComponent<FarmPlot>().SetSeed(currentSeed);
            CinemachineShake.Instance.ShakeCamera(20,0.25f);
            currentSeed = null;
        }
        else if (Physics2D.OverlapCircle(this.transform.position, 1, plotLayer) && Physics2D.OverlapCircle(this.transform.position, 0.25f, plotLayer).GetComponent<FarmPlot>().curSeed.GetTasks() == currentTool)
        {
            Physics2D.OverlapCircle(this.transform.position, 0.25f, plotLayer).GetComponent<FarmPlot>().DoTasks();
            CinemachineShake.Instance.ShakeCamera(20, 0.25f);
            currentSeed = null;
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position,0.25f);
    }
}
