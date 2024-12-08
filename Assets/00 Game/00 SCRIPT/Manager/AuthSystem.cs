using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Account
{
    public string Username;
    public string Password;
    public string Email;
    public int CurrentScore;
    public int HighScore;

    public Account(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = EncryptionUtility.GetMD5Hash(password);
        CurrentScore = 0;
        HighScore = 0;
    }

    public bool ValidatePassword(string password)
    {
        string hashedPassword = EncryptionUtility.GetMD5Hash(password);
        return Password.Equals(hashedPassword, System.StringComparison.OrdinalIgnoreCase);
    }
}

[System.Serializable]
public class LoginState
{
    public string Username = "";
    public bool IsLoggedIn = false;
}

[System.Serializable]
public class AccountData
{
    public List<Account> Accounts = new();
}

public class AuthSystem : MonoBehaviour
{
    public static AuthSystem Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI topText;
    [SerializeField] private TextMeshProUGUI messengerText;

    [Header("Login")]
    [SerializeField] private TMP_InputField userNameLogin;
    [SerializeField] private TMP_InputField passLogin;
    [SerializeField] private GameObject loginPage;

    [Header("Register")]
    [SerializeField] private TMP_InputField userRegister;
    [SerializeField] private TMP_InputField emailRegister;
    [SerializeField] private TMP_InputField passwordsRegister;
    [SerializeField] private GameObject registerPage;

    [Header("Loading")]
    [SerializeField] private GameObject loadingBar;
    [SerializeField] private Slider loadingSlider;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject LoginScreen;

    private string accountsPath;
    private string loginStatePath;
    private AccountData accountData;
    private Account currentAccount;
    private LoginState loginState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Correct Path Handling: Use Application.persistentDataPath consistently.
        accountsPath = Path.Combine(Application.dataPath, "01_DataGame", "accounts.json"); 
        loginStatePath = Path.Combine(Application.dataPath, "01_DataGame", "login_state.json");
        accountData = new AccountData();
        LoadAccounts();
        LoadLoginState();

        // Tự động đăng nhập nếu trạng thái đúng
        if (loginState.IsLoggedIn && !string.IsNullOrEmpty(loginState.Username))
        {
            currentAccount = accountData.Accounts.FirstOrDefault(a => a.Username == loginState.Username);
            if (currentAccount != null)
            {
                Debug.Log($"Auto-logged in as: {currentAccount.Username}");
                ShowMainMenu();
            }
        }
        else
        {
            ShowLogin();
        }
    }

    void Start()
    {
        Debug.Log(accountsPath);
        Debug.Log(loginStatePath);
    }

    private void LoadAccounts()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(accountsPath)); // Ensure directory exists

        if (File.Exists(accountsPath))
        {
            string json = File.ReadAllText(accountsPath);
            accountData = JsonUtility.FromJson<AccountData>(json);
        }
        else
        {
            Debug.LogWarning("Accounts file not found. Creating a new one.");
        }
    }

    private void SaveAccounts()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(accountsPath)); // Ensure directory exists
        string json = JsonUtility.ToJson(accountData, true);
        try
        {
            File.WriteAllText(accountsPath, json);
        }
        catch (IOException ex)
        {
            Debug.LogError($"Error saving accounts: {ex.Message}");
        }
    }

    private void SaveLoginState()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(loginStatePath)); // Ensure directory exists

        string json = JsonUtility.ToJson(loginState);
        try
        {
            File.WriteAllText(loginStatePath, json);
            Debug.Log("Login state saved.");
        }
        catch (IOException ex)
        {
            Debug.LogError($"Error saving login state: {ex.Message}");
        }
    }


    private void LoadLoginState()
    {
        if (File.Exists(loginStatePath))
        {
            try
            {
                string json = File.ReadAllText(loginStatePath);
                loginState = JsonUtility.FromJson<LoginState>(json);
            }
            catch (IOException ex)
            {
                Debug.LogError($"Error loading login state: {ex.Message}");
                loginState = new LoginState(); // Initialize if loading fails
            }

        }
        else
        {
            loginState = new LoginState(); // Initialize if file doesn't exist
        }
    }

    public void OpenLogin()
    {
        mainMenu.SetActive(false);
        loginPage.SetActive(true);
        registerPage.SetActive(false);
        topText.text = "Login";
        ClearInputFields();
    }


    public void OpenRegister()
    {
        loginPage.SetActive(false);
        registerPage.SetActive(true);
        topText.text = "Register";
        ClearInputFields();
    }

    private void ClearInputFields()
    {
        userNameLogin.text = "";
        passLogin.text = "";
        userRegister.text = "";
        emailRegister.text = "";
        passwordsRegister.text = "";
        messengerText.text = "";
    }

    public void LoginProcess()
    {
        string input = userNameLogin.text.Trim();
        string password = passLogin.text.Trim();

        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(password))
        {
            messengerText.text = "<color=red>Username/email or password cannot be empty!</color>";
            return;
        }

        Account account = accountData.Accounts.FirstOrDefault(a =>
            a.Username.Equals(input, System.StringComparison.OrdinalIgnoreCase) ||
            a.Email.Equals(input, System.StringComparison.OrdinalIgnoreCase));

        if (account != null && account.ValidatePassword(password))
        {
            currentAccount = account;
            loginState.Username = currentAccount.Username;
            loginState.IsLoggedIn = true;
            SaveLoginState();


            ShowMainMenu();

            Debug.Log($"Logged in as: {currentAccount.Username}");
        }
        else
        {
            messengerText.text = "<color=red>Invalid username/email or password.</color>";
        }
    }


    public void RegisterProcess()
    {
        string username = userRegister.text.Trim();
        string email = emailRegister.text.Trim();
        string password = passwordsRegister.text.Trim();


        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            messengerText.text = "<color=red>All fields are required!</color>";
            return;
        }

        if (accountData.Accounts.Any(a =>
            a.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase) ||
            a.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase)))

        {
            messengerText.text = "<color=red>Username or email already exists!</color>";
            return;
        }


        Account newAccount = new Account(username, email, password);
        accountData.Accounts.Add(newAccount);
        SaveAccounts();

        messengerText.text = "<color=green>Registration successful! Please log in.</color>";

        OpenLogin();
    }



    private void ShowLogin()
    {
        LoginScreen.SetActive(true);
        mainMenu.SetActive(false);
        loginPage.SetActive(true);
        registerPage.SetActive(false);

        topText.text = "Login";
    }

    private void ShowMainMenu()
    {
        LoginScreen.SetActive(false);
        mainMenu.SetActive(true);
        loginPage.SetActive(false);
        registerPage.SetActive(false);
    }

    public void LogOut()
    {
        loginState.IsLoggedIn = false;
        loginState.Username = "";
        SaveLoginState();

        currentAccount = null; // Reset current account

        ShowLogin();

        Debug.Log("Logged out.");
    }

    public Account GetCurrentAccount()
    {
        return currentAccount;
    }
}
