using System.Collections.Generic;

namespace DPizza.Application.DTOs
{
    public class PagenationResponseDto<T>
    {
        public PagenationResponseDto(List<T> data, int count)
        {
            Data = data;
            Count = count;
        }
        public List<T> Data { get; set; }
        public int Count { get; set; }
    }
}
