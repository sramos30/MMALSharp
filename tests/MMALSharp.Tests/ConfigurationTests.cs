﻿// <copyright file="ConfigurationTests.cs" company="Techyian">
// Copyright (c) Ian Auty. All rights reserved.
// Licensed under the MIT License. Please see LICENSE.txt for License info.
// </copyright>

using System;
using MMALSharp.Components;
using MMALSharp.Native;
using MMALSharp.Utility;
using Xunit;

namespace MMALSharp.Tests
{
    public class ConfigurationTests : TestBase
    {
        [Theory]
        [InlineData(MMALSensorMode.Mode0)]
        [InlineData(MMALSensorMode.Mode2)]
        [InlineData(MMALSensorMode.Mode4)]
        [MMALTestsAttribute]
        public void SetThenGetSensorMode(MMALSensorMode mode)
        {
            MMALCameraConfig.SensorMode = mode;

            Fixture.MMALCamera.ConfigureCameraSettings();
            Assert.True(Fixture.MMALCamera.Camera.GetSensorMode() == mode);
        }

        [Theory]
        [InlineData(40)]
        [InlineData(45)]
        [InlineData(-100)]
        [MMALTestsAttribute]
        public void SetThenGetBrightness(double brightness)
        {
            MMALCameraConfig.Brightness = brightness;

            if (brightness >= 0 && brightness <= 100)
            {
                Fixture.MMALCamera.ConfigureCameraSettings();

                Assert.True(Fixture.MMALCamera.Camera.GetBrightness() == brightness / 100);
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => Fixture.MMALCamera.ConfigureCameraSettings());
            }
        }

