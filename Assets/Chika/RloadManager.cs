using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReloadManager : MonoBehaviour
{
    public InputActionReference reference;

    private void OnEnable()
    {
        reference.action.Enable();
        reference.action.performed += OnPerformed;
    }

    private void OnDisable()
    {
        reference.action.performed -= OnPerformed;
    }

    private void OnPerformed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }
}