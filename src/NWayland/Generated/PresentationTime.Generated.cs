using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
#nullable enable
// <auto-generated/>
namespace NWayland.Protocols.PresentationTime
{
    /// <summary>
    /// <br/>
    /// <br/>
    /// When the final realized presentation time is available, e.g.
    /// after a framebuffer flip completes, the requested
    /// presentation_feedback.presented events are sent. The final
    /// presentation time can differ from the compositor's predicted
    /// display update time and the update's target time, especially
    /// when the compositor misses its target vertical blanking period.
    /// </summary>
    public sealed unsafe partial class WpPresentation : WlProxy
    {
        [FixedAddressValueType]
        public static WlInterface WlInterface;

        static WpPresentation()
        {
            NWayland.Protocols.PresentationTime.WpPresentation.WlInterface = new WlInterface("wp_presentation", 1, new WlMessage[] {
                new WlMessage("destroy", "", new WlInterface*[] { }),
                new WlMessage("feedback", "on", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface) })
            }, new WlMessage[] {
                new WlMessage("clock_id", "u", new WlInterface*[] { null })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentation.WlInterface);
        }

        protected override void Dispose(bool disposing)
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
            base.Dispose(true);
        }

        /// <summary>
        /// Request presentation feedback for the current content submission
        /// on the given surface. This creates a new presentation_feedback
        /// object, which will deliver the feedback information once. If
        /// multiple presentation_feedback objects are created for the same
        /// submission, they will all deliver the same information.
        /// <br/>
        /// <br/>
        /// For details on what information is returned, see the
        /// presentation_feedback interface.
        /// </summary>
        public NWayland.Protocols.PresentationTime.WpPresentationFeedback Feedback(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                @surface,
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor_versioned(this.Handle, 1, __args, ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface, (uint)this.Version);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.PresentationTime.WpPresentationFeedback(__ret, Version);
        }

        public interface IEvents
        {
            /// <summary>
            /// This event tells the client in which clock domain the
            /// compositor interprets the timestamps used by the presentation
            /// extension. This clock is called the presentation clock.
            /// <br/>
            /// <br/>
            /// The compositor sends this event when the client binds to the
            /// presentation interface. The presentation clock does not change
            /// during the lifetime of the client connection.
            /// <br/>
            /// <br/>
            /// The clock identifier is platform dependent. On Linux/glibc,
            /// the identifier value is one of the clockid_t values accepted
            /// by clock_gettime(). clock_gettime() is defined by
            /// POSIX.1-2001.
            /// <br/>
            /// <br/>
            /// Timestamps in this clock domain are expressed as tv_sec_hi,
            /// tv_sec_lo, tv_nsec triples, each component being an unsigned
            /// 32-bit value. Whole seconds are in tv_sec which is a 64-bit
            /// value combined from tv_sec_hi and tv_sec_lo, and the
            /// additional fractional part in tv_nsec as nanoseconds. Hence,
            /// for valid timestamps tv_nsec must be in [0, 999999999].
            /// <br/>
            /// <br/>
            /// Note that clock_id applies only to the presentation clock,
            /// and implies nothing about e.g. the timestamps used in the
            /// Wayland core protocol input events.
            /// <br/>
            /// <br/>
            /// Compositors should prefer a clock which does not jump and is
            /// not slewed e.g. by NTP. The absolute value of the clock is
            /// irrelevant. Precision of one millisecond or better is
            /// recommended. Clients must be able to query the current clock
            /// value directly, not by asking the compositor.
            /// </summary>
            void OnClockId(NWayland.Protocols.PresentationTime.WpPresentation eventSender, uint @clkId);
        }

        public IEvents? Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            switch (opcode)
            {
                case 0:
                    Events?.OnClockId(this, arguments[0].UInt32);
                    break;
            }
        }

        /// <summary>
        /// These fatal protocol errors may be emitted in response to
        /// illegal presentation requests.
        /// </summary>
        public enum ErrorEnum
        {
            /// <summary></summary>
            InvalidTimestamp = 0,
            /// <summary></summary>
            InvalidFlag = 1
        }

        private class ProxyFactory : IBindFactory<WpPresentation>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentation.WlInterface);
            }

            public WpPresentation Create(IntPtr handle, int version)
            {
                return new WpPresentation(handle, version);
            }
        }

        public static IBindFactory<WpPresentation> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wp_presentation";
        public const int InterfaceVersion = 1;

        public WpPresentation(IntPtr handle, int version) : base(handle, version)
        {
        }
    }

    /// <summary>
    /// A presentation_feedback object returns an indication that a
    /// wl_surface content update has become visible to the user.
    /// One object corresponds to one content update submission
    /// (wl_surface.commit). There are two possible outcomes: the
    /// content update is presented to the user, and a presentation
    /// timestamp delivered; or, the user did not see the content
    /// update because it was superseded or its surface destroyed,
    /// and the content update is discarded.
    /// <br/>
    /// <br/>
    /// Once a presentation_feedback object has delivered a 'presented'
    /// or 'discarded' event it is automatically destroyed.
    /// </summary>
    public sealed unsafe partial class WpPresentationFeedback : WlProxy
    {
        [FixedAddressValueType]
        public static WlInterface WlInterface;

        static WpPresentationFeedback()
        {
            NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface = new WlInterface("wp_presentation_feedback", 1, new WlMessage[] { }, new WlMessage[] {
                new WlMessage("sync_output", "o", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlOutput.WlInterface) }),
                new WlMessage("presented", "uuuuuuu", new WlInterface*[] { null, null, null, null, null, null, null }),
                new WlMessage("discarded", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface);
        }

        public interface IEvents
        {
            /// <summary>
            /// As presentation can be synchronized to only one output at a
            /// time, this event tells which output it was. This event is only
            /// sent prior to the presented event.
            /// <br/>
            /// <br/>
            /// As clients may bind to the same global wl_output multiple
            /// times, this event is sent for each bound instance that matches
            /// the synchronized output. If a client has not bound to the
            /// right wl_output global at all, this event is not sent.
            /// </summary>
            void OnSyncOutput(NWayland.Protocols.PresentationTime.WpPresentationFeedback eventSender, NWayland.Protocols.Wayland.WlOutput @output);

            /// <summary>
            /// The associated content update was displayed to the user at the
            /// indicated time (tv_sec_hi/lo, tv_nsec). For the interpretation of
            /// the timestamp, see presentation.clock_id event.
            /// <br/>
            /// <br/>
            /// The timestamp corresponds to the time when the content update
            /// turned into light the first time on the surface's main output.
            /// Compositors may approximate this from the framebuffer flip
            /// completion events from the system, and the latency of the
            /// physical display path if known.
            /// <br/>
            /// <br/>
            /// This event is preceded by all related sync_output events
            /// telling which output's refresh cycle the feedback corresponds
            /// to, i.e. the main output for the surface. Compositors are
            /// recommended to choose the output containing the largest part
            /// of the wl_surface, or keeping the output they previously
            /// chose. Having a stable presentation output association helps
            /// clients predict future output refreshes (vblank).
            /// <br/>
            /// <br/>
            /// The 'refresh' argument gives the compositor's prediction of how
            /// many nanoseconds after tv_sec, tv_nsec the very next output
            /// refresh may occur. This is to further aid clients in
            /// predicting future refreshes, i.e., estimating the timestamps
            /// targeting the next few vblanks. If such prediction cannot
            /// usefully be done, the argument is zero.
            /// <br/>
            /// <br/>
            /// If the output does not have a constant refresh rate, explicit
            /// video mode switches excluded, then the refresh argument must
            /// be zero.
            /// <br/>
            /// <br/>
            /// The 64-bit value combined from seq_hi and seq_lo is the value
            /// of the output's vertical retrace counter when the content
            /// update was first scanned out to the display. This value must
            /// be compatible with the definition of MSC in
            /// GLX_OML_sync_control specification. Note, that if the display
            /// path has a non-zero latency, the time instant specified by
            /// this counter may differ from the timestamp's.
            /// <br/>
            /// <br/>
            /// If the output does not have a concept of vertical retrace or a
            /// refresh cycle, or the output device is self-refreshing without
            /// a way to query the refresh count, then the arguments seq_hi
            /// and seq_lo must be zero.
            /// </summary>
            void OnPresented(NWayland.Protocols.PresentationTime.WpPresentationFeedback eventSender, uint @tvSecHi, uint @tvSecLo, uint @tvNsec, uint @refresh, uint @seqHi, uint @seqLo, KindEnum @flags);

            /// <summary>
            /// The content update was never displayed to the user.
            /// </summary>
            void OnDiscarded(NWayland.Protocols.PresentationTime.WpPresentationFeedback eventSender);
        }

        public IEvents? Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            switch (opcode)
            {
                case 0:
                    Events?.OnSyncOutput(this, WlProxy.FromNative<NWayland.Protocols.Wayland.WlOutput>(arguments[0].IntPtr));
                    break;
                case 1:
                    Events?.OnPresented(this, arguments[0].UInt32, arguments[1].UInt32, arguments[2].UInt32, arguments[3].UInt32, arguments[4].UInt32, arguments[5].UInt32, (KindEnum)arguments[6].UInt32);
                    break;
                case 2:
                    Events?.OnDiscarded(this);
                    break;
            }
        }

        /// <summary>
        /// These flags provide information about how the presentation of
        /// the related content update was done. The intent is to help
        /// clients assess the reliability of the feedback and the visual
        /// quality with respect to possible tearing and timings.
        /// </summary>
        [Flags]
        public enum KindEnum
        {
            Vsync = 0x1,
            HwClock = 0x2,
            HwCompletion = 0x4,
            ZeroCopy = 0x8
        }

        private class ProxyFactory : IBindFactory<WpPresentationFeedback>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.PresentationTime.WpPresentationFeedback.WlInterface);
            }

            public WpPresentationFeedback Create(IntPtr handle, int version)
            {
                return new WpPresentationFeedback(handle, version);
            }
        }

        public static IBindFactory<WpPresentationFeedback> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "wp_presentation_feedback";
        public const int InterfaceVersion = 1;

        public WpPresentationFeedback(IntPtr handle, int version) : base(handle, version)
        {
        }
    }
}