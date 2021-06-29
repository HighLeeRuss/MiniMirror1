using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Epic.OnlineServices;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Logging;
using Epic.OnlineServices.Platform;

public class EOSSDKComponent : MonoBehaviour
{
    // Set these values as appropriate. For more information, see the Developer Portal documentation.
    //AUTH REQUIRED - CUSTOM VARS
    public string m_ProductName = "EOSSDKUnityAttempt";
    public string m_ProductVersion = "1.0";
    public string m_ProductId = "154ec01ffb2044baa76940bde209de4e";
    public string m_SandboxId = "d48e158eca9946b6b17dfe1951ef52ed";
    public string m_DeploymentId = "fb33c144823d45e698bfc0c30555085b";
    public string m_ClientId = "xyza7891wq6tnT6YxDvcmvMiwY3idFvO";
    public string m_ClientSecret = "pcv/tAeSGWSd6QhKFhifgommKt4NnYrV2klYpzIjb7A";

    public LoginCredentialType m_LoginCredentialType = LoginCredentialType.AccountPortal;

    /// These fields correspond to <see cref="Credentials.Id" /> and <see cref="Credentials.Token" />,
    /// and their use differs based on the login type. For more information, see <see cref="Credentials" />
    /// and the Auth Interface documentation.
    public string m_LoginCredentialId = null;

    public string m_LoginCredentialToken = null;

    private static PlatformInterface s_PlatformInterface;
    private const float c_PlatformTickInterval = 0.1f;
    private float m_PlatformTickTimer = 0f;

    // If we're in editor, we should dynamically load and unload the SDK between play sessions.
    // This allows us to initialize the SDK each time the game is run in editor.
#if UNITY_EDITOR
    [DllImport("Kernel32.dll")]
    private static extern IntPtr LoadLibrary(string lpLibFileName);

    [DllImport("Kernel32.dll")]
    private static extern int FreeLibrary(IntPtr hLibModule);

    [DllImport("Kernel32.dll")]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    private IntPtr m_LibraryPointer;
#endif

    private void Awake()
    {
#if UNITY_EDITOR
        var libraryPath = $"Assets/{Config.LibraryName}";

        m_LibraryPointer = LoadLibrary(libraryPath);
        if (m_LibraryPointer == IntPtr.Zero)
        {
            throw new Exception($"Failed to load library {libraryPath}");
        }

        Bindings.Hook(m_LibraryPointer, GetProcAddress);
#endif
    }

    private void OnApplicationQuit()
    {
        if (s_PlatformInterface != null)
        {
            s_PlatformInterface.Release();
            s_PlatformInterface = null;
            PlatformInterface.Shutdown();
        }

#if UNITY_EDITOR
        if (m_LibraryPointer != IntPtr.Zero)
        {
            Bindings.Unhook();

            // Free until the module ref count is 0
            while (FreeLibrary(m_LibraryPointer) != 0)
            {
            }

            m_LibraryPointer = IntPtr.Zero;
        }
#endif
    }

    void Start()
    {
        var initializeOptions = new InitializeOptions()
        {
            ProductName = m_ProductName,
            ProductVersion = m_ProductVersion
        };

        var initializeResult = PlatformInterface.Initialize(initializeOptions);
        if (initializeResult != Result.Success)
        {
            throw new Exception("Failed to initialize platform: " + initializeResult);
        }

        // The SDK outputs lots of information that is useful for debugging.
        // Make sure to set up the logging interface as early as possible: after initializing.
        LoggingInterface.SetLogLevel(LogCategory.AllCategories, LogLevel.VeryVerbose);
        LoggingInterface.SetCallback((LogMessage logMessage) => Debug.Log(logMessage.Message));

        var options = new Options()
        {
            ProductId = m_ProductId,
            SandboxId = m_SandboxId,
            DeploymentId = m_DeploymentId,
            ClientCredentials = new ClientCredentials()
            {
                ClientId = m_ClientId,
                ClientSecret = m_ClientSecret
            }
        };

        s_PlatformInterface = PlatformInterface.Create(options);
        if (s_PlatformInterface == null)
        {
            throw new Exception("Failed to create platform");
        }

        var loginOptions = new LoginOptions()
        {
            Credentials = new Credentials()
            {
                Type = m_LoginCredentialType,
                Id = m_LoginCredentialId,
                Token = m_LoginCredentialToken
            }
        };

        // Ensure platform tick is called on an interval, or this will not callback.
        s_PlatformInterface.GetAuthInterface().Login(loginOptions, null, (LoginCallbackInfo loginCallbackInfo) =>
        {
            if (loginCallbackInfo.ResultCode == Result.Success)
            {
                Debug.Log("Login succeeded");
            }

            else if (Common.IsOperationComplete(loginCallbackInfo.ResultCode))
            {
                Debug.Log("Login failed: " + loginCallbackInfo.ResultCode);
            }
        });
    }

    // Calling tick on a regular interval is required for callbacks to work.
    private void FixedUpdate()
    {
        if (s_PlatformInterface != null)
        {
            m_PlatformTickTimer += Time.deltaTime;

            if (m_PlatformTickTimer >= c_PlatformTickInterval)
            {
                m_PlatformTickTimer = 0;
                s_PlatformInterface.Tick();
            }
        }
    }
}
