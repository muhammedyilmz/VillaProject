using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{

    public class CounterController : Controller
    {
        private readonly ICounterService _counterService;
        private readonly IMapper _mapper;

        public CounterController(ICounterService counterService, IMapper mapper)
        {
            _counterService = counterService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _counterService.TGetListAsync();
            var counterList = _mapper.Map<List<ResultCounterDto>>(values);
            return View(counterList);
        }

        public async Task<IActionResult> DeleteCounter(ObjectId id)
        {
            await _counterService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateCounter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterDto createCounterDto)
        {
            var newCounter = _mapper.Map<Counter>(createCounterDto);
            await _counterService.TCreateAsync(newCounter);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCounter(ObjectId id)
        {
            var value = await _counterService.TGetByIdAsync(id);
            var updateCounter = _mapper.Map<UpdateCounterDto>(value);
            return View(updateCounter);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCounter(UpdateCounterDto updateCounterDto)
        {
            var newCounter = _mapper.Map<Counter>(updateCounterDto);
            await _counterService.TUpdateAsync(newCounter);
            return RedirectToAction("Index");
        }

    }
}