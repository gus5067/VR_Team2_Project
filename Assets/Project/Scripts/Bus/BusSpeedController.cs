using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusSpeedController : MonoBehaviour
{
    private NavMeshAgent bus;
    [SerializeField]
    private AudioData busSound;

    private AudioSource busAudio;
    [SerializeField, Range(0f, 10f)]
    private float speed;
    public float Speed
    {
        get { return speed; }
        set
        {
            if (value <= 0)
            {
                speed = 0;
                busAudio.clip = busSound.AudioClips[0];
                busAudio.Play();
            }
            else
            {
                busAudio.clip = busSound.AudioClips[1];
                busAudio.Play();
                speed = value;
            }
        }
    }
    private void Awake()
    {
        bus = GetComponent<NavMeshAgent>();
        busAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Speed = speed;
    }
    private void Update()
    {
        bus.speed = Speed;
    }
}
