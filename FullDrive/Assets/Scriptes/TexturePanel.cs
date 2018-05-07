using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePanel : MonoBehaviour {

    private readonly string url = "https://api.fulldive.com/dive";
    private static RootObjectList jsonObject;
    private string urlimg;
    private Texture2D img;

    private void Start()
    {
        StartCoroutine(Processing(url, ThroughData));
    }

    private static IEnumerator Processing(string url, Action callback)
    {
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            jsonObject = GetObjectFromJson(www.text);
            callback();
        }
        else
        {
            Debug.Log("Something wrong: " + www.error);
        }
    }

    private static RootObjectList GetObjectFromJson(string jsonString)
    {
        return JsonUtility.FromJson<RootObjectList>("{\"data\": " + jsonString + "}");
    }

    private static Result GetResultCouple(int element)
    {
        return new Result(jsonObject.data[element].icon, jsonObject.data[element].title);
    }

    private void ThroughData()
    {
        Result res;
        var k = UnityEngine.Random.Range(1, jsonObject.data.Count);
        res = GetResultCouple(k);
        urlimg = res.icon;
        Debug.Log(urlimg);
        StartCoroutine(ChangeImg());
    }
    private IEnumerator ChangeImg()
    {
        WWW www = new WWW(urlimg);
        yield return www;
        img = www.texture;
        GetComponent<Renderer>().material.mainTexture = img;
    }
}
