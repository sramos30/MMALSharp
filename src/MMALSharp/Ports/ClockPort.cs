// <copyright file="ClockPort.cs" company="Techyian">
// Copyright (c) Ian Auty. All rights reserved.
// Licensed under the MIT License. Please see LICENSE.txt for License info.
// </copyright>

using System;
using MMALSharp.Native;

namespace MMALSharp.Ports
{
    public class ClockPort : GenericPort
    {
        public unsafe ClockPort(MMAL_PORT_T* ptr, MMALComponentBase comp, PortType type, Guid guid) : base(ptr, comp, type, guid)
        {
        }
    }
}