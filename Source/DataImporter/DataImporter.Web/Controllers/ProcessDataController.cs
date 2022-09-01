using DataImporter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DataImporter.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProcessDataController : ControllerBase
    {
        private readonly ILogger<ProcessDataController> m_Logger;
        private readonly IFileProcessorService m_FileProcessorService;
        private readonly IVolumeProcessorService m_VolumeProcessorService;
        private static readonly string m_FileTemplate = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).ToString(), @"Resources\data2x2.csv");

        public ProcessDataController(ILogger<ProcessDataController> logger, IFileProcessorService fileProcessorService, IVolumeProcessorService volumeProcessorService)
        {
            m_Logger = logger;
            m_FileProcessorService = fileProcessorService;
            m_VolumeProcessorService = volumeProcessorService;
        }

        [HttpPost("GetVolumeAboveFluidContact")]
        public double Post(double topToBaseDistance, double fluidContact, double crossInterval, double inlineInterval)
        {
            var data = m_FileProcessorService.ReadAndProcess(m_FileTemplate, topToBaseDistance, fluidContact, crossInterval, inlineInterval);
            return m_VolumeProcessorService.GetVolumeAboveFluidContact(data.Data, fluidContact);
        }

        [HttpPost("GetVolume")]
        public double PostFull(double topToBaseDistance, double fluidContact, double crossInterval, double inlineInterval)
        {
            var data = m_FileProcessorService.ReadAndProcess(m_FileTemplate, topToBaseDistance, fluidContact, crossInterval, inlineInterval);
            return m_VolumeProcessorService.GetVolume(data.Data);
        }
    }
}