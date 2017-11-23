using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using xapps;
using AVFoundation;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using xapps.iOS;
using System.Diagnostics;
using AVKit;
using CoreMedia;

[assembly: ExportRenderer(typeof(DetailPreview), typeof(PreviewCustomRenderer))]
namespace xapps.iOS
{
    class PreviewCustomRenderer : ViewRenderer, IAVPictureInPictureControllerDelegate
    {
        AVPlayer player;
        AVPlayerLayer playerLayer;
        AVAsset asset;
        AVPlayerItem playerItem;

        UIButton playButton;
        UIButton stopButton;
        AVPlayerViewController controller;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if ((e.OldElement != null) || (this.Element == null))
                return;

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.Red;
            }

            SetNativeControl(new UIView());

            Debug.WriteLine("OnElementChanged");

            asset = AVAsset.FromUrl(new NSUrl(MovieUrlData.previewUrl));
            playerItem = new AVPlayerItem(asset);

            player = new AVPlayer(playerItem);
            player.AddObserver(this, (NSString)"status", NSKeyValueObservingOptions.New, IntPtr.Zero);

            controller = new AVPlayerViewController();
            controller.Player = player;
            playerLayer = AVPlayerLayer.FromPlayer(player);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Debug.WriteLine("LayoutSubviews");

            playerLayer = AVPlayerLayer.FromPlayer(player);
            playerLayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;
            playerLayer.NeedsDisplayOnBoundsChange = true;
            playerLayer.Frame = NativeView.Bounds;
            NativeView.Layer.AddSublayer(playerLayer);

            CGRect rect = NativeView.Bounds;
            playButton = new UIButton(new CGRect((rect.Size.Width / 2) - 25, (rect.Size.Height / 2) - 25, 50, 50));
            stopButton = new UIButton(new CGRect((rect.Size.Width / 2) - 25, (rect.Size.Height / 2) - 25, 50, 50));

            playButton.SetImage(new UIImage("play.png"), UIControlState.Normal);
            playButton.SetImage(new UIImage("play.png"), UIControlState.Highlighted);
            playButton.AddTarget(TouchUpInsidePlayEvent, UIControlEvent.TouchUpInside);
            playButton.Hidden = false;

            stopButton.SetImage(new UIImage("stop.png"), UIControlState.Normal);
            stopButton.SetImage(new UIImage("stop.png"), UIControlState.Highlighted);
            stopButton.AddTarget(TouchUpInsideStopEvent, UIControlEvent.TouchUpInside);
            stopButton.Hidden = true;

            NativeView.AddSubview(playButton);
            NativeView.AddSubview(stopButton);

            UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();
            this.BecomeFirstResponder();

            //NativeView.Layer.AddSublayer(playButton);

