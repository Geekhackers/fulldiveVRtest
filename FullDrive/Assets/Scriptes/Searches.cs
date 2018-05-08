﻿using System;
using System.Collections;
using UnityEngine;

public class Searches : MonoBehaviour {

    private readonly string url = "https://api.fulldive.com/dive";
    private static string jsonQuery;
    private static RootObjectList jsonObject;
    private int rand;

    private void Start()
    {
        rand = UnityEngine.Random.Range(2, 7);
        Spawn.k = rand;
        StartCoroutine(Processing(url, ThroughData));
    }

    private static IEnumerator Processing(string url, Action callback)
    {
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            jsonQuery = www.text;
            jsonObject = JsonParser(jsonQuery);
            callback();
        }
        else
        {
            Debug.Log("Something wrong: " + www.error);
        }
    }

    private static RootObjectList JsonParser(string jsonString)
    {
        return JsonUtility.FromJson<RootObjectList>("{\"data\": " + jsonString + "}");
    }

    private static Result GetDataFromArray(int element)
    {
        return new Result(jsonObject.data[element].icon, jsonObject.data[element].title);
    }

    private void ThroughData()
    {
        Result res;
        GameObject[] PanelVR = GameObject.FindGameObjectsWithTag("PanelVR");
        GameObject[] PanelText = GameObject.FindGameObjectsWithTag("Text");


        if (rand < jsonObject.data.Count)
        {
            for (int i = 0; i < rand; i++)
            {
                res = GetDataFromArray(i);
                StartCoroutine(ChangeImg(res.icon, PanelVR[i]));
                PanelText[i].GetComponent<TextMesh>().text = res.title;

            }
        }
    }
    private IEnumerator ChangeImg(string urlimg, GameObject PanelVR)
    {
        WWW www = new WWW(urlimg);
        yield return www;
        PanelVR.GetComponent<Renderer>().material.mainTexture = www.texture; ;
    }
}