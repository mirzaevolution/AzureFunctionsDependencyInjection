﻿using System;

namespace Welcome.DataTransferObjects
{
    public class ConfigMapDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
