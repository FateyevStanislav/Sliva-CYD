using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SlivaCYD1.Player.Stamina
{
    [DefaultExecutionOrder(100)]
    public class PlayerStaminaUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerStaminaController playerStaminaController;
        [SerializeField] private Slider staminaSlider;
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Fade")]
        [SerializeField] private float visibleDelay = 1.5f;
        [SerializeField] private float fadeDuration = 0.4f;

        private Coroutine fadeCoroutine;

        private void Awake()
        {
            canvasGroup ??= GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            playerStaminaController.Model.StaminaChanged += OnStaminaChanged;
            SyncImmediate();
        }

        private void OnDisable()
        {
            playerStaminaController.Model.StaminaChanged -= OnStaminaChanged;
            fadeCoroutine = null;
        }

        private void SyncImmediate()
        {
            staminaSlider.maxValue = playerStaminaController.Model.MaxStamina;
            staminaSlider.value = playerStaminaController.Model.CurrentStamina;
        }

        private void OnStaminaChanged(float currentStamina)
        {
            staminaSlider.value = currentStamina;
            ShowImmediately();
            RestartFadeCoroutine();
        }

        private void ShowImmediately()
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            canvasGroup.alpha = 1f;
        }

        private void RestartFadeCoroutine()
        {
            fadeCoroutine = StartCoroutine(FadeOutRoutine());
        }

        private IEnumerator FadeOutRoutine()
        {
            yield return new WaitForSeconds(visibleDelay);

            var elapsed = 0f;
            var startAlpha = canvasGroup.alpha;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsed / fadeDuration);
                yield return null;
            }

            canvasGroup.alpha = 0f;
            fadeCoroutine = null;
        }
    }
}