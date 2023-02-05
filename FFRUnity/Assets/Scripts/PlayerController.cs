using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    public SpriteRenderer playerSprite;
   
    [SerializeField]
    private TextMeshProUGUI InteractHint;

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
     //   animator = GetComponent<Animator>();
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
          animator.SetFloat("X_Velocity",  Playerrigidbody.velocity.magnitude);

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
        
        RaycastHit2D pickupHit = Physics2D.Raycast(transform.position, transform.right, 5f, ~(1 << 2) );
        //update hint
         
        if (pickupHit.collider.TryGetComponent<SeedPickupStation>(out SeedPickupStation seedStation))
        {
           // InteractHint.text = seedStation.HintText;
        }
        else if (pickupHit.collider.TryGetComponent<ToolPickupStation>(out ToolPickupStation toolPickupStation))
        {
            InteractHint.text = toolPickupStation.Name;
        }
        else if (pickupHit.collider.TryGetComponent<FarmPlot>(out FarmPlot farmplot))
        {
            if (farmplot.curSeed == null)
            {
                InteractHint.text = "Press E to plant";
            }
            else if (farmplot.curSeed.GetTasks() == Seed.Tasks.Fertilize && currentTool is Fertilizer) 
            {
                 InteractHint.text = "Press E to Fertilize";
            }
            else if (farmplot.curSeed.GetTasks() == Seed.Tasks.Water && currentTool is Watering) 
            {
                InteractHint.text = "Press E to Water";
            }
             else if (farmplot.curSeed.GetTasks() == Seed.Tasks.Till && currentTool is Till) 
            {
                InteractHint.text = "Press E to Till";
            }
        }
        else
        {
            InteractHint.text = "";
        }
      

        if (moveInput.x <= -0.01f)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }
       
        Debug.Log(currentSeed);
        Debug.Log(currentTool);

    }
    public void PickupSeed(InputAction.CallbackContext context)
    {
        if (!context.started)   return;

        RaycastHit2D pickupHit = Physics2D.Raycast(transform.position, transform.right, 5f, ~(1 << 2) ); //.right gets rotated to front of character
        
        if (pickupHit.collider.TryGetComponent<SeedPickupStation>(out SeedPickupStation seedStation))
        {
            seedStation.GivePlayerSeed(gameObject);
        }
        else if (pickupHit.collider.TryGetComponent<ToolPickupStation>(out ToolPickupStation toolPickupStation))
        {
            toolPickupStation.GiveTool(this);
        }
        else if (pickupHit.collider.TryGetComponent<FarmPlot>(out FarmPlot farmplot))
        {
            if (farmplot.curSeed == null)
            {
                animator.SetTrigger("PlantingTrigger");
                farmplot.SetSeed(currentSeed);
                currentSeed = null; //Erase seed from player inv
            }
            else
            {
                Seed seed = farmplot.curSeed;
                 if (seed.GetTasks() == Seed.Tasks.Fertilize && currentTool is Fertilizer)
                 {
                    animator.SetTrigger("FertilizeTrigger");
                    seed.CompleteTask();
                 }
                 else if (seed.GetTasks() == Seed.Tasks.Water && currentTool is Watering)
                 {
                    animator.SetTrigger("WateringTrigger");
                    seed.CompleteTask();
                 }
                 else if(seed.GetTasks() == Seed.Tasks.Till && currentTool is Till)
                 {
                    animator.SetTrigger("FertilizeTrigger");
                    seed.CompleteTask();
                 }
            }
            

        }

        /*
        if (pickupHit.collider != null && pickupHit.collider.GetComponent<Interactable>() != null)
        {
            SeedPickupStation station = pickupHit.collider.GetComponent<SeedPickupStation>();
            FarmPlot plot = pickupHit.collider.GetComponent<FarmPlot>();
            ToolPickupStation toolstation = pickupHit.collider.GetComponent<ToolPickupStation>();
            //has interactible component
            if (station != null)
            {
                station.GivePlayerSeed(gameObject);
            }    
            else if (toolstation != null)
            {
                toolstation.GiveTool(this);
            }
            else if(plot != null)
            {
                  plot.SetSeed(currentSeed);
                  currentSeed = null; //remove player seed
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

 public static class Extensions
 {
     public static bool TryGetComponent<T>(GameObject obj, T result) where T : Component
     {
         return (result = obj.GetComponent<T>()) != null;
     }
 }