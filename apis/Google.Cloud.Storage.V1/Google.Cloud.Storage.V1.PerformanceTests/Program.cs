// Copyright 2017 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using Google.Apis.Download;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Cloud.Storage.V1.PerformanceTests
{
    /// <summary>
    /// Currently just a "download very fast" test. May become more useful over time.
    /// Could it use xUnit etc? Not sure.
    /// </summary>
    class Program
    {
        private const string LargeFile = "5gb.dat";
        private const long FileSize = 5 * 1024L * 1024L * 1024L;

        // Horrible global state, but it's simpler than passing it around...
        private static string bucket;
        private static StorageClient client;
        private static int iterations;
        private static long totalData;
        private static volatile bool done;

        static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.Error.WriteLine("Arguments: <bucket> <iterations> <threads>");
                Console.Error.WriteLine("The bucket must exist beforehand, but files will be generated if necessary.");
                return 1;
            }

            client = StorageClient.Create();
            bucket = args[0];
            iterations = int.Parse(args[1]);
            int threadCount = int.Parse(args[2]);

            CreateFileIfNecessary();

            var progressTask = Task.Run((Action) ReportProgress);
            var workerThreads = Enumerable.Range(0, threadCount).Select(_ => Task.Run((Action) Download)).ToArray();
            Task.WaitAll(workerThreads);
            done = true;
            progressTask.Wait();

            return 0;
        }

        private static void Download()
        {
            var stream = new NullStream();
            for (int i = 0; i < iterations; i++)
            {
                client.DownloadObject(bucket, LargeFile, stream,
                    new DownloadObjectOptions { ChunkSize = 1 * 1024 * 1024 }, // 1MB chunks
                    new ProgressMonitor());
            }
        }

        private static void ReportProgress()
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (!done)
            {
                Thread.Sleep(1000);
                long ms = sw.ElapsedMilliseconds;
                long bytesRead = Interlocked.Read(ref totalData);
                double speed = (bytesRead / (1024.0 * 1024.0)) / (ms / 1000.0);
                Console.WriteLine($"{speed:F2}MBps     ({bytesRead} bytes in {ms}ms)");
            }
        }

        private static void CreateFileIfNecessary()
        {
            try
            {
                client.GetObject(bucket, LargeFile);
                Console.WriteLine($"File {bucket}/{LargeFile} already exists. Skipping upload.");
                return;
            }
            catch (GoogleApiException e) when (e.HttpStatusCode == HttpStatusCode.NotFound)
            {
            }
            Console.WriteLine($"File {bucket}/{LargeFile} not found. Creating.");
            var stream = new LongRandomStream(FileSize);
            var stopwatch = Stopwatch.StartNew();
            client.UploadObject(bucket, LargeFile, "application/octet-stream", stream);
            stopwatch.Stop();
            Console.WriteLine($"{FileSize} bytes uploaded in {stopwatch.ElapsedMilliseconds}ms");
        }

        private class ProgressMonitor : IProgress<IDownloadProgress>
        {
            private long lastSeen = 0;

            public void Report(IDownloadProgress value)
            {
                long current = value.BytesDownloaded;
                Interlocked.Add(ref totalData, current - lastSeen);
                lastSeen = current;
            }
        }
    }
}
