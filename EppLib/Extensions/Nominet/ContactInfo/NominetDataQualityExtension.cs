﻿using System;
using System.Collections.Generic;

namespace EppLib.Extensions.Nominet.ContactInfo
{
    public class NominetDataQualityExtension
    {
        public string Status { get; set; }
        public string Reason { get; set; }
        public DateTime? DateCommenced { get; set; }
        public DateTime? DateToSuspend { get; set; }
        public bool? LockApplied { get; set; }
        public List<string> DomainList { get; set; }
    }
}
