using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using SwipeActivationIssue.Custom;
using SwipeActivationIssue.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeActivationIssue.Handlers
{
    /// <summary>
    /// Adds common handlers defined in this Maui project.
    /// </summary>
    public static class CommonHandlerProvider
    {
        public static MauiAppBuilder ConfigureCommonMauiHandlers(this MauiAppBuilder builder)
        {
            return builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(CustomSwipeView), typeof(CustomSwipeViewHandler));
            });
        }
    }
}
