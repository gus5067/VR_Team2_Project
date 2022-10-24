using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AudioData : ScriptableObject
{
    [SerializeField]
    private AudioClip[] audioClips;
    public AudioClip[] AudioClips { get { return audioClips; } }


}
