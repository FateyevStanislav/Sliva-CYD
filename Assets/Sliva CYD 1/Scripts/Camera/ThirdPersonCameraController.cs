using UnityEngine;
using SlivaCYD1.Player;

namespace SlivaCYD1.Camera
{
    public class ThirdPersonCameraController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform followTarget;
        [SerializeField] private PlayerInputReader playerInputReader;

        [Header("Orbit")]
        [SerializeField] private float distance = 4f;
        [SerializeField] private float yawSpeed = 120f;
        [SerializeField] private float pitchSpeed = 90f;
        [SerializeField] private float minPitch = -30f;
        [SerializeField] private float maxPitch = 60f;

        private float yaw;
        private float pitch = 20f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            var angles = transform.eulerAngles;
            yaw = angles.y;
            pitch = angles.x;
        }

        private void LateUpdate()
        {
            UpdateRotation();
            UpdatePosition();
        }

        private void UpdateRotation()
        {
            var lookInput = playerInputReader.LookInput;

            yaw += lookInput.x * yawSpeed * Time.deltaTime;
            pitch -= lookInput.y * pitchSpeed * Time.deltaTime;

            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }

        private void UpdatePosition()
        {
            var rotation = Quaternion.Euler(pitch, yaw, 0f);
            var offset = rotation * new Vector3(0f, 0f, -distance);

            transform.position = followTarget.position + offset;
            transform.rotation = rotation;
        }
    }
}