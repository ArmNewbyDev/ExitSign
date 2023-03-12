using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSfxPitch : MonoBehaviour
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    [SerializeField] private float VolumeMax = 1f;
    [Range (0f, 1f)]
    [SerializeField] private float VolumeMin = 0f;
    [Range (-3f, 3f)]
    [SerializeField] private float PitchMax = 1f;
    [Range (-3f, 3f)]
    [SerializeField] private float PitchMin = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSource.volume = Random.Range (VolumeMin, VolumeMax);
        audioSource.pitch = Random.Range (PitchMin, PitchMax);
    }
}
