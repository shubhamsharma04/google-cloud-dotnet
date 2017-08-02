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

using System;
using System.IO;

namespace Google.Cloud.Storage.V1.PerformanceTests
{
    /// <summary>
    /// Stream which supplies random data up to a given length.
    /// </summary>
    internal sealed class LongRandomStream : Stream
    {
        private readonly object _lock = new object();
        private readonly Random _rng = new Random();
        // Random.NextBytes fills a buffer; we need a chunk. It's really ugly...
        // (We happen to know that we'll be uploading 4K chunks...)
        private readonly byte[] _streamBuffer = new byte[4096];

        public override bool CanRead => true;
        public override bool CanSeek => true;
        public override bool CanWrite => false;

        public override long Length { get; }
        public override long Position { get; set; }

        internal LongRandomStream(long length)
        {
            Length = length;
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            // We assume that the parameters are reasonable.
            lock (_lock)
            {
                int maxReadable = (int) Math.Min(int.MaxValue, Length - Position);
                int actualReadLength = Math.Min(count, maxReadable);
                if (actualReadLength < 0)
                {
                    return 0;
                }
                if (offset == 0 && actualReadLength == buffer.Length)
                {
                    _rng.NextBytes(buffer);
                }
                else
                {
                    // If only Random had a NextBytes(byte[], int, int)...
                    int bytesLeft = actualReadLength;
                    int localOffset = offset;
                    while (bytesLeft > 0)
                    {
                        _rng.NextBytes(_streamBuffer);
                        int bytesToCopy = Math.Min(bytesLeft, _streamBuffer.Length);
                        Buffer.BlockCopy(_streamBuffer, 0, buffer, localOffset, bytesToCopy);
                        localOffset += bytesToCopy;
                        bytesLeft -= bytesToCopy;
                    }
                }
                Position += actualReadLength;
                return actualReadLength;
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }
}
