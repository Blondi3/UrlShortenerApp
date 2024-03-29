﻿using System;
using System.Threading.Tasks;

namespace UrlShortenerApp.Database
{
    public static class TaskExtensions
    {
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }
            catch (Exception ex) when (onException != null)
            {
                Console.WriteLine(ex);
            }
        }
    }
}