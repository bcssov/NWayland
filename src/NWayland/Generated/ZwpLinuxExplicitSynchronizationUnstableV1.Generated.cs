using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NWayland.Protocols.Wayland;
using NWayland.Interop;
#nullable enable
// <auto-generated/>
namespace NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1
{
    /// <summary>
    /// This global is a factory interface, allowing clients to request
    /// explicit synchronization for buffers on a per-surface basis.
    /// <br/>
    /// <br/>
    /// See zwp_linux_surface_synchronization_v1 for more information.
    /// <br/>
    /// <br/>
    /// This interface is derived from Chromium's
    /// zcr_linux_explicit_synchronization_v1.
    /// <br/>
    /// <br/>
    /// Warning! The protocol described in this file is experimental and
    /// backward incompatible changes may be made. Backward compatible changes
    /// may be added together with the corresponding interface version bump.
    /// Backward incompatible changes are done by bumping the version number in
    /// the protocol and interface names and resetting the interface version.
    /// Once the protocol is to be declared stable, the 'z' prefix and the
    /// version number in the protocol and interface names are removed and the
    /// interface version number is reset.
    /// </summary>
    public sealed unsafe partial class ZwpLinuxExplicitSynchronizationV1 : WlProxy
    {
        [FixedAddressValueType]
        public static WlInterface WlInterface;

        static ZwpLinuxExplicitSynchronizationV1()
        {
            NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxExplicitSynchronizationV1.WlInterface = new WlInterface("zwp_linux_explicit_synchronization_v1", 2, new WlMessage[] {
                new WlMessage("destroy", "", new WlInterface*[] { }),
                new WlMessage("get_synchronization", "no", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxSurfaceSynchronizationV1.WlInterface), WlInterface.GeneratorAddressOf(ref NWayland.Protocols.Wayland.WlSurface.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxExplicitSynchronizationV1.WlInterface);
        }

        protected override void Dispose(bool disposing)
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
            base.Dispose(true);
        }

        /// <summary>
        /// Instantiate an interface extension for the given wl_surface to provide
        /// explicit synchronization.
        /// <br/>
        /// <br/>
        /// If the given wl_surface already has an explicit synchronization object
        /// associated, the synchronization_exists protocol error is raised.
        /// <br/>
        /// <br/>
        /// Graphics APIs, like EGL or Vulkan, that manage the buffer queue and
        /// commits of a wl_surface themselves, are likely to be using this
        /// extension internally. If a client is using such an API for a
        /// wl_surface, it should not directly use this extension on that surface,
        /// to avoid raising a synchronization_exists protocol error.
        /// </summary>
        public NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxSurfaceSynchronizationV1 GetSynchronization(NWayland.Protocols.Wayland.WlSurface @surface)
        {
            if (@surface == null)
                throw new ArgumentNullException("surface");
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId,
                @surface
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor_versioned(this.Handle, 1, __args, ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxSurfaceSynchronizationV1.WlInterface, (uint)this.Version);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxSurfaceSynchronizationV1(__ret, Version);
        }

        public interface IEvents
        {
        }

        public IEvents? Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum ErrorEnum
        {
            /// <summary></summary>
            SynchronizationExists = 0
        }

        private class ProxyFactory : IBindFactory<ZwpLinuxExplicitSynchronizationV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxExplicitSynchronizationV1.WlInterface);
            }

