using System;
using System.Collections.Generic;

[Serializable]
public class RootObject
{
    public string _id;
    public List<string> metaTags;
    public int score;
    public string title;
    public string icon;
    public DateTime created;
    public int created_ts;
    public Count count;
    public int age;
    public string source;
    public int viewCount;
    public int commentCount;
    public int duration;
    public int reactionCount;
    public string shareId;
    public int uniqueViewersCount;
    public int internalScore;
    public bool ageUpdateRestricted;
    public bool approved;
    public int scoreTranded;
    public string type;
    public string mainReaction;
    public bool notSafe;
    public double hotScore;
    public string sourceDomainId;
    public LastComment lastComment;
    public List<string> userMetaTags;
    public bool? _autoApproved;
}