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
    public class VentaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VentaDto>>> Get()
        {
            var results = await _unitOfWork.Ventas.GetAllAsync();
            return _mapper.Map<List<VentaDto>>(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentaDto>> Get(int id)
        {
            var result = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<VentaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VentaDto>> Post(VentaDto resultDto)
        {
            var result = _mapper.Map<Venta>(resultDto);
            if (resultDto.Fecha == DateOnly.MinValue)
            {
                result.Fecha = DateOnly.FromDateTime(DateTime.Now);
                resultDto.Fecha = DateOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Ventas.Add(result);
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
        public async Task<ActionResult<VentaDto>> Put(int id, [FromBody] VentaDto resultDto)
        {
            var exists = await _unitOfWork.Ventas.GetByIdAsync(id);
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
            if (resultDto.Fecha == DateOnly.MinValue)
            {
                exists.Fecha = DateOnly.FromDateTime(DateTime.Now);
            }
            await _unitOfWork.SaveAsync();
            return _mapper.Map<VentaDto>(exists);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Ventas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}