        [Theory]
        [InlineData(20)]
        [InlineData(38)]
        [InlineData(101)]
        [MMALTestsAttribute]
        public void SetThenGetSharpness(double sharpness)
        { 
            MMALCameraConfig.Sharpness = sharpness;

            if (sharpness >= -100 && sharpness <= 100)
            {
                Fixture.MMALCamera.ConfigureCameraSettings();

                Assert.True(Fixture.MMALCamera.Camera.GetSharpness() == sharpness / 100);
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => Fixture.MMALCamera.ConfigureCameraSettings());
            }
        }

        [Theory]
        [InlineData(10)]
        [InlineData(54)]
        [InlineData(-200)]
        [MMALTestsAttribute]
        public void SetThenGetContrast(double contrast)
        {  
            MMALCameraConfig.Contrast = contrast;

            if (contrast >= -100 && contrast <= 100)
            {
                Fixture.MMALCamera.ConfigureCameraSettings();

                Assert.True(Fixture.MMALCamera.Camera.GetContrast() == contrast / 100);
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => Fixture.MMALCamera.ConfigureCameraSettings());
            }
        }

        [Theory]
        [InlineData(30)]
        [InlineData(55)]
        [InlineData(90)]
        [MMALTestsAttribute]
        public void SetThenGetSaturation(double saturation)
        {    
            MMALCameraConfig.Saturation = saturation;
            Fixture.MMALCamera.ConfigureCameraSettings();

            Assert.True(Fixture.MMALCamera.Camera.GetSaturation() == saturation / 100);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(900)]
        [InlineData(0)]
        [MMALTestsAttribute]
        public void SetThenGetIso(int iso)
        {  
            MMALCameraConfig.ISO = iso;

            if ((iso >= 100 && iso <= 800) || iso == 0)
            {
                Fixture.MMALCamera.ConfigureCameraSettings();

                Assert.True(Fixture.MMALCamera.Camera.GetISO() == iso);
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => Fixture.MMALCamera.ConfigureCameraSettings());
            }
        }

        [Theory]
        [InlineData(5)]
        [InlineData(50)]
        [InlineData(-30)]
        [MMALTestsAttribute]
        public void SetThenGetExposureCompensation(int expCompensation)
        {   
            MMALCameraConfig.ExposureCompensation = expCompensation;

            if (expCompensation >= -10 && expCompensation <= 10)
            {
                Fixture.MMALCamera.ConfigureCameraSettings();
                Assert.True(Fixture.MMALCamera.Camera.GetExposureCompensation() == expCompensation);
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => Fixture.MMALCamera.ConfigureCameraSettings());
            }
        }

        [Theory]
        [InlineData(MMAL_PARAM_EXPOSUREMODE_T.MMAL_PARAM_EXPOSUREMODE_BEACH)]
        [InlineData(MMAL_PARAM_EXPOSUREMODE_T.MMAL_PARAM_EXPOSUREMODE_FIREWORKS)]
        [InlineData(MMAL_PARAM_EXPOSUREMODE_T.MMAL_PARAM_EXPOSUREMODE_ANTISHAKE)]
        [MMALTestsAttribute]
        public void SetThenGetExposureMode(MMAL_PARAM_EXPOSUREMODE_T expMode)
        {    
            MMALCameraConfig.ExposureMode = expMode;
            Fixture.MMALCamera.ConfigureCameraSettings();

            Assert.True(Fixture.MMALCamera.Camera.GetExposureMode() == expMode);
        }

        [Theory]
        [InlineData(MMAL_PARAM_EXPOSUREMETERINGMODE_T.MMAL_PARAM_EXPOSUREMETERINGMODE_BACKLIT)]
        [InlineData(MMAL_PARAM_EXPOSUREMETERINGMODE_T.MMAL_PARAM_EXPOSUREMETERINGMODE_MATRIX)]
        [InlineData(MMAL_PARAM_EXPOSUREMETERINGMODE_T.MMAL_PARAM_EXPOSUREMETERINGMODE_AVERAGE)]
        [MMALTestsAttribute]
        public void SetThenGetExposureMeteringMode(MMAL_PARAM_EXPOSUREMETERINGMODE_T expMetMode)
        {     
            MMALCameraConfig.ExposureMeterMode = expMetMode;
            Fixture.MMALCamera.ConfigureCameraSettings();

            Assert.True(Fixture.MMALCamera.Camera.GetExposureMeteringMode() == expMetMode);
        }

        [Theory]
        [InlineData(MMAL_PARAM_AWBMODE_T.MMAL_PARAM_AWBMODE_AUTO)]
        [InlineData(MMAL_PARAM_AWBMODE_T.MMAL_PARAM_AWBMODE_FLUORESCENT)]
        [InlineData(MMAL_PARAM_AWBMODE_T.MMAL_PARAM_AWBMODE_CLOUDY)]
        [MMALTestsAttribute]
        public void SetThenGetAwbMode(MMAL_PARAM_AWBMODE_T awbMode)
        {    
            MMALCameraConfig.AwbMode = awbMode;
            Fixture.MMALCamera.ConfigureCameraSettings();

            Assert.True(Fixture.MMALCamera.Camera.GetAwbMode() == awbMode);
        }

        [Theory]
        [InlineData(MMAL_PARAM_IMAGEFX_T.MMAL_PARAM_IMAGEFX_CARTOON)]
        [InlineData(MMAL_PARAM_IMAGEFX_T.MMAL_PARAM_IMAGEFX_COLOURBALANCE)]
        [InlineData(MMAL_PARAM_IMAGEFX_T.MMAL_PARAM_IMAGEFX_OILPAINT)]
        [MMALTestsAttribute]
        public void SetThenGetImageFx(MMAL_PARAM_IMAGEFX_T imgFx)
        {      
            MMALCameraConfig.ImageFx = imgFx;
            Fixture.MMALCamera.ConfigureCameraSettings();
            Assert.True(Fixture.MMALCamera.Camera.GetImageFx() == imgFx);
        }

        [Theory]
        [InlineData(true, 128, 128)]
        [InlineData(true, 50, 100)]
        [InlineData(false, 128, 128)]
        [MMALTestsAttribute]
        public void SetThenGetColourFx(bool enable, byte u, byte v)
        {        
            var color = MMALColor.FromYUVBytes(0, u, v);

            var colFx = new ColourEffects(enable, color);

            MMALCameraConfig.ColourFx = colFx;
            Fixture.MMALCamera.ConfigureCameraSettings();

            var uv = MMALColor.RGBToYUVBytes(Fixture.MMALCamera.Camera.GetColourFx().Color);
            
            Assert.True(Fixture.MMALCamera.Camera.GetColourFx().Enable == enable &&
                        uv.Item2 == u &&
                        uv.Item3 == v);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(90, 90)]
        [InlineData(140, 90)]
        [InlineData(250, 180)]
        [InlineData(270, 270)]
        [MMALTestsAttribute]
        public void SetThenGetRotation(int rotation, int expectedResult)
        {     
            MMALCameraConfig.Rotation = rotation;
            Fixture.MMALCamera.ConfigureCameraSettings();

            Assert.True(Fixture.MMALCamera.Camera.GetRotation() == expectedResult);
        }

        [Theory]
        [InlineData(MMAL_PARAM_MIRROR_T.MMAL_PARAM_MIRROR_HORIZONTAL)]
        [InlineData(MMAL_PARAM_MIRROR_T.MMAL_PARAM_MIRROR_BOTH)]
        [InlineData(MMAL_PARAM_MIRROR_T.MMAL_PARAM_MIRROR_VERTICAL)]
        [MMALTestsAttribute]
        public void SetThenGetFlips(MMAL_PARAM_MIRROR_T flips)
        {     
            MMALCameraConfig.Flips = flips;
            Fixture.MMALCamera.ConfigureCameraSettings();
            Assert.True(Fixture.MMALCamera.Camera.GetFlips() == flips &&
                        Fixture.MMALCamera.Camera.GetStillFlips() == flips &&
                        Fixture.MMALCamera.Camera.GetVideoFlips() == flips);
        }

        [Theory]
        [InlineData(0.1, 0.1, 0.5, 1.0)]
        [InlineData(0.5, 0.1, 0.5, 1.0)]
        [InlineData(0.1, 1.1, 0.5, 1.0)]
        [MMALTestsAttribute]
        public void SetThenGetZoom(double x, double y, double width, double height)
        {      
            var zoom = new Zoom(x, y, width, height);

            MMALCameraConfig.ROI = zoom;

            if (x <= 1.0 && y <= 1.0 && height <= 1.0 && width <= 1.0)
            {
                Fixture.MMALCamera.ConfigureCameraSettings();

                Assert.True(Fixture.MMALCamera.Camera.GetZoom().Height == Convert.ToInt32(height * 65536) &&
                            Fixture.MMALCamera.Camera.GetZoom().Width == Convert.ToInt32(width * 65536) &&
                            Fixture.MMALCamera.Camera.GetZoom().X == Convert.ToInt32(x * 65536) &&
                            Fixture.MMALCamera.Camera.GetZoom().Y == Convert.ToInt32(y * 65536));
            }
            else
            {
                Assert.ThrowsAny<Exception>(() => Fixture.MMALCamera.ConfigureCameraSettings());
            }
        }

        [Theory]
        [InlineData(2500)]
        [MMALTestsAttribute]
        public void SetThenGetShutterSpeed(int shutterSpeed)
        {   
            MMALCameraConfig.StillFramerate = new MMAL_RATIONAL_T(0, 0);
            MMALCameraConfig.SensorMode = MMALSensorMode.Mode1;
            MMALCameraConfig.AwbMode = MMAL_PARAM_AWBMODE_T.MMAL_PARAM_AWBMODE_OFF;
            MMALCameraConfig.ShutterSpeed = shutterSpeed;
            Fixture.MMALCamera.ConfigureCameraSettings();

            Assert.True(Fixture.MMALCamera.Camera.GetShutterSpeed() == shutterSpeed);
        }

        [Theory]
        [InlineData(MMAL_PARAMETER_DRC_STRENGTH_T.MMAL_PARAMETER_DRC_STRENGTH_HIGH)]
        [InlineData(MMAL_PARAMETER_DRC_STRENGTH_T.MMAL_PARAMETER_DRC_STRENGTH_LOW)]
        [InlineData(MMAL_PARAMETER_DRC_STRENGTH_T.MMAL_PARAMETER_DRC_STRENGTH_MEDIUM)]
        [MMALTestsAttribute]
        public void SetThenGetDrc(MMAL_PARAMETER_DRC_STRENGTH_T drc)
        { 
            MMALCameraConfig.DrcLevel = drc;
            Fixture.MMALCamera.ConfigureCameraSettings();
            Assert.True(Fixture.MMALCamera.Camera.GetDRC() == drc);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [MMALTestsAttribute]
        public void SetThenGetStatsPass(bool statsPass)
        {    
            MMALCameraConfig.StatsPass = statsPass;
            Fixture.MMALCamera.ConfigureCameraSettings();
            Assert.True(Fixture.MMALCamera.Camera.GetStatsPass() == statsPass);
        }
    }
}
