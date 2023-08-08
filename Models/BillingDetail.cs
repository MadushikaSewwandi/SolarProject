﻿using Newtonsoft.Json;

namespace UmbracoSolarProject1.Models
{
    public class BillingDetail
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        

        public Register? Register { get; set; }
    }
}
