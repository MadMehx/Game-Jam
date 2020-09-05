using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    [Header("Foot Steps")]
    //[SerializeField]
    //private Vector2 footstepPitchRange;

    [SerializeField]
    private List<AudioClip> footstepClips = new List<AudioClip>();

    [SerializeField]
    private AudioSource audioSource = null;

    private int lastUsedClip = 0;

    public void PlayFootstep()
    {
        audioSource.PlayOneShot(RoundRobin());
    }

    private AudioClip RoundRobin()
    {
        int rand = Random.Range(0, footstepClips.Count);

        while (rand == lastUsedClip)
        {
            rand = Random.Range(0, footstepClips.Count);
        }

        lastUsedClip = rand;
        return footstepClips[rand];
    }

}
