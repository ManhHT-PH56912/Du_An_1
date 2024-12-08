// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Security.Cryptography;
// using System.Text;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// [System.Serializable]
// public class Account
// {
//     public string Username;
//     public string Password;
//     public int CurrentScore;
//     public int HighScore;

//     public Account(string username, string password)
//     {
//         Username = username;
//         Password = EncryptionUtility.GetMD5Hash(password);
//         CurrentScore = 0;
//         HighScore = 0;
//     }

//     public bool ValidatePassword(string password)
//     {
//         string hashedPassword = EncryptionUtility.GetMD5Hash(password);
//         return Password.Equals(hashedPassword, System.StringComparison.OrdinalIgnoreCase);
//     }
// }

// [System.Serializable]
// public class AccountData
// {
//     public List<Account> Accounts = new List<Account>();
// }

// public class AuthSystem : MonoBehaviour
// {
//     public static AuthSystem Instance { get; private set; }

//     [Header("UI Elements")]
//     [SerializeField] private TextMeshProUGUI topText;
//     [SerializeField] private TextMeshProUGUI messengerText;

//     [Header("Login")]
//     [SerializeField] private TMP_InputField userNameLogin;
//     [SerializeField] private TMP_InputField passLogin;
//     [SerializeField] private GameObject loginPage;

//     [Header("Register")]
//     [SerializeField] private TMP_InputField userRegister;
//     [SerializeField] private TMP_InputField emailRegister;
//     [SerializeField] private TMP_InputField passwordsRegister;
//     [SerializeField] private GameObject registerPage;

//     [Header("Loading")] // Added Loading UI elements
//     [SerializeField] private GameObject loadingBar;
//     [SerializeField] private Slider loadingSlider;


//     private readonly string accountsPath = "00 Game/Resources/UserAccounts/accounts.json";
//     private readonly string loginStatePath = "00 Game/Resources/UserAccounts/login_state.json";

//     private AccountData accountData;
//     private Account currentAccount;

//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }

//         accountData = new AccountData();
//         LoadAccounts();

//         string savedUsername = LoadLoginState();
//         if (!string.IsNullOrEmpty(savedUsername))
//         {
//             currentAccount = accountData.Accounts.FirstOrDefault(a => a.Username == savedUsername);
//             if (currentAccount != null)
//             {
//                 Debug.Log($"Auto-logged in as: {currentAccount.Username}");
//                 // Optionally, proceed directly to the main menu after auto-login
//                 // MainMenu.GotoMainMenu();
//             }
//         }
//     }

//     private void LoadAccounts()
//     {
//         string filePath = Path.Combine(Application.dataPath, accountsPath);
//         if (File.Exists(filePath))
//         {
//             string json = File.ReadAllText(filePath);
//             accountData = JsonUtility.FromJson<AccountData>(json);
//         }
//         else
//         {
//             Debug.LogWarning("Accounts file not found. Creating a new one.");
//             //  Consider adding default accounts here if needed.
//         }
//     }

//     private void SaveAccounts()
//     {
//         string filePath = Path.Combine(Application.dataPath, accountsPath);
//         string json = JsonUtility.ToJson(accountData, true);
//         try
//         {
//             File.WriteAllText(filePath, json);
//         }
//         catch (IOException ex)
//         {
//             Debug.LogError($"Error saving accounts: {ex.Message}");
//         }
//     }

//     private void SaveLoginState()
//     {
//         if (currentAccount != null)
//         {
//             string filePath = Path.Combine(Application.dataPath, loginStatePath);
//             string json = JsonUtility.ToJson(new { Username = currentAccount.Username });
//             try
//             {
//                 File.WriteAllText(filePath, json);
//                 Debug.Log("Login state saved.");
//             }
//             catch (IOException ex)
//             {
//                 Debug.LogError($"Error saving login state: {ex.Message}");
//             }

//         }
//     }

//     private string LoadLoginState()
//     {
//         string filePath = Path.Combine(Application.dataPath, loginStatePath);
//         if (File.Exists(filePath))
//         {
//             try
//             {
//                 string json = File.ReadAllText(filePath);
//                 var data = JsonUtility.FromJson<Dictionary<string, string>>(json);
//                 return data.ContainsKey("Username") ? data["Username"] : null;
//             }
//             catch (IOException ex)
//             {
//                 Debug.LogError($"Error loading login state: {ex.Message}");
//                 return null;
//             }
//         }
//         return null;
//     }

