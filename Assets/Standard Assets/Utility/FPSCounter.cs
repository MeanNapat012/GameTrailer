using System;
using UnityEngine;
using UnityEngine.UI; // เพิ่มไลบรารี UI สำหรับใช้ UI.Text

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof (Text))] // แก้ให้ใช้ Text แทน GUIText
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        private Text m_UiText; // เปลี่ยนชื่อตัวแปรเป็น m_UiText

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_UiText = GetComponent<Text>(); // เปลี่ยนการเรียกใช้ให้เป็น GetComponent<Text>()
        }

        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_UiText.text = string.Format(display, m_CurrentFps);
            }
        }
    }
}
