﻿// <copyright file="OutputCallbackProvider.cs" company="Techyian">
// Copyright (c) Ian Auty. All rights reserved.
// Licensed under the MIT License. Please see LICENSE.txt for License info.
// </copyright>

using System;
using System.Collections.Generic;
using MMALSharp.Ports;

namespace MMALSharp.Callbacks.Providers
{
    /// <summary>
    /// Provides a facility to retrieve callback handlers for Output ports.
    /// </summary>
    internal static class ControlCallbackProvider
    {
        /// <summary>
        /// The list of active callback handlers.
        /// </summary>
        public static Dictionary<IControlPort, IControlCallbackHandler> WorkingHandlers { get; private set; } = new Dictionary<IControlPort, IControlCallbackHandler>();

        /// <summary>
        /// Register a new <see cref="IControlCallbackHandler"/>.
        /// </summary>
        /// <param name="handler">The callback handler.</param>
        public static void RegisterCallback(IControlCallbackHandler handler)
        {
            if (handler?.WorkingPort == null)
            {
                throw new NullReferenceException("Callback handler not configured correctly.");
            }

            if (WorkingHandlers.ContainsKey(handler.WorkingPort))
            {
                WorkingHandlers[handler.WorkingPort] = handler;
            }
            else
            {
                WorkingHandlers.Add(handler.WorkingPort, handler);
            }
        }

        /// <summary>
        /// Finds and returns a <see cref="IControlCallbackHandler"/> for a given port. If no handler is registered, a 
        /// <see cref="DefaultControlCallbackHandler"/> will be returned.
        /// </summary>
        /// <param name="port">The port we are retrieving the callback handler on.</param>
        /// <returns>A <see cref="IControlCallbackHandler"/> for a given port. If no handler is registered, a 
        /// <see cref="DefaultControlCallbackHandler"/> will be returned.</returns>
        public static IControlCallbackHandler FindCallback(IControlPort port)
        {
            if (WorkingHandlers.ContainsKey(port))
            {
                return WorkingHandlers[port];
            }
            
            return new DefaultControlCallbackHandler(port);
        }

        /// <summary>
        /// Remove a callback handler for a given port.
        /// </summary>
        /// <param name="port">The port we are removing the callback handler on.</param>
        public static void RemoveCallback(IControlPort port)
        {
            if (WorkingHandlers.ContainsKey(port))
            {
                WorkingHandlers.Remove(port);
            }
        }
    }
}
