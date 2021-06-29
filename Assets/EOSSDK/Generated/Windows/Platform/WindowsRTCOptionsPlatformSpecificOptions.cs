// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Platform
{
	/// <summary>
	/// Options for initializing rtc functionality required for some platforms.
	/// </summary>
	public class WindowsRTCOptionsPlatformSpecificOptions : ISettable
	{
		/// <summary>
		/// The absolute path to a `xaudio2_9redist.dll` dependency, including the file name
		/// </summary>
		public string XAudio29DllPath { get; set; }

		internal void Set(WindowsRTCOptionsPlatformSpecificOptionsInternal? other)
		{
			if (other != null)
			{
				XAudio29DllPath = other.Value.XAudio29DllPath;
			}
		}

		public void Set(object other)
		{
			Set(other as WindowsRTCOptionsPlatformSpecificOptionsInternal?);
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct WindowsRTCOptionsPlatformSpecificOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_XAudio29DllPath;

		public string XAudio29DllPath
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_XAudio29DllPath, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_XAudio29DllPath, value);
			}
		}

		public void Set(WindowsRTCOptionsPlatformSpecificOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = PlatformInterface.PlatformWindowsrtcoptionsplatformspecificoptionsApiLatest;
				XAudio29DllPath = other.XAudio29DllPath;
			}
		}

		public void Set(object other)
		{
			Set(other as WindowsRTCOptionsPlatformSpecificOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_XAudio29DllPath);
		}
	}
}