            public ZwpLinuxExplicitSynchronizationV1 Create(IntPtr handle, int version)
            {
                return new ZwpLinuxExplicitSynchronizationV1(handle, version);
            }
        }

        public static IBindFactory<ZwpLinuxExplicitSynchronizationV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_linux_explicit_synchronization_v1";
        public const int InterfaceVersion = 2;

        public ZwpLinuxExplicitSynchronizationV1(IntPtr handle, int version) : base(handle, version)
        {
        }
    }

    /// <summary>
    /// This object implements per-surface explicit synchronization.
    /// <br/>
    /// <br/>
    /// Synchronization refers to co-ordination of pipelined operations performed
    /// on buffers. Most GPU clients will schedule an asynchronous operation to
    /// render to the buffer, then immediately send the buffer to the compositor
    /// to be attached to a surface.
    /// <br/>
    /// <br/>
    /// In implicit synchronization, ensuring that the rendering operation is
    /// complete before the compositor displays the buffer is an implementation
    /// detail handled by either the kernel or userspace graphics driver.
    /// <br/>
    /// <br/>
    /// By contrast, in explicit synchronization, dma_fence objects mark when the
    /// asynchronous operations are complete. When submitting a buffer, the
    /// client provides an acquire fence which will be waited on before the
    /// compositor accesses the buffer. The Wayland server, through a
    /// zwp_linux_buffer_release_v1 object, will inform the client with an event
    /// which may be accompanied by a release fence, when the compositor will no
    /// longer access the buffer contents due to the specific commit that
    /// requested the release event.
    /// <br/>
    /// <br/>
    /// Each surface can be associated with only one object of this interface at
    /// any time.
    /// <br/>
    /// <br/>
    /// In version 1 of this interface, explicit synchronization is only
    /// guaranteed to be supported for buffers created with any version of the
    /// wp_linux_dmabuf buffer factory. Version 2 additionally guarantees
    /// explicit synchronization support for opaque EGL buffers, which is a type
    /// of platform specific buffers described in the EGL_WL_bind_wayland_display
    /// extension. Compositors are free to support explicit synchronization for
    /// additional buffer types.
    /// </summary>
    public sealed unsafe partial class ZwpLinuxSurfaceSynchronizationV1 : WlProxy
    {
        [FixedAddressValueType]
        public static WlInterface WlInterface;

        static ZwpLinuxSurfaceSynchronizationV1()
        {
            NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxSurfaceSynchronizationV1.WlInterface = new WlInterface("zwp_linux_surface_synchronization_v1", 2, new WlMessage[] {
                new WlMessage("destroy", "", new WlInterface*[] { }),
                new WlMessage("set_acquire_fence", "h", new WlInterface*[] { null }),
                new WlMessage("get_release", "n", new WlInterface*[] { WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1.WlInterface) })
            }, new WlMessage[] { });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxSurfaceSynchronizationV1.WlInterface);
        }

        protected override void Dispose(bool disposing)
        {
            WlArgument* __args = stackalloc WlArgument[] {
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 0, __args);
            base.Dispose(true);
        }

        /// <summary>
        /// Set the acquire fence that must be signaled before the compositor
        /// may sample from the buffer attached with wl_surface.attach. The fence
        /// is a dma_fence kernel object.
        /// <br/>
        /// <br/>
        /// The acquire fence is double-buffered state, and will be applied on the
        /// next wl_surface.commit request for the associated surface. Thus, it
        /// applies only to the buffer that is attached to the surface at commit
        /// time.
        /// <br/>
        /// <br/>
        /// If the provided fd is not a valid dma_fence fd, then an INVALID_FENCE
        /// error is raised.
        /// <br/>
        /// <br/>
        /// If a fence has already been attached during the same commit cycle, a
        /// DUPLICATE_FENCE error is raised.
        /// <br/>
        /// <br/>
        /// If the associated wl_surface was destroyed, a NO_SURFACE error is
        /// raised.
        /// <br/>
        /// <br/>
        /// If at surface commit time the attached buffer does not support explicit
        /// synchronization, an UNSUPPORTED_BUFFER error is raised.
        /// <br/>
        /// <br/>
        /// If at surface commit time there is no buffer attached, a NO_BUFFER
        /// error is raised.
        /// </summary>
        public void SetAcquireFence(int @fd)
        {
            WlArgument* __args = stackalloc WlArgument[] {
                @fd
            };
            LibWayland.wl_proxy_marshal_array(this.Handle, 1, __args);
        }

        /// <summary>
        /// Create a listener for the release of the buffer attached by the
        /// client with wl_surface.attach. See zwp_linux_buffer_release_v1
        /// documentation for more information.
        /// <br/>
        /// <br/>
        /// The release object is double-buffered state, and will be associated
        /// with the buffer that is attached to the surface at wl_surface.commit
        /// time.
        /// <br/>
        /// <br/>
        /// If a zwp_linux_buffer_release_v1 object has already been requested for
        /// the surface in the same commit cycle, a DUPLICATE_RELEASE error is
        /// raised.
        /// <br/>
        /// <br/>
        /// If the associated wl_surface was destroyed, a NO_SURFACE error
        /// is raised.
        /// <br/>
        /// <br/>
        /// If at surface commit time there is no buffer attached, a NO_BUFFER
        /// error is raised.
        /// </summary>
        public NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1 GetRelease()
        {
            WlArgument* __args = stackalloc WlArgument[] {
                WlArgument.NewId
            };
            var __ret = LibWayland.wl_proxy_marshal_array_constructor_versioned(this.Handle, 2, __args, ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1.WlInterface, (uint)this.Version);
            return __ret == IntPtr.Zero ? null : new NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1(__ret, Version);
        }

        public interface IEvents
        {
        }

        public IEvents? Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
        }

        public enum ErrorEnum
        {
            /// <summary></summary>
            InvalidFence = 0,
            /// <summary></summary>
            DuplicateFence = 1,
            /// <summary></summary>
            DuplicateRelease = 2,
            /// <summary></summary>
            NoSurface = 3,
            /// <summary></summary>
            UnsupportedBuffer = 4,
            /// <summary></summary>
            NoBuffer = 5
        }

        private class ProxyFactory : IBindFactory<ZwpLinuxSurfaceSynchronizationV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxSurfaceSynchronizationV1.WlInterface);
            }

            public ZwpLinuxSurfaceSynchronizationV1 Create(IntPtr handle, int version)
            {
                return new ZwpLinuxSurfaceSynchronizationV1(handle, version);
            }
        }

        public static IBindFactory<ZwpLinuxSurfaceSynchronizationV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_linux_surface_synchronization_v1";
        public const int InterfaceVersion = 2;

        public ZwpLinuxSurfaceSynchronizationV1(IntPtr handle, int version) : base(handle, version)
        {
        }
    }

    /// <summary>
    /// This object is instantiated in response to a
    /// zwp_linux_surface_synchronization_v1.get_release request.
    /// <br/>
    /// <br/>
    /// It provides an alternative to wl_buffer.release events, providing a
    /// unique release from a single wl_surface.commit request. The release event
    /// also supports explicit synchronization, providing a fence FD for the
    /// client to synchronize against.
    /// <br/>
    /// <br/>
    /// Exactly one event, either a fenced_release or an immediate_release, will
    /// be emitted for the wl_surface.commit request. The compositor can choose
    /// release by release which event it uses.
    /// <br/>
    /// <br/>
    /// This event does not replace wl_buffer.release events; servers are still
    /// required to send those events.
    /// <br/>
    /// <br/>
    /// Once a buffer release object has delivered a 'fenced_release' or an
    /// 'immediate_release' event it is automatically destroyed.
    /// </summary>
    public sealed unsafe partial class ZwpLinuxBufferReleaseV1 : WlProxy
    {
        [FixedAddressValueType]
        public static WlInterface WlInterface;

        static ZwpLinuxBufferReleaseV1()
        {
            NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1.WlInterface = new WlInterface("zwp_linux_buffer_release_v1", 1, new WlMessage[] { }, new WlMessage[] {
                new WlMessage("fenced_release", "h", new WlInterface*[] { null }),
                new WlMessage("immediate_release", "", new WlInterface*[] { })
            });
        }

        protected override WlInterface* GetWlInterface()
        {
            return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1.WlInterface);
        }

        public interface IEvents
        {
            /// <summary>
            /// Sent when the compositor has finalised its usage of the associated
            /// buffer for the relevant commit, providing a dma_fence which will be
            /// signaled when all operations by the compositor on that buffer for that
            /// commit have finished.
            /// <br/>
            /// <br/>
            /// Once the fence has signaled, and assuming the associated buffer is not
            /// pending release from other wl_surface.commit requests, no additional
            /// explicit or implicit synchronization is required to safely reuse or
            /// destroy the buffer.
            /// <br/>
            /// <br/>
            /// This event destroys the zwp_linux_buffer_release_v1 object.
            /// </summary>
            void OnFencedRelease(NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1 eventSender, int @fence);

            /// <summary>
            /// Sent when the compositor has finalised its usage of the associated
            /// buffer for the relevant commit, and either performed no operations
            /// using it, or has a guarantee that all its operations on that buffer for
            /// that commit have finished.
            /// <br/>
            /// <br/>
            /// Once this event is received, and assuming the associated buffer is not
            /// pending release from other wl_surface.commit requests, no additional
            /// explicit or implicit synchronization is required to safely reuse or
            /// destroy the buffer.
            /// <br/>
            /// <br/>
            /// This event destroys the zwp_linux_buffer_release_v1 object.
            /// </summary>
            void OnImmediateRelease(NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1 eventSender);
        }

        public IEvents? Events { get; set; }

        protected override void DispatchEvent(uint opcode, WlArgument* arguments)
        {
            switch (opcode)
            {
                case 0:
                    Events?.OnFencedRelease(this, arguments[0].Int32);
                    break;
                case 1:
                    Events?.OnImmediateRelease(this);
                    break;
            }
        }

        private class ProxyFactory : IBindFactory<ZwpLinuxBufferReleaseV1>
        {
            public WlInterface* GetInterface()
            {
                return WlInterface.GeneratorAddressOf(ref NWayland.Protocols.ZwpLinuxExplicitSynchronizationUnstableV1.ZwpLinuxBufferReleaseV1.WlInterface);
            }

            public ZwpLinuxBufferReleaseV1 Create(IntPtr handle, int version)
            {
                return new ZwpLinuxBufferReleaseV1(handle, version);
            }
        }

        public static IBindFactory<ZwpLinuxBufferReleaseV1> BindFactory { get; } = new ProxyFactory();

        public const string InterfaceName = "zwp_linux_buffer_release_v1";
        public const int InterfaceVersion = 1;

        public ZwpLinuxBufferReleaseV1(IntPtr handle, int version) : base(handle, version)
        {
        }
    }
}