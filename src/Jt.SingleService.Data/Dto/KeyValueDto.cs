﻿namespace Jt.SingleService.Data
{
    public class KeyValueDto<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
