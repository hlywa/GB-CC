using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForumPostInfo
{
    public string postTitle = "";
    public string caption = "";
    public eGamerTag characterTag;
    public eChannel channel;
    public string timePosted = "";
    public string datePosted = "";
    public  int[] reactions = new int[3]{0,0,0};
    public PostComment[] comments = new PostComment[] { };

    public ForumPostInfo(string title, string captionText, eGamerTag gTag, eChannel echannel, string time, string date, int[] reaction, PostComment[] comment)
    {
        postTitle = title;
        caption = captionText;
        characterTag = gTag;
        channel = echannel;
        timePosted = time;
        datePosted = date;
        reactions = reaction;
        comments = comment;
    }
}

