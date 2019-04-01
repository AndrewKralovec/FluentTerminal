﻿using FluentTerminal.App.Services;
using FluentTerminal.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentTerminal.App.ViewModels
{
    public class OverlayViewModel : ViewModelBase
    {
        private readonly IDispatcherTimer _overlayTimer;
        private bool _showOverlay;
        private string _overlayContent;

        public OverlayViewModel(IDispatcherTimer dispatcherTimer)
        {
            _overlayTimer = dispatcherTimer;
            _overlayTimer.Interval = new TimeSpan(0, 0, 2);
            _overlayTimer.Tick += OnResizeOverlayTimerFinished;
        }

        public bool ShowOverlay
        {
            get => _showOverlay;
            set
            {
                Set(ref _showOverlay, value);
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

        public string OverlayContent
        {
            get => _overlayContent;
            set
            {
                ShowOverlay = true;
                Set(ref _overlayContent, value);
            }
        }

        private void OnResizeOverlayTimerFinished(object sender, object e)
        {
            _overlayTimer.Stop();
            ShowOverlay = false;
        }

    }
}
