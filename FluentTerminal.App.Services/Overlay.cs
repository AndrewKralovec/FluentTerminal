using System;
using System.Collections.Generic;
using System.Text;

namespace FluentTerminal.App.Services
{
    public class Overlay
    {
        private readonly IDispatcherTimer _overlayTimer;
        public bool _showOverlay { get; set; } = false;
        public string Content { get; set; } = "";

        public Overlay(IDispatcherTimer dispatcherTimer)
        {
            _overlayTimer = dispatcherTimer;
            _overlayTimer.Interval = new TimeSpan(0, 0, 2);
            _overlayTimer.Tick += OnTimerFinished;
        }

        public bool ShowOverlay
        {
            get => _showOverlay;
            set
            {
                _showOverlay = value;
                if (value)
                {
                    if (_overlayTimer.IsEnabled)
                    {
                        _overlayTimer.Stop();
                    }
                    _overlayTimer.Start();
                }
            }
        }

        public void DisplayOverlay(string text)
        {
            Content = text;
            ShowOverlay = true;
        }

        public void OnTimerFinished(object sender, object e)
        {
            _overlayTimer.Stop();
            ShowOverlay = false;
        }
    }
}
