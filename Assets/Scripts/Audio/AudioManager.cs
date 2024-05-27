using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Die, 
            Resources.Load<AudioClip>("die"));
        audioClips.Add(AudioClipName.Flap,
            Resources.Load<AudioClip>("flap"));
        audioClips.Add(AudioClipName.Hit,
            Resources.Load<AudioClip>("hit"));
        audioClips.Add(AudioClipName.Point,
             Resources.Load<AudioClip>("point"));
        audioClips.Add(AudioClipName.Swoosh,
             Resources.Load<AudioClip>("swoosh"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
