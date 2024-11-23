using TMPro;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Класс SettingsButton отвечает за управление панелью настроек и отображением текста кнопки.
    /// </summary>
    public class SettingsButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private GameObject settingsPanel;

        private void Start()
        {
            if (buttonText == null)
            {
                Debug.LogError("TextMeshProUGUI component is missing.");
            }

            if (settingsPanel == null)
            {
                Debug.LogError("Settings panel GameObject is missing.");
            }
        }

        /// <summary>
        /// Открывает панель настроек.
        /// </summary>
        private void OpenSettingsPanel()
        {
            settingsPanel.SetActive(true);
            buttonText.text = "<";
        }

        /// <summary>
        /// Закрывает панель настроек.
        /// </summary>
        private void CloseSettingsPanel()
        {
            settingsPanel.SetActive(false);
            buttonText.text = ">";
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки.
        /// </summary>
        public void OnClick()
        {
            if (settingsPanel.activeSelf)
            {
                CloseSettingsPanel();
            }
            else
            {
                OpenSettingsPanel();
            }
        }
    }
}