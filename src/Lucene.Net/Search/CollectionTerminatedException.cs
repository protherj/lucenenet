using System;
#if FEATURE_SERIALIZABLE
using System.Runtime.Serialization;
#endif

namespace Lucene.Net.Search
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
    /// Throw this exception in <seealso cref="ICollector#collect(int)"/> to prematurely
    ///  terminate collection of the current leaf.
    ///  <p>Note: IndexSearcher swallows this exception and never re-throws it.
    ///  As a consequence, you should not catch it when calling
    ///  <seealso cref="IndexSearcher#search"/> as it is unnecessary and might hide misuse
    ///  of this exception.
    /// </summary>
    // LUCENENET: All exeption classes should be marked serializable
#if FEATURE_SERIALIZABLE
    [Serializable]
#endif
    public sealed class CollectionTerminatedException : Exception
    {
        /// <summary>
        /// Sole constructor. </summary>
        public CollectionTerminatedException()
            : base()
        {
        }

#if FEATURE_SERIALIZABLE
        /// <summary>
        /// Initializes a new instance of this class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        public CollectionTerminatedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}