using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Light flashLight;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        flashLight = GetComponentInChildren<Light>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            flashLight.enabled = !flashLight.enabled;
        }
    }
}
