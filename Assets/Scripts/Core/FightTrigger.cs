using UnityEngine;

namespace Core
{
    /// <summary>
    /// Класс FightTrigger инициирует фазу боя при столкновении с игроком.
    /// </summary>
    public class FightTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerBehaviour>();
            if (player != null)
            {
                GameManager.FightPhase.BallPhase();
                gameObject.SetActive(false);
            }
        }
    }
}