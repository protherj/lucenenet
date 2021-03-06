using Lucene.Net.Support;
using System;
using System.IO;
using System.Threading;

namespace Lucene.Net.Util
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    /// <summary>
    /// InfoStream implementation over a <seealso cref="PrintStream"/>
    /// such as <code>System.out</code>.
    ///
    /// @lucene.internal
    /// </summary>
    public class PrintStreamInfoStream : InfoStream
    {
        // Used for printing messages
        private static readonly AtomicInt32 MESSAGE_ID = new AtomicInt32();

        protected readonly int m_messageID;

        protected readonly TextWriter m_stream;

        public PrintStreamInfoStream(TextWriter stream)
            : this(stream, MESSAGE_ID.GetAndIncrement())
        {
        }

        public PrintStreamInfoStream(TextWriter stream, int messageID)
        {
            this.m_stream = stream;
            this.m_messageID = messageID;
        }

        public override void Message(string component, string message)
        {
            m_stream.Write(component + " " + m_messageID + " [" + DateTime.Now + "; " + Thread.CurrentThread.Name + "]: " + message);
        }

        public override bool IsEnabled(string component)
        {
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !IsSystemStream)
            {
                m_stream.Dispose();
            }
        }

        public virtual bool IsSystemStream
        {
            get
            {
                return m_stream == Console.Out || m_stream == Console.Error;
            }
        }
    }
}