using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinlist.Shared.DTOs.Sinlists
{
    public class GetTodoListRequest
    {
        public int TodolistId { get; set; }
        public string DeviceInfo { get; set; }
    }
}
