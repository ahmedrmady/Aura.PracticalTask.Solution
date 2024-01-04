using Aura.PracticalTask.Data;
using Aura.PracticalTask.Data.Entites;
using Aura.PracticalTask.Dtos;
using Aura.PracticalTask.Services;
using Aura.PracticalTask.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Aura.PracticalTask.Errors;

namespace Aura.PracticalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {

        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {

            this._recordService = recordService;
        }

        [HttpPost] // POST : /api/Main/Records
        public async Task<ActionResult<RecordToReturnDto>> AddRecordAsync(RecordDto dto)
        {

            var record = await _recordService.AddRecodAsync(new Record( ) { Name = dto.Name  } );
            
            if(record is null) return BadRequest(new ApiResponse(400));

            return Ok(new RecordToReturnDto(record.Id,record.Name));
           
        }

        [HttpDelete] //DELETE : /api/Records?id=id
        public async Task<ActionResult<bool>> RemoveRecordAsync([FromQuery] int id)
        {


            var isDeleted = await _recordService.DeleteRecordAsync(id);

            return isDeleted ? Ok(true) : BadRequest(new ApiResponse(400));
        }

        [HttpGet] //GET : /api/Record
        public async Task<ActionResult<IReadOnlyList<RecordToReturnDto>>> GetAllAsync()
        {

            var recordsList = await _recordService.GetAllRecodAsync();
            if (recordsList is null) return NotFound(new ApiResponse(404));

            var recordeListDto = new List<RecordToReturnDto>();

            //map record to recordDto,and add it in the list
             foreach (var record in recordsList)
                recordeListDto.Add(new RecordToReturnDto(record.Id,record.Name));

             //return the RecordsDtoList
            return Ok(recordeListDto);

        }


    }
}
