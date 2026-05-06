using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportActivator : MonoBehaviour
{
    [SerializeField] private GameObject teleportInteractor;
    [SerializeField] private InputActionReference teleportModeActivate;
    [SerializeField] private InputActionReference teleportModeCancel;

    void OnEnable()
    {
        teleportModeActivate.action.performed += ShowTeleport;
        teleportModeCancel.action.performed += HideTeleport;
        teleportModeActivate.action.canceled += HideTeleport;
    }

    void OnDisable()
    {
        teleportModeActivate.action.performed -= ShowTeleport;
        teleportModeCancel.action.performed -= HideTeleport;
        teleportModeActivate.action.canceled -= HideTeleport;
    }

    void Start()
    {
        teleportInteractor.SetActive(false);
    }

    private void ShowTeleport(InputAction.CallbackContext ctx)
    {
        teleportInteractor.SetActive(true);
    }

    private void HideTeleport(InputAction.CallbackContext ctx)
    {
        teleportInteractor.SetActive(false);
    }
}