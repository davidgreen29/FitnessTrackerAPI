using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using trackerApi.Contracts;
using trackerApi.Data;
using trackerApi.Exceptions;
using trackerApi.Models.Weights;
using trackerApi.Repository;

namespace trackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class WeightsController : ControllerBase
    {
        private readonly IWeightsRepository _weightsRepository;
        private readonly IMapper _mapper;

        public WeightsController(IWeightsRepository weightsRepository,IMapper mapper)
        {
            this._weightsRepository = weightsRepository;
            this._mapper = mapper;
        }

        // GET: api/Weights
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<UserWeightDto>>> GetWeights()
        {
            var weights = await _weightsRepository.GetAllAsync();
            return Ok(_mapper.Map<UserWeightDto>(weights));
        }

        // GET: api/Weights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weight>> GetWeight(int id)
        {
            var weight = await _weightsRepository.GetAsync(id);

            if (weight == null)
            {
                throw new NotFoundException(nameof(GetWeight), id);
            }

            return Ok(_mapper.Map<UserWeightDto>(weight));
        }


        // PUT: api/Weights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeight(int id, UserWeightDto weightDto)
        {
            if (id != weightDto.Id)
            {
                return BadRequest();
            }

            var weight = await _weightsRepository.GetAsync(id);

            try
            {
                await _weightsRepository.UpdateAsync(weight);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WeightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weight>> PostWeight(CreateWeightDto weightDto)
        {
            var weight = _mapper.Map<Weight>(weightDto);
            await _weightsRepository.AddAsync(weight);  

            return CreatedAtAction("GetWeight", new { id = weight.Id }, weight);
        }

        // DELETE: api/Weights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeight(int id)
        {
            var weight = await _weightsRepository.GetAsync(id);
            if (weight == null)
            {
               throw new NotFoundException(nameof(GetWeight), id);    
            }


            await _weightsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> WeightExists(int id)
        {
            return await _weightsRepository.Exists(id);
        }
    }
}
