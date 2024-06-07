
using GameFramework;
using GameFramework.Event;
using StarForce;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using GameEntry = StarForce.GameEntry;

public class DownloadImageToUnityTest : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        
        GameEntry.Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            string downloadUrl = "https://inews.gtimg.com/om_bt/OHyQqgC_5oi4Vm0tlH49XvJzqNBHo2Zryxx5F_be5N2cIAA/1000";
            
            // 向服务器请求版本信息
            GameEntry.WebRequest.AddWebRequest(downloadUrl, this);
        }
    }

    void OnWebRequestSuccess(object sender,GameEventArgs e) { 
        WebRequestSuccessEventArgs webRequestSuccessEventArgs = (WebRequestSuccessEventArgs)e;
        Log.Debug("下载成功");
        Texture2D texture = new Texture2D(100, 100);
        texture.LoadImage(webRequestSuccessEventArgs.GetWebResponseBytes());
        Sprite sprite = Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(texture.width, texture.height)), Vector2.zero);
        image.sprite = sprite;
    }
}
