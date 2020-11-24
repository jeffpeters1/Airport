using Airport.CORE.Interfaces;
using Airport.CORE.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Airport.API.Controllers
{
    [ApiController]
    [Route("api/arrivals")]
    public class ArrivalController : Controller
    {
        private readonly IArrivalService _arrivalService;
        private readonly IMapper _mapper;


        public ArrivalController(IArrivalService arrivalService, IMapper mapper)
        {
            _arrivalService = arrivalService;
            _mapper = mapper;
        }

        //========================
        // GET
        //========================
        [HttpGet()]
        public ActionResult<IEnumerable<PlaneDto>> GetArrivals()
        {
            var arrivals = _arrivalService.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlaneDto>>(arrivals));
        }

        [HttpGet("{flightNumber:int}", Name = "GetPlane")]
        public IActionResult GetPlane(int flightNumber)
        {
            var arrival = _arrivalService.GetPlane(flightNumber);
            return Ok(_mapper.Map<PlaneDto>(arrival));
        }

        //========================
        // POST
        //========================
        [HttpPost]
        public ActionResult CreateArrival(PlaneForCreationDto plane)
        {
            var planeEntity = _mapper.Map<CORE.Entities.Plane>(plane);

            // Can plane be landed?
            if (!_arrivalService.IsArrivalPossible(planeEntity))
                return new StatusCodeResult(429);

            // Land plane
            _arrivalService.AddPlane(planeEntity);

            var planeToReturn = _mapper.Map<PlaneDto>(planeEntity);

            return CreatedAtRoute("GetPlane", new { flightNumber = planeToReturn.FlightNumber }, planeToReturn);
        }
    }
}