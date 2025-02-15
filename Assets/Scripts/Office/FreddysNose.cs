using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddysNose : MonoBehaviour
{
    [SerializeField] private AudioSource noseAudio;
    
    public void PressNose()
    {
        noseAudio.Play();
    }
}
