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
    public class PrendaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrendaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PrendaDto>>> Get()
        {
            var results = await _unitOfWork.Prendas.GetAllAsync();
            return _mapper.Map<List<PrendaDto>>(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrendaDto>> Get(int id)
        {
            var result = await _unitOfWork.Prendas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<PrendaDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PrendaDto>> Post(PrendaDto resultDto)
        {
            var result = _mapper.Map<Prenda>(resultDto);
            _unitOfWork.Prendas.Add(result);
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
        public async Task<ActionResult<PrendaDto>> Put(int id, [FromBody] PrendaDto resultDto)
        {
            var exists = await _unitOfWork.Prendas.GetByIdAsync(id);
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
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PrendaDto>(exists);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Prendas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Prendas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}