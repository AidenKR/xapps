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
    class PreviewCustomRenderer : ViewRenderer
    {
        AVPlayer player;
        AVPlayerLayer playerLayer;
        AVAsset asset;
        AVPlayerItem playerItem;

        UIButton playButton;
        UIButton stopButton;
        bool isPlaying;

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

            Console.WriteLine("OnElementChanged");

            asset = AVAsset.FromUrl(new NSUrl(MovieUrlData.previewUrl));
            playerItem = new AVPlayerItem(asset);

            player = new AVPlayer(playerItem);
            playerLayer = AVPlayerLayer.FromPlayer(player);
            isPlaying = false;
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            Console.WriteLine("Dispose disposing = " + disposing);
            Console.WriteLine("playerLayer.ReadyForDisplay = " + playerLayer.ReadyForDisplay);
            if(disposing && isPlaying) {
                player.Pause();
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Console.WriteLine("LayoutSubviews");

            playerLayer = AVPlayerLayer.FromPlayer(player);
            playerLayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;
            playerLayer.NeedsDisplayOnBoundsChange = true;
            playerLayer.Frame = NativeView.Bounds;
            NativeView.Layer.AddSublayer(playerLayer);

            player.AddObserver(this, (NSString)"status", NSKeyValueObservingOptions.New, IntPtr.Zero);
            player.AddBoundaryTimeObserver(times: new[] { NSValue.FromCMTime(new CMTime(playerItem.Asset.Duration.Value, playerItem.Asset.Duration.TimeScale)) },
                                            queue: null,
                                            handler: () =>
                                            {
                                                player.Seek(new CMTime(0, 0));
                                                controlPlayer(true);
                                            });

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

        public void videoFinished(NSNotification notify)
        {
            Console.WriteLine("videoFinished");
        }

        private void TouchUpInsidePlayEvent(object sender, EventArgs e)
        {
            Console.WriteLine("TouchUpInsidePlayEvent");

            controlPlayer(false);
        }

        private void TouchUpInsideStopEvent(object sender, EventArgs e)
        {
            Console.WriteLine("TouchUpInsideStopEvent");

            controlPlayer(true);
        }

        private void controlPlayer(bool stoping)
        {
            if (stoping)
            {
                player.Pause();
            }
            else
            {
                player.Play();

            }

            isPlaying = !stoping;
            playButton.Hidden = !stoping;
            stopButton.Hidden = stoping;
        }

        public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
            Console.WriteLine("ObserveValue");
        }
    }
}