            ////layout the elements depending on what screen orientation we are. 
            //if (DeviceHelper.iOSDevice.Orientation == UIDeviceOrientation.Portrait)
            //{
            //    //playButton.Frame = new CGRect(0, NativeView.Frame.Bottom - 50, NativeView.Frame.Width, 50);
            //    _playerLayer.Frame = NativeView.Frame;
            //    NativeView.Layer.AddSublayer(_playerLayer);
            //    //NativeView.Add(playButton);
            //}
            //else if (DeviceHelper.iOSDevice.Orientation == UIDeviceOrientation.LandscapeLeft || DeviceHelper.iOSDevice.Orientation == UIDeviceOrientation.LandscapeRight)
            //{
            //    _playerLayer.Frame = NativeView.Frame;
            //    NativeView.Layer.AddSublayer(_playerLayer);
            //    //playButton.Frame = new CGRect(0, 0, 0, 0);
            //}
        }

        private void TouchUpInsidePlayEvent(object sender, EventArgs e)
        {
            Console.WriteLine("TouchUpInsidePlayEvent");

            player.Play();

            playButton.Hidden = true;
            stopButton.Hidden = false;
        }

        private void TouchUpInsideStopEvent(object sender, EventArgs e)
        {
            Console.WriteLine("TouchUpInsideStopEvent");

            player.Pause();

            playButton.Hidden = false;
            stopButton.Hidden = true;
        }

        [Export("pictureInPictureControllerDidStartPictureInPicture:")]
        public void DidStartPictureInPicture(AVPictureInPictureController pictureInPictureController)
        {
            Console.WriteLine("DidStartPictureInPicture");
            //PictureInPictureActiveLabel.Hidden = false;
            //Toolbar.Hidden = true;
        }

        [Export("pictureInPictureControllerWillStopPictureInPicture:")]
        public void WillStopPictureInPicture(AVPictureInPictureController pictureInPictureController)
        {
            Console.WriteLine("WillStopPictureInPicture");
            //PictureInPictureActiveLabel.Hidden = true;
            //Toolbar.Hidden = false;
        }

        [Export("pictureInPictureControllerFailedToStartPictureInPicture:withError:")]
        public void FailedToStartPictureInPicture(AVPictureInPictureController pictureInPictureController, NSError error)
        {
            Console.WriteLine("FailedToStartPictureInPicture");
            //PictureInPictureActiveLabel.Hidden = true;
            //Toolbar.Hidden = false;
            //HandleError(error);
        }

        void ObserveCurrentItemDuration(NSObservedChange change)
        {
            Console.WriteLine("ObserveCurrentItemDuration");
            //CMTime newDuration;
            //var newDurationAsValue = change.NewValue as NSValue;
            //newDuration = (newDurationAsValue != null) ? newDurationAsValue.CMTimeValue : CMTime.Zero;
            //var hasValidDuration = newDuration.IsNumeric && newDuration.Value != 0;
            //var newDurationSeconds = hasValidDuration ? newDuration.Seconds : 0;

            //TimeSlider.MaxValue = (float)newDurationSeconds;

            //var currentTime = Player.CurrentTime.Seconds;
            //TimeSlider.Value = (float)(hasValidDuration ? currentTime : 0);

            //PlayPauseButton.Enabled = hasValidDuration;
            //TimeSlider.Enabled = hasValidDuration;
        }

        void ObserveCurrentRate(NSObservedChange change)
        {
            Console.WriteLine("ObserveCurrentRate");
            //// Update playPauseButton type.
            //var newRate = ((NSNumber)change.NewValue).DoubleValue;

            //UIBarButtonSystemItem style = (Math.Abs(newRate) < float.Epsilon) ? UIBarButtonSystemItem.Play : UIBarButtonSystemItem.Pause;
            //var newPlayPauseButton = new UIBarButtonItem(style, PlayPauseButtonWasPressed);

            //// Replace the current button with the updated button in the toolbar.
            //UIBarButtonItem[] items = Toolbar.Items;

            //var playPauseItemIndex = Array.IndexOf(items, PlayPauseButton);
            //if (playPauseItemIndex >= 0)
            //{
            //    items[playPauseItemIndex] = newPlayPauseButton;
            //    PlayPauseButton = newPlayPauseButton;
            //    Toolbar.SetItems(items, false);
            //}
        }

        void ObserveCurrentItemStatus(NSObservedChange change)
        {
            Console.WriteLine("ObserveCurrentItemStatus");
            //// Display an error if status becomes Failed
            //var newStatusAsNumber = change.NewValue as NSNumber;
            //AVPlayerItemStatus newStatus = (newStatusAsNumber != null)
            //    ? (AVPlayerItemStatus)newStatusAsNumber.Int32Value
            //    : AVPlayerItemStatus.Unknown;

            //if (newStatus == AVPlayerItemStatus.Failed)
            //{
            //    HandleError(Player.CurrentItem.Error);
            //}
            //else if (newStatus == AVPlayerItemStatus.ReadyToPlay)
            //{
            //    var asset = Player.CurrentItem != null ? Player.CurrentItem.Asset : null;
            //    if (asset != null)
            //    {

            //        // First test whether the values of `assetKeysRequiredToPlay` we need
            //        // have been successfully loaded.
            //        foreach (var key in assetKeysRequiredToPlay)
            //        {
            //            NSError error;
            //            if (asset.StatusOfValue(key, out error) == AVKeyValueStatus.Failed)
            //            {
            //                HandleError(error);
            //                return;
            //            }
            //        }

            //        if (!asset.Playable || asset.ProtectedContent)
            //        {
            //            // We can't play this asset.
            //            HandleError(null);
            //            return;
            //        }

            //        // The player item is ready to play,
            //        // setup picture in picture.
            //        SetupPictureInPicturePlayback();
            //    }
            //}
        }

        public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
            Console.WriteLine("ObserveValue");
            //if (context != IntPtr.Zero)
            //{
            //    base.ObserveValue(keyPath, ofObject, change, context);
            //    return;
            //}

            //var ch = new NSObservedChange(change);

            //if (keyPath == "pictureInPicturePossible")
            //{
            //    // Enable the `PictureInPictureButton` only if `PictureInPicturePossible`
            //    // is true. If this returns false, it might mean that the application
            //    // was not configured as shown in the AppDelegate.
            //    PictureInPictureButton.Enabled = ((NSNumber)ch.NewValue).BoolValue;
            //}
        }

        void HandleError(NSError error)
        {
            Console.WriteLine("HandleError");
            //string message = error != null ? error.LocalizedDescription : string.Empty;
            //var alertController = UIAlertController.Create("Error", message, UIAlertControllerStyle.Alert);
            //var alertAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
            //alertController.AddAction(alertAction);
            //PresentViewController(alertController, true, null);
        }
    }
}