using System;

namespace Net5ApiWeb.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }
        public double Gia { get; set; }
    }

    public class HangHoa : HangHoaVM
    {
        public Guid HangHoaGuid { get; set;}
    }
}
