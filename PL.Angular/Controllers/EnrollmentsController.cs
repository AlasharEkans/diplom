using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;
using PL.Angular.Models;

namespace PL.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController(IEnrollmentService enrollmentService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<EnrollmentDTO>> CreateEnrollment([FromBody] EnrollmentRequestModel request)
        {
            try
            {
                var enrollment = await enrollmentService.CreateEnrollmentAsync(request.UserId, request.CourseIds);
                return Ok(enrollment);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("student/{userId}")]
        public async Task<ActionResult<IEnumerable<EnrollmentDTO>>> GetStudentEnrollments(Guid userId)
        {
            var enrollments = await enrollmentService.GetStudentEnrollmentsAsync(userId);
            return Ok(enrollments);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentDTO>>> GetAllEnrollments()
        {
            var enrollments = await enrollmentService.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] EnrollmentStatus status)
        {
            await enrollmentService.UpdateStatusAsync(id, status);
            return Ok();
        }
    }
}