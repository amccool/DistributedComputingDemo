﻿using KeyWatcher.Messages;
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace KeyWatcher.Dependencies
{
	internal sealed class SignalRNotification
		: INotification
	{
		private readonly IHubContext hub;

		public SignalRNotification(IHubContext hub)
		{
			if (hub == null)
			{
				throw new ArgumentNullException(nameof(hub));
			}

			this.hub = hub;
		}

		public Task SendAsync(string recipient, string title, string message)
		{
			Console.Out.WriteLine("About to SignalR...");
			this.hub.Clients.All.NotificationSent(
				new SignalRNotificationMessage(recipient, title, message));
			return Task.CompletedTask;
		}
	}
}
