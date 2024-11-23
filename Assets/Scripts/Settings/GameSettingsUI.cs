using TMPro;
using UnityEngine;
using System.Collections.Generic;
using Core;

namespace Settings
{
    public class GameSettingsUI : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private TMP_InputField ballSpeed;
        [SerializeField] private TMP_InputField minDelayInput;
        [SerializeField] private TMP_InputField maxDelayInput;
        [SerializeField] private TMP_InputField wallMinMoveDelayInput;
        [SerializeField] private TMP_InputField wallMaxMoveDelayInput;
        [SerializeField] private TMP_InputField delayBetweenDestroyingBallsInput;
        [SerializeField] private TMP_InputField spaceBetweenBallsInput;
        [SerializeField] private TMP_InputField numberOfBallsInput;
        [SerializeField] private TMP_InputField destroyBallsCountInput;
        [SerializeField] private TMP_InputField spawnWallsCountInput;

        private Dictionary<TMP_InputField, System.Action<string>> _updateActions;

        private void Start()
        {
            // Заполняем поля значениями из GameSettings
            ballSpeed.text = gameSettings.wallOfBallsSpeed.ToString();
            minDelayInput.text = gameSettings.minDelayBetweenSpawnWall.ToString();
            maxDelayInput.text = gameSettings.maxDelayBetweenSpawnWall.ToString();
            wallMinMoveDelayInput.text = gameSettings.wallMinMoveDelay.ToString();
            wallMaxMoveDelayInput.text = gameSettings.wallMaxMoveDelay.ToString();
            delayBetweenDestroyingBallsInput.text = gameSettings.delayBetweenDestroyingBalls.ToString();
            spaceBetweenBallsInput.text = gameSettings.spaceBetweenBalls.ToString();
            numberOfBallsInput.text = gameSettings.numberOfBalls.ToString();
            destroyBallsCountInput.text = gameSettings.destroyBallsCount.ToString();
            spawnWallsCountInput.text = gameSettings.spawnWallsCount.ToString();

            // Инициализируем словарь действий
            _updateActions = new Dictionary<TMP_InputField, System.Action<string>>
            {
                { ballSpeed, value => UpdateFloat(value, v => gameSettings.wallOfBallsSpeed = v) },
                { minDelayInput, value => UpdateInt(value, v => gameSettings.minDelayBetweenSpawnWall = v) },
                { maxDelayInput, value => UpdateInt(value, v => gameSettings.maxDelayBetweenSpawnWall = v) },
                { wallMinMoveDelayInput, value => UpdateInt(value, v => gameSettings.wallMinMoveDelay = v) },
                { wallMaxMoveDelayInput, value => UpdateInt(value, v => gameSettings.wallMaxMoveDelay = v) },
                { delayBetweenDestroyingBallsInput, value => UpdateFloat(value, v => gameSettings.delayBetweenDestroyingBalls = v) },
                { spaceBetweenBallsInput, value => UpdateFloat(value, v => gameSettings.spaceBetweenBalls = v) },
                { numberOfBallsInput, value => UpdateInt(value, v => gameSettings.numberOfBalls = v) },
                { destroyBallsCountInput, value => UpdateInt(value, v => gameSettings.destroyBallsCount = v) },
                { spawnWallsCountInput, value => UpdateFloat(value, v => gameSettings.spawnWallsCount = v) }
            };
        }

        private void UpdateFloat(string value, System.Action<float> updateAction)
        {
            if (float.TryParse(value, out float result))
            {
                updateAction(result);
            }
        }

        private void UpdateInt(string value, System.Action<int> updateAction)
        {
            if (int.TryParse(value, out int result))
            {
                updateAction(result);
            }
        }

        public void ApplySettings()
        {
            foreach (var inputField in _updateActions.Keys)
            {
                _updateActions[inputField](inputField.text);
            }

            FireWavesManager.Instance?.UpdateSettings(gameSettings);
        }
    }
}
