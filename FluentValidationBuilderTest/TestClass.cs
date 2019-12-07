using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using FluentValidationBuilder.Model.ActiveMessage;
using NUnit.Framework;

namespace FluentValidationBuilderTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestSerializationCode()
        {
            var transcodeBody = new TranscodeBody();

            
            var transcodeItem = new TranscodeItem
            {
                FileSize = 144708692,
                Tasks = GetTranscodeTasks(),
                CheckSum = "F3653151503CE8F66DBE86E5B8592615F6429EC6343269861E891034AFB4DD45",
                FormatId = 2211,
                Priority = 0,
                SourceKey = "1523924/8201913_20190801_792254.mxf",
                FrameCount = 660,
                SourceFile =
                    "222240064172237095153242202004224178205203037167214040044150229229136024117252237248135044047088035003190228006055134057179049183047132253058139108128020045126044125233192137207135202083081065174030239237117018098068194149190008163011025118252240229244160068052125231153135097140123186175214140000144141078080045212158041043166198172141025215040009231066182239248122001092250135066227246089092054119081053024215252041075167206120187011211147033121072211090173109022159136210178167",
                TargetFile =
                    "8201913-XDC60StrictLG15_29.97fps_8-10bit-v1_24bit_AES_MXF_(GLOBO)-24ec2c15-47f5-46fe-b339-feafe80b8021.mxf",
                CustomValues = GetTranscodeCustomValues(),
                SourceBucket = "ebus-media-sa",
                SourceRegion = "sa-east-1",
                TargetFolder = "1523924"
            };

            transcodeBody.Items = new List<TranscodeItem>()
            {
                transcodeItem
            };
            transcodeBody.Endpoint = "https://api.imdcloud.net/mediaservices/message";
            transcodeBody.Priority = 6;
            transcodeBody.TargetBucket = "ebus-media-sa";
            transcodeBody.CorrelationId = "f219d386-ee82-40a5-a9f1-76b0c2ec6516";
            transcodeBody.CallbackEndpoint = "http://mediaservicecallback.imdcloud.net/";
            transcodeBody.TargetStorageProviderUser =
                "200140200021222107008088150117204195058159133227166226113016005178061178061009110188052178229022";
            transcodeBody.TargetStorageProviderPassword =
                "019209060186107235192195194130011022136064046189142179089037150199200088184181004093059243039155050075006193079177211212060039021139193069161211";
            transcodeBody.TargetStorageProvider = "Amazon";
            transcodeBody.CustomValues = GetTranscodeCustomValues();


            var options = new JsonSerializerOptions();
            options.WriteIndented = true;

            var jsonData = JsonSerializer.Serialize(transcodeBody, options);
            Console.WriteLine(jsonData);
            Assert.IsTrue(jsonData.Length > 0);

        }

        private IList<TranscodeTask> GetTranscodeTasks()
        {
            return new List<TranscodeTask>()
            {
                new TranscodeTask()
                {
                    Order = 1,
                    Command = "$Format.avisynth_name(\"\") $Format.avisynth_noaudio(\"1\") $Format.avisynth_debug(\"0\") $Format.avisynth_decomb_threshold(\"30\") $Format.avisynth_blur_prefilter(\"25\") $Format.avisynth_blur_postfilter(\"25\") $Format.avisynth_apply_legalize(\"0\") $Format.avisynth_scriptversion(\"4\")",
                    Provider = "AvsGen"
                },
                new TranscodeTask()
                {
                    Order = 2,
                    Command = "$Tools.demux_provider(\"ffmpeg.exe\") -i \"$Runtime.InputFile\" $Format.demux_string(\" -vcodec copy work.m2v -acodec pcm_s16le work1.wav -acodec pcm_s16le work2.wav -acodec pcm_s16le work3.wav -acodec pcm_s16le work4.wav -acodec pcm_s16le work5.wav -acodec pcm_s16le work6.wav -acodec pcm_s16le work7.wav -acodec pcm_s16le work8.wav \")",
                    Provider = "DemuxV2"
                },
                new TranscodeTask()
                {
                    Order = 3,
                    Command = "$Runtime.WorkingDirectory\\work.wav $Runtime.WorkingDirectory\\tvc.wav",
                    Provider = "SoxPad"
                }
            };

        }

        private IList<TranscodeCustomValue> GetTranscodeCustomValues()
        {
            return new List<TranscodeCustomValue>()
            {
                new TranscodeCustomValue()
                {
                    Name = "$Format.avisynth_name",
                    Value = "generated.avs"
                },
                new TranscodeCustomValue()
                {
                    Name = "$Format.avisynth_apply_legalize",
                    Value = "1"
                },
                new TranscodeCustomValue()
                {
                    Name = "$Tools.sequence_provider",
                    Value = "ffmpeg400x64.exe"
                }
            };
        }
    }
}

