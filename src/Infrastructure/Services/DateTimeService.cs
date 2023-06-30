using SRIS.Application.Common.Interfaces;
using System;

namespace SRIS.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
