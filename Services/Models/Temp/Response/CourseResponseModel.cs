﻿using System;

namespace Services.Models.Temp.ResponseModels
{
    public class CourseResponseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}