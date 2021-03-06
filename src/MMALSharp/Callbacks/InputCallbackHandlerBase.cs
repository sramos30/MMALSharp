﻿// <copyright file="InputCallbackHandlerBase.cs" company="Techyian">
// Copyright (c) Ian Auty. All rights reserved.
// Licensed under the MIT License. Please see LICENSE.txt for License info.
// </copyright>

using System;
using MMALSharp.Handlers;
using MMALSharp.Native;
using MMALSharp.Ports;

namespace MMALSharp.Callbacks
{
    /// <summary>
    /// Base class for input port callback handlers.
    /// </summary>
    public abstract class InputCallbackHandlerBase : IInputCallbackHandler
    {
        /// <inheritdoc />
        public MMALEncoding EncodingType { get; }

        /// <inheritdoc />
        public IInputPort WorkingPort { get; }

        /// <summary>
        /// Creates a new instance of <see cref="InputCallbackHandlerBase"/>.
        /// </summary>
        /// <param name="port">The working <see cref="IInputPort"/>.</param>
        protected InputCallbackHandlerBase(IInputPort port)
        {
            this.WorkingPort = port;
        }

        /// <summary>
        /// Creates a new instance of <see cref="InputCallbackHandlerBase"/>.
        /// </summary>
        /// <param name="port">The working <see cref="IInputPort"/>.</param>
        /// <param name="encodingType">The <see cref="MMALEncoding"/> type to restrict on.</param>
        protected InputCallbackHandlerBase(IInputPort port, MMALEncoding encodingType)
        {
            this.WorkingPort = port;
            this.EncodingType = encodingType;
        }

        /// <inheritdoc />
        public virtual ProcessResult Callback(MMALBufferImpl buffer)
        {
            if (MMALCameraConfig.Debug)
            {
                MMALLog.Logger.Debug("In managed input callback");
            }
            
            if (this.EncodingType != null && this.WorkingPort.EncodingType != this.EncodingType)
            {
                throw new ArgumentException("Port Encoding Type not supported for this handler.");
            }
            
            return this.WorkingPort.Handler?.Process(buffer.AllocSize);
        }
    }
}
