﻿using System;
using System.Threading.Tasks;

namespace Xamarin.Forms.NeoControls.Extensions
{
    /// <summary>
    /// Based on <see cref="https://github.com/brminnick/AsyncAwaitBestPractices"/> from Brandon Minnick
    /// </summary>
    internal static class TaskExtensions
    {
        internal static async void SafeFireAndForget(this Task task, bool continueOnCapturedContext = false, Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(continueOnCapturedContext);
            }
            catch (Exception ex) when (onException != null)
            {
                onException.Invoke(ex);
            }
        }
    }
}
