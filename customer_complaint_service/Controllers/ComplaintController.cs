using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using customer_complaint_service.Entities;
using Microsoft.Data.SqlClient;

namespace customer_complaint_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        AuditServiceContext context = new AuditServiceContext();

        [HttpPost("addComplaint")]
        public IActionResult addComplaint([FromBody] CustomerComplaint customerComplaint)
        {
            try
            {
                context.Add(customerComplaint);
                context.SaveChanges();
                return Ok(customerComplaint);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetallCompalins")]

        public IActionResult getallcompalints()
        {
            var complains = context.CustomerComplaints.ToList();

            try
            {
                return Ok(complains);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getcomplaintbyEmail/{email}")]
        public IActionResult getbyEmail([FromRoute] string email)
        {
            var complaints = context.CustomerComplaints.Where(x => x.PatientEmail == email).ToList();

            try
            {
                return Ok(complaints);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
