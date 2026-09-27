using UnityEngine;

public class Player : KitchenObjectHolder
{
    public static Player Instance { get; private set; }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking = false;
    private BaseCounter selectedCounter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleInteraction();
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        selectedCounter?.Interact(this);
    }

    private void HandleMovement()
    {
        Vector3 direction = gameInput.GetMovementDirectionVector();

        isWalking = direction != Vector3.zero;
        transform.position += direction * moveSpeed * Time.fixedDeltaTime;

        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(
                transform.forward,
                direction,
                Time.fixedDeltaTime * rotateSpeed);
        }
    }

    private void HandleInteraction()
    {
        Vector3 interactionOrigin = transform.position + Vector3.up;

        if (Physics.Raycast(
            interactionOrigin,
            transform.forward,
            out RaycastHit hitInfo,
            2f,
            counterLayerMask))
        {
            if (hitInfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    public void SetSelectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();
            counter?.SelectCounter();
            selectedCounter = counter;
        }
    }

    public bool IsWalking
    {
        get
        {
            return isWalking;
        }
    }
}