using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

/// <summary>
/// Класс NavigationScript отвечает за управление перемещением объектов на основе кликов мыши.
/// </summary>
public class NavigationScript : MonoBehaviour
{
    [Tooltip("Слой, по которому можно кликать для перемещения.")]
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on the GameObject.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Проверка, был ли клик над UI-элементом
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;  // Прерываем выполнение метода, если клик был над UI-элементом
        }

        if (Input.GetMouseButton(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out RaycastHit hitInfo, 100, whatCanBeClickedOn))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}