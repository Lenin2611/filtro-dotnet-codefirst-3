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
    public class CargoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CargoDto>>> Get()
        {
            var results = await _unitOfWork.Cargos.GetAllAsync();
            return _mapper.Map<List<CargoDto>>(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CargoDto>> Get(int id)
        {
            var result = await _unitOfWork.Cargos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<CargoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CargoDto>> Post(CargoDto resultDto)
        {
            var result = _mapper.Map<Cargo>(resultDto);
            _unitOfWork.Cargos.Add(result);
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
        public async Task<ActionResult<CargoDto>> Put(int id, [FromBody] CargoDto resultDto)
        {
            var exists = await _unitOfWork.Cargos.GetByIdAsync(id);
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
            return _mapper.Map<CargoDto>(exists);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Cargos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Cargos.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}