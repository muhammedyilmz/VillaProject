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
using Villa.Dto.Dtos.FeatureDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _featureService.TGetListAsync();
            var featureList = _mapper.Map<List<ResultFeatureDto>>(values);
            return View(featureList);
        }

        public async Task<IActionResult> DeleteFeature(ObjectId id)
        {
            await _featureService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var newFeature = _mapper.Map<Feature>(createFeatureDto);
            await _featureService.TCreateAsync(newFeature);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateFeature(ObjectId id)
        {
            var value = await _featureService.TGetByIdAsync(id);
            var updateFeature = _mapper.Map<UpdateFeatureDto>(value);
            return View(updateFeature);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var newFeature = _mapper.Map<Feature>(updateFeatureDto);
            await _featureService.TUpdateAsync(newFeature);
            return RedirectToAction("Index");
        }
    }
}