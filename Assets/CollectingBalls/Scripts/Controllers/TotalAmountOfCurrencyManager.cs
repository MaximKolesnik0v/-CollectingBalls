using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class TotalAmountOfCurrencyManager : MonoBehaviour
{
    [SerializeField] private Text _totalAmountOfCurrency;

    private int _totalMeteorites = 0;

    private void Start()
    {
        TheAdditionOfMeteorites();
            
        _totalAmountOfCurrency.text = ("Total meteorites: " + _totalMeteorites);
    }

    public void TheAdditionOfMeteorites()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat")) LoadGame();

        _totalMeteorites += MeteoriteCounter._meteorite;
        _totalAmountOfCurrency.text = ("Total meteorites: " + _totalMeteorites);

        SaveGame();
    }

    public void SubtractionOfMeteorites(int Count)
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat")) LoadGame();

        _totalMeteorites -= Count;
        _totalAmountOfCurrency.text = ("Total meteorites" + _totalMeteorites);

        SaveGame();
    }

     void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedMeteorits = _totalMeteorites;
        bf.Serialize(file, data);
        file.Close();
        //Debug.Log("Game data saved!");
    }

     void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =  File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            _totalMeteorites = data.savedMeteorits;
            //Debug.Log("Game data loaded!");
        }
        else
        {
            //Debug.LogError("There is no save data!");
        }
    }
}


[Serializable]
class SaveData
{
    public int savedMeteorits;
}