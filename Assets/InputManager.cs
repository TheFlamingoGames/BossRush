using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;    
    PlayerInput playerInput;

    //Player Movement
    public event EventHandler OnDashPressed;
    public event EventHandler OnAttackPressed;
    public event EventHandler OnParryPressed;
    public event EventHandler OnInteractPressed;
    public event EventHandler OnArrowPressed;
    Vector2 lStickInput;

    //Technical Inputs
    public event EventHandler OnPausePressed;
    public event EventHandler OnEnableCameraPressed;
    public event EventHandler OnEnableCameraReleased;
    Vector2 rStickInput;
    Vector2 mousePos;

    //Menu Handling
    public event EventHandler OnOkayPressed;
    public event EventHandler OnBackPressed;
    Vector2 menuInput;

    public void Awake()
    {
        CheckForNewInstance();
        LoadInputs();
    }
    public void Start()
    {
        GameManager.instance.OnGameStateChange += ChangeInputListeners;
    }

    void CheckForNewInstance()
    {        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void LoadInputs()
    {
        playerInput = new PlayerInput();

        //Player Movement
        playerInput.PlayerMovement.Move.performed += ctx => lStickInput = ctx.ReadValue<Vector2>();
        playerInput.PlayerMovement.Move.canceled += ctx => lStickInput = Vector2.zero;

        playerInput.PlayerMovement.Dash.performed += ctx => OnDashPressed?.Invoke(this, EventArgs.Empty);
        playerInput.PlayerMovement.Attack.performed += ctx => OnAttackPressed?.Invoke(this, EventArgs.Empty);
        playerInput.PlayerMovement.Parry.performed += ctx => OnParryPressed?.Invoke(this, EventArgs.Empty);
        playerInput.PlayerMovement.Interact.performed += ctx => OnInteractPressed?.Invoke(this, EventArgs.Empty);
        playerInput.PlayerMovement.Arrow.performed += ctx => OnArrowPressed?.Invoke(this, EventArgs.Empty);

        //Camera Movement
        playerInput.TechnicalInputs.CameraMovement.performed += ctx => rStickInput = ctx.ReadValue<Vector2>();
        playerInput.TechnicalInputs.CameraMovement.canceled += ctx => rStickInput = Vector2.zero;
        playerInput.TechnicalInputs.MouseCameraMovement.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        playerInput.TechnicalInputs.MouseCameraMovement.canceled += ctx => mousePos = Vector2.zero;

        playerInput.TechnicalInputs.Pause.performed += ctx => OnPausePressed?.Invoke(this, EventArgs.Empty);
        playerInput.TechnicalInputs.EnableCamera.performed += ctx => OnEnableCameraPressed?.Invoke(this, EventArgs.Empty);
        playerInput.TechnicalInputs.EnableCamera.canceled += ctx => OnEnableCameraReleased?.Invoke(this, EventArgs.Empty);

        //Menu Inputs
        playerInput.MenuHandling.Move.performed += ctx => menuInput = ctx.ReadValue<Vector2>();
        playerInput.MenuHandling.Move.canceled += ctx => menuInput = Vector2.zero;

        playerInput.MenuHandling.Okay.performed += ctx => OnOkayPressed?.Invoke(this, EventArgs.Empty);
        playerInput.MenuHandling.Back.performed += ctx => OnBackPressed?.Invoke(this, EventArgs.Empty);
    }

    public void ChangeInputListeners(object sender, GameManager.OnGameStateChangeArgs e)
    {
        switch(e.gs)
        {
            case GameManager.GameState.NULL:
                playerInput.PlayerMovement.Enable();
                playerInput.TechnicalInputs.Enable();
                playerInput.MenuHandling.Disable();
                break;

            case GameManager.GameState.MENU:
                playerInput.PlayerMovement.Disable();
                playerInput.TechnicalInputs.Disable();
                playerInput.MenuHandling.Enable();
                break;

            case GameManager.GameState.PAUSED:
                playerInput.PlayerMovement.Disable();
                playerInput.TechnicalInputs.Disable();
                playerInput.MenuHandling.Enable();
                break;

            case GameManager.GameState.DEATH:
                playerInput.PlayerMovement.Disable();
                playerInput.TechnicalInputs.Disable();
                playerInput.MenuHandling.Enable();
                break;

            case GameManager.GameState.PLAY:
                playerInput.PlayerMovement.Enable();
                playerInput.TechnicalInputs.Enable();
                playerInput.MenuHandling.Disable();
                break;

            default:
                playerInput.PlayerMovement.Enable();
                playerInput.TechnicalInputs.Enable();
                playerInput.MenuHandling.Disable();
                break;
        }        
        Debug.Log(e.gs);
    }

    public Vector2 GetLStickInput()
    {
        return lStickInput;
    }

    public Vector2 GetRStickInput()
    {
        return rStickInput;
    }

    public Vector2 GetMousePos()
    {
        return mousePos;
    }

    public Vector2 GetMenuInput()
    {
        return menuInput;
    }
}
