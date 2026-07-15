using System;
using UnityEngine;

namespace SlivaCYD3.Clicker
{
    public class ClickerModel
    {
        private const int WINDOW_SIZE = 60;

        private float[] recentClickTimes;
        private int currentIndex;
        
        public event Action<ClickerModel> OnDataChanged;
        
        public int TotalClicks { get; private set; }
        public float CurrentCPS { get; private set; }
        public float AverageCPS { get; private set; }
        
        public ClickerModel()
        {
            recentClickTimes = new float[WINDOW_SIZE];
        }
        
        public void RegisterClick()
        {
            var now = Time.time;
            
            recentClickTimes[currentIndex] = now;
            currentIndex = (currentIndex + 1) % WINDOW_SIZE;
            
            TotalClicks++;
            CalculateCPS(now);
            CalculateAverageCPS();
            
            OnDataChanged?.Invoke(this);
        }
        
        private void CalculateCPS(float currentTime)
        {
            var clicksInLastSecond = 0;
            for (var i = 0; i < WINDOW_SIZE; i++)
            {
                if (currentTime - recentClickTimes[i] <= 1.0f && recentClickTimes[i] > 0)
                    clicksInLastSecond++;
            }
            CurrentCPS = clicksInLastSecond;
        }
        
        private void CalculateAverageCPS()
        {
            if (TotalClicks == 0) 
                return;
            
            AverageCPS = TotalClicks / Mathf.Max(1, Time.time);
        }
    }
}