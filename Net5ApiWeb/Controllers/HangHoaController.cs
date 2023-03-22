using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5ApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net5ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoas);
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                // Query
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.HangHoaGuid == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(HangHoaVM hanghoaVM)
        {
            var hanghoa = new HangHoa
            {
                HangHoaGuid = Guid.NewGuid(),
                TenHangHoa = hanghoaVM.TenHangHoa,
                Gia = hanghoaVM.Gia,
            };
            hanghoas.Add(hanghoa);
            return Ok(new
            {
                Success = true, Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id,HangHoa hanghoaput)
        {
            try
            {
                // Query
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.HangHoaGuid == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if(id != hanghoaput.HangHoaGuid.ToString())
                {
                    return BadRequest();
                }
                // Update
                hanghoa.TenHangHoa = hanghoaput.TenHangHoa;
                hanghoa.Gia = hanghoaput.Gia;
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                // Query
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.HangHoaGuid == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                hanghoas.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
