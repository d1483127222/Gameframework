



using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

using StarForce;
using GameEntry = StarForce.GameEntry;

public class DownloadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEntry.Event.Subscribe(DownloadStartEventArgs.EventId, OnDownloadStart);
        GameEntry.Event.Subscribe(DownloadUpdateEventArgs.EventId, OnDownloadUpdate);
        GameEntry.Event.Subscribe(DownloadSuccessEventArgs.EventId, OnDownloadSucess);
        GameEntry.Event.Subscribe(DownloadFailureEventArgs.EventId, OnDownloadFail);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            string downloadPath = Application.streamingAssetsPath + "/Android.zip";
            string downloadUrl = "https://inews.gtimg.com/om_bt/OHyQqgC_5oi4Vm0tlH49XvJzqNBHo2Zryxx5F_be5N2cIAA/1000";
            GameEntry.Download.AddDownload(downloadPath,downloadUrl);
        }
    }

    private void OnDownloadStart(object sender,GameEventArgs e) {
        Log.Debug("開始下載");
    }
    private void OnDownloadUpdate(object sender, GameEventArgs e)
    {
        DownloadUpdateEventArgs args = (DownloadUpdateEventArgs)e;
        Log.Debug("正在下载" + args.CurrentLength);
    }
    private void OnDownloadSucess(object sender, GameEventArgs e)
    {
        Log.Debug("下载成功");
    }
    private void OnDownloadFail(object sender, GameEventArgs e)
    {
        Log.Debug("下载失败");
    }
}
