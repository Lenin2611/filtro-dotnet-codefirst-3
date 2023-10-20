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
    public class EmpresaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpresaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> Get()
        {
            var results = await _unitOfWork.Empresas.GetAllAsync();
            return _mapper.Map<List<EmpresaDto>>(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpresaDto>> Get(int id)
        {
            var result = await _unitOfWork.Empresas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<EmpresaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpresaDto>> Post(EmpresaDto resultDto)
        {
            var result = _mapper.Map<Empresa>(resultDto);
            if (resultDto.FechaCreacion == DateOnly.MinValue)
            {
                result.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
                resultDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Empresas.Add(result);
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
        public async Task<ActionResult<EmpresaDto>> Put(int id, [FromBody] EmpresaDto resultDto)
        {
            var exists = await _unitOfWork.Empresas.GetByIdAsync(id);
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
            if (resultDto.FechaCreacion == DateOnly.MinValue)
            {
                exists.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            }
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EmpresaDto>(exists);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Empresas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Empresas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}