//     // UI Control
//     public void OpenLogin()
//     {
//         loginPage.SetActive(true);
//         registerPage.SetActive(false);
//         topText.text = "Login";
//         ClearInputFields();
//     }

//     public void OpenRegister()
//     {
//         loginPage.SetActive(false);
//         registerPage.SetActive(true);
//         topText.text = "Register";
//         ClearInputFields();
//     }

//     private void ClearInputFields()
//     {
//         userNameLogin.text = "";
//         passLogin.text = "";
//         userRegister.text = "";
//         emailRegister.text = "";
//         passwordsRegister.text = "";
//         messengerText.text = "";
//     }

//     // Login Process
//     public void LoginProcess()
//     {
//         string username = userNameLogin.text.Trim();
//         string password = passLogin.text.Trim();

//         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//         {
//             messengerText.text = "<color=red>Username or password cannot be empty!</color>";
//             return;
//         }

//         Account account = accountData.Accounts.FirstOrDefault(a => a.Username == username);
//         if (account != null && account.ValidatePassword(password))
//         {
//             currentAccount = account;
//             SaveLoginState();
//             messengerText.text = "<color=green>Login successful!</color>";
//             StartCoroutine(LoadScene()); // Load the scene after successful login
//             Debug.Log($"Logged in as: {currentAccount.Username}");
//         }
//         else
//         {
//             messengerText.text = "<color=red>Invalid username or password!</color>";
//         }
//     }

//     // Register Process
//     public void RegisterProcess()
//     {
//         string username = userRegister.text.Trim();
//         string email = emailRegister.text.Trim();
//         string password = passwordsRegister.text.Trim();

//         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
//         {
//             messengerText.text = "<color=red>All fields are required!</color>";
//             return;
//         }

//         if (accountData.Accounts.Any(a => a.Username == username))
//         {
//             messengerText.text = "<color=red>Username already exists!</color>";
//             return;
//         }

//         Account newAccount = new Account(username, password);
//         accountData.Accounts.Add(newAccount);
//         SaveAccounts();
//         messengerText.text = "<color=green>Registration successful!</color>";
//         OpenLogin();
//     }

//     // Logout
//     public void Logout()
//     {
//         currentAccount = null;
//         File.Delete(Path.Combine(Application.dataPath, loginStatePath)); //Improved error handling
//         OpenLogin();
//     }

//     private bool IsValidEmail(string email)
//     {
//         if (string.IsNullOrWhiteSpace(email)) return false;
//         email = email.Trim();
//         return email.Contains("@") && email.Contains(".") && email.Length >= 5;
//     }


//     public string GetCurrentUsername()
//     {
//         return currentAccount?.Username ?? "";
//     }

//     public int GetCurrentScore()
//     {
//         return currentAccount?.CurrentScore ?? 0;
//     }

//     public int GetHighScore()
//     {
//         return currentAccount?.HighScore ?? 0;
//     }

//     public void UpdateCurrentScore(int score)
//     {
//         if (currentAccount == null)
//         {
//             Debug.LogError("No current account is logged in. Cannot update score.");
//             return;
//         }

//         currentAccount.CurrentScore = score;
//         if (score > currentAccount.HighScore)
//         {
//             currentAccount.HighScore = score;
//         }
//         SaveAccounts();
//         Debug.Log($"Updated CurrentScore: {currentAccount.CurrentScore}, HighScore: {currentAccount.HighScore}");
//     }


//     private IEnumerator LoadScene()
//     {
//         topText.text = "Loading...";
//         loadingBar.SetActive(true);

//         float progress = 0f;
//         while (progress < 1f)
//         {
//             progress += Time.deltaTime * 2f;
//             loadingSlider.value = progress;
//             yield return null;
//         }

//         loadingBar.SetActive(false);
//         // Replace "MainMenuScene" with the actual name of your main menu scene
//         UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene"); //Loads your Main Menu Scene
//     }
// }