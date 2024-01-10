using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBehaviour>() != null)
        {
            GameManager.FightPhase.BallPhase();
            Destroy(this);
        }
    }
}
