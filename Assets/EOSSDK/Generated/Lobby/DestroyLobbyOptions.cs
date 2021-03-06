// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbyInterface.DestroyLobby" /> function.
	/// </summary>
	public class DestroyLobbyOptions
	{
		/// <summary>
		/// The Product User ID of the local user requesting destruction of the lobby; this user must currently own the lobby
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The ID of the lobby to destroy
		/// </summary>
		public string LobbyId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct DestroyLobbyOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_LobbyId;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public string LobbyId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LobbyId, value);
			}
		}

		public void Set(DestroyLobbyOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = LobbyInterface.DestroylobbyApiLatest;
				LocalUserId = other.LocalUserId;
				LobbyId = other.LobbyId;
			}
		}

		public void Set(object other)
		{
			Set(other as DestroyLobbyOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LocalUserId);
			Helper.TryMarshalDispose(ref m_LobbyId);
		}
	}
}