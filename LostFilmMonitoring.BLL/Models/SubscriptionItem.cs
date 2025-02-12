﻿// <copyright file="SubscriptionItem.cs" company="Alexander Panfilenok">
// MIT License
// Copyright (c) 2021 Alexander Panfilenok
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the 'Software'), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </copyright>

namespace LostFilmMonitoring.BLL.Models
{
    /// <summary>
    /// Represents user selection.
    /// </summary>
    public class SubscriptionItem
    {
        /// <summary>
        /// Gets or sets Series Name.
        /// </summary>
        public string? SeriesName { get; set; }

        /// <summary>
        /// Gets or sets quality.
        /// </summary>
        public string? Quality { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.SeriesName} [{this.Quality}]";
        }

        /// <summary>
        /// Map array of <see cref="SubscriptionItem"/> to an array of <see cref="Subscription"/>.
        /// </summary>
        /// <param name="items">An array of <see cref="SubscriptionItem"/>.</param>
        /// <returns>An array of <see cref="Subscription"/>.</returns>
        internal static Subscription[] ToSubscriptions(SubscriptionItem[] items)
            => items.Select(Map).ToArray();

        private static Subscription Map(SubscriptionItem s)
            => new (
                s.SeriesName ?? throw new InvalidDataException(nameof(Subscription.SeriesName)),
                s.Quality ?? throw new InvalidDataException(nameof(Subscription.Quality)));
    }
}
