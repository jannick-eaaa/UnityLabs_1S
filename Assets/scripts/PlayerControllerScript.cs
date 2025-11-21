using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{

    Rigidbody2D rb;
    InputAction moveAction;

    void Start() {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.MovePosition(rb.position + moveValue * Time.deltaTime * 2f);
    }
}
