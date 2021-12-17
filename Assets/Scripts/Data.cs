using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Data : MonoBehaviour
{
    public static Data data;

    public int m_Points;
    public int savedHighScore;

    public TMP_InputField nameInput;

    public string name;
    public string bestScoreName;

    private void Awake()
    {
        // start of new code
        if (data != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        data = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void GetName()
    {
        name = nameInput.text;
    }


    [System.Serializable]
    class SaveData
    {
        public int savedHighScore;
        public string name;
        public string bestScoreName;
    }

    public void SaveHighScore()
    {
        //Check if you got a high score
        SaveData data = new SaveData();
        data.savedHighScore = m_Points;
        data.bestScoreName = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedHighScore = data.savedHighScore;
            bestScoreName = data.bestScoreName;
        }
    }

    public void ResetScore()
    {
        m_Points = 0;
    }
}
