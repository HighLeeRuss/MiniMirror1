// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbyInterface.PromoteMember" /> function.
	/// </summary>
	public class PromoteMemberOptions
	{
		/// <summary>
		/// The ID of the lobby
		/// </summary>
		public string LobbyId { get; set; }

		/// <summary>
		/// The Product User ID of the local user making the request
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The Product User ID of the member to promote to owner of the lobby
		/// </summary>
		public ProductUserId TargetUserId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct PromoteMemberOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LobbyId;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_TargetUserId;

		public string LobbyId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LobbyId, value);
			}
		}

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public ProductUserId TargetUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_TargetUserId, value);
			}
		}

		public void Set(PromoteMemberOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = LobbyInterface.PromotememberApiLatest;
				LobbyId = other.LobbyId;
				LocalUserId = other.LocalUserId;
				TargetUserId = other.TargetUserId;
			}
		}

		public void Set(object other)
		{
			Set(other as PromoteMemberOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LobbyId);
			Helper.TryMarshalDispose(ref m_LocalUserId);
			Helper.TryMarshalDispose(ref m_TargetUserId);
		}
	}
}