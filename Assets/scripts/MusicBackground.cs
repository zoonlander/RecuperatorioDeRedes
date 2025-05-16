using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour
{
    private void Start()
    {
        GlobalAudioManager.instance.PlayMusic1("Background");
    }
}
