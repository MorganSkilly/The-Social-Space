using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using VideoLibrary;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    public InputField iField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        //var service = Client.For(YouTube.Default);
        //var video = service.GetVideo(iField.text);

        var youTube = YouTube.Default; // starting point for YouTube actions
        var videoInfos = youTube.GetAllVideosAsync(iField.text).GetAwaiter().GetResult();
        var maxResolution = videoInfos.First(i => i.Resolution == videoInfos.Max(j => j.Resolution));

        Debug.Log(maxResolution.Uri);
        gameObject.GetComponent<VideoPlayer>().url = maxResolution.Uri;
        gameObject.GetComponent<VideoPlayer>().Play();
    }

    public void Pause()
    {
        gameObject.GetComponent<VideoPlayer>().Pause();
    }

    public void Stop()
    {
        gameObject.GetComponent<VideoPlayer>().Stop();
    }
}
