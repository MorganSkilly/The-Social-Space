﻿using System.Collections;
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

    [SerializeField]
    public VideoClip defaultVideo;

    [SerializeField]
    public AudioSource defaultAudio;

    [SerializeField]
    public VideoPlayer cinemaScreen;
    [SerializeField]
    public VideoPlayer audioScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayHD()
    {
        string link = ParseYoutubeUrlHD(iField.text);

        using (var service = Client.For(YouTube.Default))
        {
            string url = ParseYoutubeUrlWithAudio(link);
            string urlHD = ParseYoutubeUrlHD(link);

            audioScreen.source = VideoSource.Url;
            cinemaScreen.source = VideoSource.Url;
            audioScreen.url = url;
            cinemaScreen.url = urlHD;
            audioScreen.SetTargetAudioSource(0, defaultAudio);
            audioScreen.Play();
            cinemaScreen.Play();
            audioScreen.Stop();
            cinemaScreen.Stop();
            audioScreen.controlledAudioTrackCount = 1;
            audioScreen.SetTargetAudioSource(0, defaultAudio);
            audioScreen.Play();
            cinemaScreen.Play();
        }
    }

    public void Play(string videoLink)
    {
        using (var service = Client.For(YouTube.Default))
        {
            string url = ParseYoutubeUrlWithAudio(videoLink);
            string urlHD = ParseYoutubeUrlHD(videoLink);

            audioScreen.source = VideoSource.Url;
            cinemaScreen.source = VideoSource.Url;
            audioScreen.url = url;
            cinemaScreen.url = urlHD;
            audioScreen.SetTargetAudioSource(0, defaultAudio);
            audioScreen.Play();
            cinemaScreen.Play();
            audioScreen.Stop();
            cinemaScreen.Stop();
            audioScreen.controlledAudioTrackCount = 1;
            audioScreen.SetTargetAudioSource(0, defaultAudio);
            audioScreen.Play();
            cinemaScreen.Play();
        }
    }

    public void YoutubeTest()
    {
        string link = "https://www.youtube.com/watch?v=Yfn7OG5iw8w";

        using (var service = Client.For(YouTube.Default))
        {
            string url = ParseYoutubeUrlWithAudio(link);
            string urlHD = ParseYoutubeUrlHD(link);

            audioScreen.source = VideoSource.Url;
            cinemaScreen.source = VideoSource.Url;
            audioScreen.url = url;
            cinemaScreen.url = urlHD;
            audioScreen.SetTargetAudioSource(0, defaultAudio);
            audioScreen.Play();
            cinemaScreen.Play();
            audioScreen.Stop();
            cinemaScreen.Stop();
            audioScreen.controlledAudioTrackCount = 1;
            audioScreen.SetTargetAudioSource(0, defaultAudio);
            audioScreen.Play();
            cinemaScreen.Play();
        }
    }

    public void Pause()
    {
        gameObject.GetComponent<VideoPlayer>().Pause();
    }

    public void Stop()
    {
        gameObject.GetComponent<VideoPlayer>().Stop();
    }

    private string ParseYoutubeUrlHD(string sourceURL)
    {
        string highestQuality;

        var youTube = YouTube.Default; // starting point for YouTube actions
        var videoInfo = youTube.GetAllVideosAsync(sourceURL).GetAwaiter().GetResult();
        highestQuality = videoInfo.First(i => i.Resolution == videoInfo.Max(j => j.Resolution)).Uri.ToString();

        return highestQuality;
    }

    private string ParseYoutubeUrlWithAudio(string sourceURL)
    {
        string withAudio;

        var youTube = YouTube.Default; // starting point for YouTube actions
        withAudio = youTube.GetVideoAsync(sourceURL).GetAwaiter().GetResult().Uri.ToString();

        return withAudio;
    }
}
