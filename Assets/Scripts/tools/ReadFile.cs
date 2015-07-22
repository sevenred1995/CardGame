using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

namespace Assets.Scripts.tools
{
    public class ReadFile
    {
        public static readonly string PathURL =
#if UNITY_ANDRORD
        "jar:file//"+Application.dataPath+"!/assets/";
#elif UNITY_IPHONE
        Application.dataPath+"/Raw/";
#elif UNITY_STANDALONE_WIN||UNITY_EDITOR
       Application.dataPath+"/StreamingAssets/";
#else   
        string.Empty;
#endif
        public static string Read(string path)
        {
            using(FileStream fs=new FileStream(PathURL+path,FileMode.Open,FileAccess.Read))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    string result = sr.ReadToEnd();
                    return result; 
                }  
            }
        }

    }
}
