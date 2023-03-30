﻿#region Copyright 2018-2023 C. Augusto Proiete & Contributors
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
//
#endregion

using ExcelDna.Integration;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.ExcelDna
{
    /// <summary>
    /// Enriches log events with an ExcelVersion property containing the <see cref="ExcelDnaUtil.ExcelVersion"/>.
    /// </summary>
    public class ExcelVersionEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        /// <summary>
        /// The property name added to enriched log events.
        /// </summary>
        public const string ExcelVersionPropertyName = "ExcelVersion";

        /// <inheritdoc />
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var cachedProperty =
                _cachedProperty ??= propertyFactory.CreateProperty(ExcelVersionPropertyName, ExcelDnaUtil.ExcelVersion);

            logEvent.AddPropertyIfAbsent(cachedProperty);
        }
    }
}
