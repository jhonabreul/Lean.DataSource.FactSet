﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using QuantConnect.Lean.DataSource.FactSet;
using System.Collections.Generic;
using System;

namespace QuantConnect.DataProcessing
{
    /// <summary>
    /// The only purpose of this class is to provide a way to access the <see cref="FactSetDataDownloader"/> class and use its constructor
    /// that takes the raw data folder as a parameter.
    ///
    /// This is done this way in order to keep the public interface of the <see cref="FactSetDataDownloader"/> clean and simple,
    /// without exposing its additional capabilities of storing the raw data downloaded from FactSet, which is only useful
    /// for the Data Processing program.
    /// </summary>
    internal class FactSetDataProcessingDataDownloader : FactSetDataDownloader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FactSetDataProcessingDataDownloader"/>
        /// </summary>
        public FactSetDataProcessingDataDownloader(FactSet.SDK.Utils.Authentication.Configuration factSetAuthConfiguration, string rawDataFolder)
            : base(new FactSetDataProcessingDataProvider(factSetAuthConfiguration, rawDataFolder))
        {
        }

        /// <summary>
        /// Get the option chains for the specified symbol and time range.
        /// Exposed to be used by the Data Processing program.
        /// </summary>
        public IEnumerable<Symbol> GetOptionChains(Symbol symbol, DateTime startUtc, DateTime endUtc)
        {
            return base.GetOptions(symbol, startUtc, endUtc);
        }
    }
}