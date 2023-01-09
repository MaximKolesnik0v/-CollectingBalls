using PlayFab;
using PlayFab.ClientModels;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    [SerializeField] private InputField _userNameField;
    [SerializeField] private InputField _userPasswordField;
    [SerializeField] private Button _registrationButton;
    [SerializeField] private Text _createError;

    private string _username;
    private string _pass;

    private void Awake()
    {
        _userNameField.onValueChanged.AddListener(SetUsername);
        _userPasswordField.onValueChanged.AddListener(SetUserPassword);
        _registrationButton.onClick.AddListener(SignInAccount);
    }

    public void SetUsername(string username)
    {
        _username = username;
    }

    public void SetUserPassword(string pass)
    {
        _pass = pass;
    }

    public void SignInAccount()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _pass
        }, result =>
        {
            _createError.gameObject.SetActive(false);
            Debug.Log($"User enter: { result.LastLoginTime}");
        }, error =>
        {
            _createError.gameObject.SetActive(true);
            _createError.text = error.ErrorDetails.FirstOrDefault().Value.FirstOrDefault() ?? "";
            Debug.Log(error);
        });
    }
}
