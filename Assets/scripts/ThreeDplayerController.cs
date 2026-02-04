using UnityEngine;
using UnityEngine.InputSystem;

public class ThreeDplayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;

    [SerializeField]
    Transform eyes;

    Rigidbody rb;

    [SerializeField]
    float sensitivity = 0.1f;
    Vector2 eyesRotation;

    [SerializeField]
    float moveSpeed = 1f;

    [SerializeField]
    float jumpForce = 1f;
    bool isJumping = false;
    bool wasJumpPressed = false;
    
    Vector3 moveDirection;

    Vector3 reusableVector;

    Vector3 initialPlayerPosition;

    private void Start()
    {
        initialPlayerPosition = transform.position;
        initialPlayerPosition.y += 0.01f;
        rb = GetComponent<Rigidbody>();
        // Frys rotation for at undslippe ikke-ønsket fysik-interaktion
        rb.freezeRotation = true;

        // Move to proper place
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // --

        // Input bindings
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        Vector2 lookValue = lookAction.ReadValue<Vector2>();
        Vector2 moveDir = moveAction.ReadValue<Vector2>();
        moveDirection.x = moveDir.x;

        // Y til Z, mus er vector2, men movement er vector3
        // Så, Y oversættes til Z
        moveDirection.z = moveDir.y;
        eyesRotation += lookValue * sensitivity;
        eyes.rotation = Quaternion.Euler(-eyesRotation.y, eyesRotation.x, 0f);

        if (!wasJumpPressed && jumpAction.IsPressed()){
            wasJumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        // Forward/Backward Z relative to camera
        // Når vi bevæger os, vil vi gerne gøre det relativt til
        // hvor spilleren (kameraet) kigger hen (forward vector, blå pil i Editor)
        reusableVector = eyes.forward;
        reusableVector.y = 0;           // W (keyboard 1) -> controller (0 ... 1)
        Vector3 move = reusableVector * moveDirection.z * moveSpeed * Time.fixedDeltaTime;

        // Left/Right X relative to camera
        // Same as above
        reusableVector = eyes.right;
        reusableVector.y = 0;
        move += reusableVector * moveDirection.x * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + move);

        if (!isJumping && wasJumpPressed){
            isJumping = true;
            rb.linearVelocity += Vector3.up * jumpForce;
        }
    }

    void resetJump() {
        isJumping = false;
        wasJumpPressed = false;
    }

    void handleDeath() {
        rb.Move(initialPlayerPosition, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground"){
            resetJump();
        } else if (collision.gameObject.tag == "death"){
            resetJump();
            handleDeath();
        }
    }
}
