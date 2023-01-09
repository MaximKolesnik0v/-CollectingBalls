using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviourPunCallbacks
{
    private const string PLAYFAB_TITLE = "E49F0";
    private const string GAME_VERSION = "dev";
    private const string AUTHENTIFICATION_KEY = "AUTHENTIFICATION_KEY";
    private readonly Dictionary<string, CatalogItem> _catalog = new Dictionary<string, CatalogItem>();


    private struct Data
    {
        public bool needCreation;
        public string id;
    }

    void Start()
    {
            PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(), OnGetCatalogSuccess, OnFailure);

            if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            PlayFabSettings.staticSettings.TitleId = PLAYFAB_TITLE;

        var needCreation = !PlayerPrefs.HasKey(AUTHENTIFICATION_KEY);
        var id = PlayerPrefs.GetString(AUTHENTIFICATION_KEY, Guid.NewGuid().ToString());

        var data = new Data { needCreation = needCreation, id = id };

        var request = new LoginWithCustomIDRequest
        {
            CustomId = id,
            CreateAccount = needCreation
        };
        PlayFabClientAPI.LoginWithCustomID(request, Success, Fail , data);
    }

    private void OnFailure(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport(); Debug.LogError($"Something went wrong: {errorMessage}");
    }

    private void OnGetCatalogSuccess(GetCatalogItemsResult result)
    {
        HandleCatalog(result.Catalog);
        Debug.Log($"Catalog was loaded successfully!");
    }

    private void HandleCatalog(List<CatalogItem> catalog)
    {
        foreach (var item in catalog)
        {
            _catalog.Add(item.ItemId, item);
            Debug.Log($"Catalog item {item.ItemId} was added successfully!");
        }
    }

    private void Success(LoginResult result)
    {
        PlayerPrefs.SetString(AUTHENTIFICATION_KEY, ((Data)result.CustomData).id);

        Debug.Log(result.PlayFabId);
        Debug.Log(((Data)result.CustomData).needCreation);
        Debug.Log(((Data)result.CustomData).id);
        Connect();

        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), 
            result =>
            {
                Debug.Log(result.AccountInfo.PlayFabId);
            }, error =>
            {
                Debug.Log(error);
            });
    }

    private void Fail(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.Log(errorMessage);
    }

    private void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomOrCreateRoom(roomName: $"Room N{UnityEngine.Random.Range(0, 9999)}");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = GAME_VERSION;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster()");
    }
}
