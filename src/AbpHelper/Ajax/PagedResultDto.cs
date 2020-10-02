using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AbpHelper.Ajax.Dto
{
    /// <summary>
    /// Implements <see cref="IPagedResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="ListResultDto{T}.Items"/> list</typeparam>
    [Serializable]
    public class PagedResultDto<T> : ListResultDto<T>, IPagedResult<T>
    {
        /// <summary>
        /// Total count of Items.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int TotalCount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int SkipCount { get; set; }

        /// <summary>
        /// Creates a new <see cref="PagedResultDto{T}"/> object.
        /// </summary>
        public PagedResultDto()
        {

        }

        /// <summary>
        /// Creates a new <see cref="PagedResultDto{T}"/> object.
        /// </summary>
        /// <param name="totalCount">Total count of Items</param>
        /// <param name="items">List of items in current page</param>
        public PagedResultDto(int totalCount, IReadOnlyList<T> items)
            : base(items)
        {
            TotalCount = totalCount;
        }
    }
}