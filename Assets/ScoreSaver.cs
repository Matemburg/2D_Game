using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class ScoreSaver {

    public static void SaveScore (Score score)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score2.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        ScoreCointaner cointaner = new ScoreCointaner(score);
        List<ScoreCointaner> ScoreTable;
        if (File.Exists(path))
        {
            try
            {
                ScoreTable = binaryFormatter.Deserialize(stream) as List<ScoreCointaner>;
                Debug.Log("Po wczytaniu" + ScoreTable.Count);
            }
            catch(System.Exception e)
            {
                Debug.LogError("Not open");
                ScoreTable = new List<ScoreCointaner>();
            }

            bool exist = false;
            foreach (ScoreCointaner item in ScoreTable)
            {
                Debug.Log("Wejście do pentli");
                if (item.Name == cointaner.Name )
                {
                    Debug.Log("Znalazło");
                    exist = true;
                    if (item.score < cointaner.score)
                        item.score = cointaner.score;
                }
                
            }
            if(!exist)
            {
                Debug.Log("dodało");
                ScoreTable.Add(cointaner);
            }
        }
        else
        {
            Debug.LogError("File Dont");
            ScoreTable = new List<ScoreCointaner>();
            ScoreTable.Add(cointaner);
        }

        binaryFormatter.Serialize(stream, ScoreTable);
        stream.Close();
    }

    public static List<ScoreCointaner> LoadScore()
    {
        List<ScoreCointaner> ScoreTable= new List<ScoreCointaner>();
        string path = Application.persistentDataPath + "/score2.fun";
        FileStream stream = new FileStream(path, FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (File.Exists(path))
        {
            try
            {
                ScoreTable = binaryFormatter.Deserialize(stream) as List<ScoreCointaner>;
            }
            catch (System.Exception e)
            {
                ScoreTable = new List<ScoreCointaner>();
            }
    
            ScoreTable = binaryFormatter.Deserialize(stream) as List<ScoreCointaner>;
        }
        stream.Close();

        return ScoreTable;
    }


}
