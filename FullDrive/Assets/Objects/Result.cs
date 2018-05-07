using System;
using UnityEngine;

[Serializable]
public class Result
{
    public Result(string icon, string title)
    {
        this.icon = icon;
        this.title = title;
    }

    public string icon;
    public string title;
}