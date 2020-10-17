﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.Audio
{
    public interface IOneShot
    {
        AudioClip Clip { get; }
        float MinVolume { get; }
        float MaxVolume { get; }
        float MinPitch { get; }
        float MaxPitch { get; }
    }
}