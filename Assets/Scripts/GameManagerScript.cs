using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManagerScript : MonoBehaviour
{
    public string filepath = "log.txt";
    public string GetCurrentTime()
    {
        DateTime now = DateTime.Now;
        return now.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        MessageConsole();
        OnApplicationStart();
        OnApplicationQuit();
    }

    // Update is called once per frame
    void Update()
    {
         using(StreamWriter writer = File.AppendText(filepath))
         {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                writer.WriteLine(GetCurrentTime() + "  Space down");
            }
         }
    }

    private void CreateFile()
    {
        if (!File.Exists(filepath)) //if file does not exists
        {
            File.Create(filepath).Close();
        }
    }
    
    public void MessageConsole()
    {
        using (StreamWriter writer = File.AppendText (filepath))
        {
            writer.WriteLine(GetCurrentTime() + "  Button clicked");
        }
    }

    public void OnApplicationStart()
    {
        using(StreamWriter writer = File.AppendText (filepath))
        {
            writer.WriteLine(GetCurrentTime() + "  Opened Application");
        }
    }

    public void OnApplicationQuit()
    {
        using (StreamWriter writer = File.AppendText (filepath))
        {
            writer.WriteLine(GetCurrentTime() + "  Closed Application");
        }
    }

}

 
    


