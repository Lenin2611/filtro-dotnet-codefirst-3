using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpleadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
        {
            var results = await _unitOfWork.Empleados.GetAllAsync();
            return _mapper.Map<List<EmpleadoDto>>(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> Get(int id)
        {
            var result = await _unitOfWork.Empleados.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<EmpleadoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDto>> Post(EmpleadoDto resultDto)
        {
            var result = _mapper.Map<Empleado>(resultDto);
            if (resultDto.FechaIngreso == DateOnly.MinValue)
            {
                resultDto.FechaIngreso = DateOnly.FromDateTime(DateTime.Now);
                result.FechaIngreso = DateOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Empleados.Add(result);
            await _unitOfWork.SaveAsync();
            if (result == null)
            {
                return BadRequest();
            }
            resultDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto resultDto)
        {
            var exists = await _unitOfWork.Empleados.GetByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }
            if (resultDto.Id == 0)
            {
                resultDto.Id = id;
            }
            if (resultDto.Id != id)
            {
                return BadRequest();
            }
            _mapper.Map(resultDto, exists);
            if (resultDto.FechaIngreso == DateOnly.MinValue)
            {
                exists.FechaIngreso = DateOnly.FromDateTime(DateTime.Now);
            }
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EmpleadoDto>(exists);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Empleados.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Empleados.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}