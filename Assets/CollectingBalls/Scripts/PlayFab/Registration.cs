using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    [SerializeField] private InputField _userEmailField;
    [SerializeField] private InputField _userNameField;
    [SerializeField] private InputField _userPasswordField;
    [SerializeField] private Button _registrationButton;
    [SerializeField] private Text _createError;

    private string _username;
    private string _mail;
    private string _pass;

    private void Awake()
    {
        _userNameField.onValueChanged.AddListener(SetUsername);
        _userEmailField.onValueChanged.AddListener(SetUserEmail);
        _userPasswordField.onValueChanged.AddListener(SetUserPassword);
        _registrationButton.onClick.AddListener(CreateAccount);
    }

    public void SetUsername(string username)
    {
        _username = username;
    }
    public void SetUserEmail(string mail)
    {
        _mail = mail;
    }
    public void SetUserPassword(string pass)
    {
        _pass = pass;
    }

    public void CreateAccount()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _username,
            Email = _mail,
            Password = _pass,
            RequireBothUsernameAndEmail = true
        }, result =>
        {
            _createError.gameObject.SetActive(false);
            Debug.Log($"User registrated: { result.Username}");
        }, error =>
        {
            Debug.Log(error);
            _createError.gameObject.SetActive(true);
            _createError.text = error.ErrorMessage;
        });
    }
}
