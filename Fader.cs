/**
 * 
 *  Copyright (C) 2019 Marios Kalogerou
 * 
 *  This file is part of Gemi Games Unity Framework (GemiFramework).
 * 
 *  GemiFramework is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  GemiFramework is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with GemiFramework. If not, see <http://www.gnu.org/licenses/>.
 * 
 **/

using GemiFramework;
using UnityEngine;

public class Fader
{
    private float m_FadePosition;

    public float Position
    {
        get { return m_FadePosition; }
    }

    private float m_FaderStartPosition;
    private float m_WishPosition;

    private float m_FadeTime;
    private float m_FadeDuration;

    private bool m_Fading;

    public bool Fading
    {
        get { return m_Fading; }
    }

    public Fader() : this(1f)
    {

    }

    public Fader(float lStartPosition)
    {
        Set(lStartPosition);
    }

    public void Set(float lStartPosition)
    {
        m_FadePosition = lStartPosition;
        m_FaderStartPosition = lStartPosition;
        m_WishPosition = lStartPosition;

        m_FadeTime = 1f;
        m_FadeDuration = 1f;

        m_Fading = false;
    }

    public void Fade(float lPosition, float lDuration = 2f)
    {
        m_FaderStartPosition = m_FadePosition;
        m_WishPosition = lPosition;

        m_FadeTime = 0f;
        m_FadeDuration = Mathf.Clamp(lDuration, 0.1f, 60f);

        m_Fading = true;
    }

    public void Update()
    {
        if (m_FadeTime < m_FadeDuration)
        {
            float lRamp = RampSineIn.getInstance().getRamp(m_FadeTime, m_FadeDuration);

            m_FadePosition = m_FaderStartPosition + (m_WishPosition - m_FaderStartPosition) * lRamp;

            m_FadeTime += Time.unscaledDeltaTime;
        }
        else if (m_Fading)
        {
            m_FadePosition = m_WishPosition;

            m_Fading = false;
        }

    }
}
